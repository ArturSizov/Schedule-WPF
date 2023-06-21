using Prism.Mvvm;
using System;
using System.Windows.Controls;

namespace Schedule_WPF.ViewModels
{
    public class ScheduleViewModel : BindableBase
    {

        #region Private property 
        private int pending = 12;
        private int jeopardy;
        private int completed;
        private string? minutes = "65";

        #endregion

        #region Public property 
        public string Title => "Schedule";
        public DateTime DateTimeNow => DateTime.Now;
        public int Pending { get => pending; set => SetProperty(ref pending, value); }
        public int Jeopardy { get => jeopardy; set => SetProperty(ref jeopardy, value); }
        public int Completed { get => completed; set => SetProperty(ref completed, value); }
        public string Minutes { get => minutes!; set => SetProperty(ref minutes, value); } 
        #endregion
    }
}
