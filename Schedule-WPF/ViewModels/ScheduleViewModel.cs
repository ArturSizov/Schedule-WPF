using Prism.Mvvm;
using Schedule_WPF.Models;
using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace Schedule_WPF.ViewModels
{
    public class ScheduleViewModel : BindableBase
    {
        #region Private property 
        private int pending;
        private int jeopardy;
        private int completed;
        private string? minutes = "65";
        private int minute;
        private ObservableCollection<Schedule>? schedules = new();
        private int scrollPosition;

        #endregion

        #region Public property 
        public string Title => "Schedule";
        public DateTime DateTimeNow => DateTime.Now;
        public int Pending { get => pending; set => SetProperty(ref pending, value); }
        public int Jeopardy { get => jeopardy; set => SetProperty(ref jeopardy, value); }
        public int Completed { get => completed; set => SetProperty(ref completed, value); }
        public string Minutes { get => minutes!; set => SetProperty(ref minutes, value); }
        public int Minute { get => minute; set => SetProperty(ref minute, value); }
        public int ScrollPosition { get => scrollPosition; set => SetProperty(ref scrollPosition, value); }
        public ObservableCollection<Schedule> Schedules { get => schedules!; set => SetProperty(ref schedules, value); } 
        #endregion

        public ScheduleViewModel()
        {
            StartTimer();

            Schedules = new ObservableCollection<Schedule>
            {
                new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },
                new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },new Schedule
                {
                    Pending = true,
                    Completed = true,
                    Jeopardy = false,
                    Id = 1
                },
            };

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

        #region Methods 
        private void SetPosition(object? sender, ElapsedEventArgs? e)
        {
            Minute = DateTime.Now.Minute * 25;
            ScrollPosition = Minute/25*10;
            RaisePropertyChanged(nameof(Minute));
            RaisePropertyChanged(nameof(ScrollPosition));
        }
        private void StartTimer()
        {
            SetPosition(null, null);
            var timer = new Timer();
            timer.Interval = 10000;
            timer.Elapsed += SetPosition;
            timer.Start();
        }
        #endregion
    }
}
