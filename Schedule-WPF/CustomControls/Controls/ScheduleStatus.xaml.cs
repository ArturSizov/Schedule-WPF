using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Schedule_WPF.CustomControls.Controls
{
    /// <summary>
    /// Логика взаимодействия для ScheduleStatus.xaml
    /// </summary>
    public partial class ScheduleStatus : Canvas
    {
        #region Public property 
        public double PositionLeft
        {
            get => (double)GetValue(PositionPropertyLeft);
            set
            {
                SetValue(PositionPropertyLeft, value);
            }
        }
        public double PositionTop
        {
            get => (double)GetValue(PositionPropertyTop);
            set
            {
                SetValue(PositionPropertyTop, value);
            }
        }

        #endregion
        public ScheduleStatus()
        {
            InitializeComponent();
            CreateOneRectangle();
        }

        #region DependencyProperty
        public static readonly DependencyProperty PositionPropertyLeft = DependencyProperty.Register(nameof(PositionLeft), typeof(double), typeof(ScheduleStatus),
                             new PropertyMetadata(PositionPropertyChanged));
        public static readonly DependencyProperty PositionPropertyTop = DependencyProperty.Register(nameof(PositionTop), typeof(double), typeof(ScheduleStatus),
                             new PropertyMetadata(PositionPropertyChanged));
        #endregion

        #region Envets 
        private static void PositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ScheduleStatus)d).SetPosition();
        }
        #endregion

        #region Methods 
        private void SetPosition()
        {
            SetLeft(canvas, PositionLeft);
            SetTop(canvas, PositionTop);
        }

        private System.Windows.Shapes.Rectangle CreateOneRectangle()
        {
            var rect = new System.Windows.Shapes.Rectangle();
            rect.Width = 550;
            rect.Height = 88;
            rect.Fill = System.Windows.Media.Brushes.Red;
            canvas.Children.Add(rect);
            return rect;
        }
        #endregion
    }
}
