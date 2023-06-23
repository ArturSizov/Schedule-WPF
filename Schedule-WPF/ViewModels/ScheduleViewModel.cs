using Prism.Mvvm;
using System;
using System.Timers;

namespace Schedule_WPF.ViewModels
{
    public class ScheduleViewModel : BindableBase
    {

        #region Private property 
        private int pending = 12;
        private int jeopardy;
        private int completed;
        private string? minutes = "65";
        private int minute;
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
        #endregion

        public ScheduleViewModel()
        {
            StartTimer();
        }


        #region Methods 
        private void SetPosition(object sender, ElapsedEventArgs e)
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
