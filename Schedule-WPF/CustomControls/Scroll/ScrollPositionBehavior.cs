using System.Windows.Controls;
using System.Windows;

namespace Schedule_WPF.CustomControls.Scroll
{
    public static class ScrollPositionBehavior
    {

        #region Private Dependency
        private static readonly DependencyProperty IsScrollPositionBoundProperty = DependencyProperty.RegisterAttached("IsScrollPositionBound", typeof(bool?), typeof(ScrollPositionBehavior));

        #endregion

        #region Public Dependency
        public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.RegisterAttached("HorizontalOffset",
                typeof(double),
                typeof(ScrollPositionBehavior),
                new FrameworkPropertyMetadata(double.NaN, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnHorizontalOffsetPropertyChanged));

        public static readonly DependencyProperty VerticalOffsetProperty =
            DependencyProperty.RegisterAttached(
                "VerticalOffset",
                typeof(double),
                typeof(ScrollPositionBehavior),
                new FrameworkPropertyMetadata(
                    double.NaN,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnVerticalOffsetPropertyChanged));
        #endregion

        #region Methods 
        public static void BindOffset(ScrollViewer scrollViewer)
        {
            if (scrollViewer.GetValue(IsScrollPositionBoundProperty) is true)
                return;

            scrollViewer.SetValue(IsScrollPositionBoundProperty, true);

            scrollViewer.Loaded += ScrollViewer_Loaded;
            scrollViewer.Unloaded += ScrollViewer_Unloaded;
        }

        public static double GetHorizontalOffset(DependencyObject depObj)
        {
            return (double)depObj.GetValue(HorizontalOffsetProperty);
        }

        public static double GetVerticalOffset(DependencyObject depObj)
        {
            return (double)depObj.GetValue(VerticalOffsetProperty);
        }

        public static void SetHorizontalOffset(DependencyObject depObj, double value)
        {
            depObj.SetValue(HorizontalOffsetProperty, value);
        }

        public static void SetVerticalOffset(DependencyObject depObj, double value)
        {
            depObj.SetValue(VerticalOffsetProperty, value);
        }

        private static void OnHorizontalOffsetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScrollViewer scrollViewer = d as ScrollViewer;
            if (scrollViewer == null || double.IsNaN((double)e.NewValue))
                return;

            BindOffset(scrollViewer);
            scrollViewer.ScrollToHorizontalOffset((double)e.NewValue);
        }

        private static void OnVerticalOffsetPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScrollViewer scrollViewer = d as ScrollViewer;
            if (scrollViewer == null || double.IsNaN((double)e.NewValue))
                return;

            BindOffset(scrollViewer);
            scrollViewer.ScrollToVerticalOffset((double)e.NewValue);
        }

        private static void ScrollChanged(object s, ScrollChangedEventArgs se)
        {
            if (se.VerticalChange != 0)
                SetVerticalOffset(s as ScrollViewer, se.VerticalOffset);

            if (se.HorizontalChange != 0)
                SetHorizontalOffset(s as ScrollViewer, se.HorizontalOffset);
        }

        private static void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            scrollViewer.ScrollChanged += ScrollChanged;
        }

        private static void ScrollViewer_Unloaded(object sender, RoutedEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;
            scrollViewer?.SetValue(IsScrollPositionBoundProperty, false);

            scrollViewer.ScrollChanged -= ScrollChanged;
            scrollViewer.Loaded -= ScrollViewer_Loaded;
            scrollViewer.Unloaded -= ScrollViewer_Unloaded;
        }
        #endregion
    }
}
