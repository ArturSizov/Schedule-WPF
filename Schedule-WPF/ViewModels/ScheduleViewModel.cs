using Prism.Mvvm;
using Schedule_WPF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;

namespace Schedule_WPF.ViewModels
{
    public class ScheduleViewModel : BindableBase
    {
        #region Private property 
        private List<DateTime> dates = new();
        private DateTime mainWindowDate;
        private DateTime startDateTime;
        private DateTime endDateTime;
        private int pending;
        private int jeopardy;
        private int completed;
        private string? minutes = "60";
        private int minute;
        private ObservableCollection<Schedule>? schedules = new();
        private int sliderPosition;
        private bool visibilityDividingLine;

        #endregion

        #region Public property 
        public string Title => "Schedule";
        public List<DateTime> Dates { get => dates; set => SetProperty(ref dates, value); } 
        public DateTime MainWindowDate { get => mainWindowDate; set => SetProperty(ref mainWindowDate, value); } 
        public DateTime StartDateTime { get => startDateTime; set => SetProperty(ref startDateTime, value); }
        public DateTime EndDateTime { get => endDateTime; set => SetProperty(ref endDateTime, value); }
        public int Pending { get => pending; set => SetProperty(ref pending, value); }
        public int Jeopardy { get => jeopardy; set => SetProperty(ref jeopardy, value); }
        public int Completed { get => completed; set => SetProperty(ref completed, value); }
        public string Minutes { get => minutes!; set => SetProperty(ref minutes, value); }
        public int Minute { get => minute; set => SetProperty(ref minute, value); }
        public bool VisibilityDividingLine 
        { 
            get 
            {
                if (Dates.Any(d => d >= DateTime.Now))
                    visibilityDividingLine = true;

                return visibilityDividingLine; 
            } 
            set => SetProperty(ref visibilityDividingLine, value); }
        public int SliderPosition
        {
            get
            {
                if (Dates.Count == sliderPosition)
                    MainWindowDate = Dates[(sliderPosition - 1) /1500];
                else MainWindowDate = Dates[sliderPosition / 1500];
                return sliderPosition;
            }
            set => SetProperty(ref sliderPosition, value);
        }
        public ObservableCollection<Schedule> Schedules { get => schedules!; set => SetProperty(ref schedules, value); }
        #endregion

        public ScheduleViewModel()
        {
            Schedules = new ObservableCollection<Schedule>
            {
                new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1,
                    StartDateTime = new DateTime(2023, 7, 4, 10, 00, 00),
                    EndDateTime = new DateTime(2023, 7, 4, 13, 00, 00)
                },
                new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1,
                    StartDateTime = new DateTime(2023, 7, 4, 12, 00, 00),
                    EndDateTime = new DateTime(2023, 7, 4, 15, 00, 00)
                },
                new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1,
                    StartDateTime = new DateTime(2023, 7, 14, 10, 00, 00),
                    EndDateTime = new DateTime(2023, 7, 11, 16, 00, 00)
                },
            };
            StartApp();
        }

        #region Methods
        private void StartApp()
        {
            Timing();

            StartTimer();

            foreach (var item in Schedules)
            {
                if (item.Jeopardy == true)
                    Pending++;
                if (item.Completed == true)
                    Completed++;
                if (item.Pending == true)
                    Jeopardy++;
            }

        }
        private void SetPosition(object? sender, ElapsedEventArgs? e)
        {
            Minute = (int)DateTime.Now.Subtract(StartDateTime).TotalMinutes * 25;

            //Minute = Dates.Count * 60 * 25;

            //var min = DateTime.Now.Hour;

            //SliderPosition = Minute;
            RaisePropertyChanged(nameof(Minute));
            RaisePropertyChanged(nameof(SliderPosition));
        }
        private void StartTimer()
        {
            SetPosition(null, null);

            var timer = new Timer
            {
                Interval = 10000
            };
            timer.Elapsed += SetPosition;
            timer.Start();
        }
        private void Timing()
        {
            StartDateTime = Schedules.Min(a => a.StartDateTime);
            EndDateTime = Schedules.Max(a => a.EndDateTime);

            for (var dt = StartDateTime; dt <= EndDateTime; dt = dt.AddHours(1))
            {
                Dates.Add(dt);
            }

            MainWindowDate = Dates[SliderPosition];
        }
        #endregion
    }
}
