using Prism.Ioc;
using Schedule_WPF.ViewModels;
using Schedule_WPF.Views;
using System.Windows;

namespace Schedule_WPF
{
    public partial class App
    {
        protected override Window CreateShell() => Container.Resolve<Schedule>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<ScheduleViewModel>();
        }
    }
}
