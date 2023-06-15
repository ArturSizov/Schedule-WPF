using System;
using System.Windows.Controls;

namespace Schedule_WPF.ViewModels
{
    public class ScheduleViewModel
    {

        #region Public property 
        public string Title => "Schedule";
        public DateTime DateTimeNow => DateTime.Now;
        #endregion
    }
}
