using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Schedule_WPF.CustomControls.Controls
{
    public partial class Ruler : Canvas
    {
        #region Private propery 
        private int count = 0;
        #endregion

        #region Public property 
        public string Number
        {
            get => (string)GetValue(NumberProperty);
            set
            {
                SetValue(NumberProperty, value); 
            }
        }

        public int Position
        {
            get => (int)GetValue(PositionProperty);
            set
            {
                SetValue(PositionProperty, value);
            }
        }
        #endregion

        #region DependencyProperty
        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register(nameof(Number), typeof(string), typeof(Ruler),
                               new PropertyMetadata(NumberPropertyChanged));

        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register(nameof(Position), typeof(int), typeof(Ruler),
                               new PropertyMetadata(PositionPropertyChanged));
        #endregion

        public Ruler()
        {
            InitializeComponent();
        }

        #region Methods 
        private static void NumberPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Ruler)d).NumberPropertyChanged();
        }

        private void NumberPropertyChanged()
        {
            var n = Convert.ToInt32(Number) / 5;

            //if (n == 0) throw new Exception("Ruler value 0");

            for (int i = 0; i < n; i++)
            {
                sp.Children.Add(CreateRoler());
                count = count + 5;
            }
        }

        private static void PositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Ruler)d).PositionPropertyChanged();
        }
        private void PositionPropertyChanged()
        {
            var pos = Position;

            SetLeft(sp, pos);
        }
        private Line CreateLine(int x1, int y1, int x2, int y2)
        {
            var line = new Line();
            line.X1 = x1;
            line.Y1 = y1;
            line.X2 = x2;
            line.Y2 = y2;
            line.Stroke = Brushes.Black;
            return line;
        }
        private Grid CreateRoler()
        {
            var grid = new Grid();
            var text = new TextBlock();
            text.Margin = new Thickness(2, -5, 0, 0);
            text.Text = $"{count}";
            grid.Children.Add(text);
            grid.Children.Add(CreateLine(0, 15, 125, 15));
            grid.Children.Add(CreateLine(0, -5, 0, 15));
            grid.Children.Add(CreateLine(25, 7, 25, 15));
            grid.Children.Add(CreateLine(50, 7, 50, 15));
            grid.Children.Add(CreateLine(75, 7, 75, 15));
            grid.Children.Add(CreateLine(100, 7, 100, 15));
            grid.Children.Add(CreateLine(125, 0, 125, 0));

            return grid;
        }
        #endregion
    }
}
