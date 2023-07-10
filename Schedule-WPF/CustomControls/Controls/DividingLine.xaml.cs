using System.Windows;
using System.Windows.Controls;

namespace Schedule_WPF.CustomControls.Controls
{
    public partial class DividingLine : Canvas
    {
        #region Public property 
        public int Position
        {
            get => (int)GetValue(PositionProperty);
            set
            {
                SetValue(PositionProperty, value);
            }
        }
        public int Minute
        {
            get => (int)GetValue(MinuteProperty);
            set
            {
                SetValue(MinuteProperty, value);
            }
        }
        #endregion
        public DividingLine()
        {
            InitializeComponent();
            SetPosition();
        }

        #region DependencyProperty
        public static readonly DependencyProperty MinuteProperty = DependencyProperty.Register(nameof(Minute), typeof(int), typeof(DividingLine),
                               new PropertyMetadata(MinutePropertyChanged));
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register(nameof(Position), typeof(int), typeof(DividingLine),
                              new PropertyMetadata(PositionPropertyChanged));
        #endregion

        #region Envets 
        private static void PositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DividingLine)d).SetPosition();
        }
        private static void MinutePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DividingLine)d).SetMinute();
        }
        #endregion

        #region Methods 
        private void SetMinute()
        {
            SetLeft(minute, Minute);
        }
        private void SetPosition()
        {
            SetLeft(canvas, -Position);
        }
        #endregion
    }
}
