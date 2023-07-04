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
        #endregion
        public DividingLine()
        {
            InitializeComponent();
        }

        #region DependencyProperty
        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register(nameof(Position), typeof(int), typeof(DividingLine),
                               new PropertyMetadata(PositionPropertyChanged));
        #endregion


        #region Methods 
        private static void PositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DividingLine)d).PositionPropertyChanged();
        }
        private void PositionPropertyChanged()
        {
            SetLeft(grid, Position);
        }
        #endregion
    }
}
