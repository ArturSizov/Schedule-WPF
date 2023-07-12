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
        public int Position
        {
            get => (int)GetValue(PositionProperty);
            set
            {
                SetValue(PositionProperty, value);
            }
        }
        public int Watch
        {
            get => (int)GetValue(WatchProperty);
            set
            {
                SetValue(WatchProperty, value);
            }
        }

        #endregion

        #region DependencyProperty

        public static readonly DependencyProperty PositionProperty = DependencyProperty.Register(nameof(Position), typeof(int), typeof(Ruler),
                               new PropertyMetadata(PositionPropertyChanged));
        public static readonly DependencyProperty WatchProperty = DependencyProperty.Register(nameof(Watch), typeof(int), typeof(Ruler),
                              new PropertyMetadata(WatchPropertyChanged));
        #endregion

        public Ruler()
        {
            InitializeComponent();
        }

        #region Events
        private static void PositionPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Ruler)d).SetPosition();
        }
        private static void WatchPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Ruler)d).CreateWatch();
        }
        #endregion

        #region Methods 
        private StackPanel CreateFullRuler()
        {
            var stackPanel = new StackPanel
            {
                Orientation = Orientation.Horizontal
            };
            
            var n = Convert.ToInt32(60) / 5;

            if (n == 0) throw new Exception("Ruler value 0");

            for (int i = 0; i < n; i++)
            {
                stackPanel.Children.Add(CreateOneRuler());
                count += 5;
            }
            return stackPanel;
        }      
        private void SetPosition()
        {
            SetLeft(sp, -Position);
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
        private Grid CreateOneRuler()
        {
            var grid = new Grid();
            var text = new TextBlock
            {
                Margin = new Thickness(2, -5, 0, 0),
                Text = $"{count}"
            };
            
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
        private void CreateWatch()
        {
            for (int i = 0; i < Watch; i++)
            {
                count = 0;
                sp.Children.Add(CreateFullRuler());
            }
        }
        #endregion
    }
}
