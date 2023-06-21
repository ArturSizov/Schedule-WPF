using System.Drawing;
using System.Windows;
using System.Windows.Controls;

namespace Schedule_WPF.CustomControls.Controls
{
    public partial class CustomScrollViewer : ScrollViewer
    {
        #region Private property
        private ScrollViewer main = new();
        private ScrollViewer sub = new();
        #endregion

        #region Public property 
        public string MainName
        {
            get => (string)GetValue(MainScrollProperty);
            set
            {
                SetValue(MainScrollProperty, value);
            }
        }

        public  string SubName
        {
            get => (string)GetValue(SubScrollProperty);
            set
            {
                SetValue(SubScrollProperty, value);
            }
        }
        #endregion

        #region DependencyProperty
        public static readonly DependencyProperty MainScrollProperty = DependencyProperty.Register(nameof(MainName), typeof(string), typeof(CustomScrollViewer),
               new PropertyMetadata(ScrollPropertyChanged));

        public static readonly DependencyProperty SubScrollProperty = DependencyProperty.Register(nameof(SubName), typeof(string), typeof(CustomScrollViewer),
               new PropertyMetadata(ScrollPropertyChanged));

        #endregion

        public CustomScrollViewer()
        {
            InitializeComponent();
            sv.ScrollChanged += CustomScrollChanged;
        }

        #region Methods 
        private static void ScrollPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomScrollViewer)d).ScrollPropertyChanged();
        }
        #endregion

        private void ScrollPropertyChanged()
        {
            
        }

        private void CustomScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            main.Name = MainName;
            sub.Name = SubName;

            if (sender == main)
            {
                sub.ScrollToVerticalOffset(e.VerticalOffset);
                sub.ScrollToHorizontalOffset(e.HorizontalOffset);
            }
            else
            {
                main.ScrollToVerticalOffset(e.VerticalOffset);
                main.ScrollToHorizontalOffset(e.HorizontalOffset);
            }
        }
    }
}
