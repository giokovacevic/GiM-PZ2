using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NetworkService.Helper;
using NetworkService.ViewModel;

namespace NetworkService.Views
{
    /// <summary>
    /// Interaction logic for NetworkDisplayView.xaml
    /// </summary>
    public partial class NetworkDisplayView : UserControl
    {
        private object _draggedMeter;

        public NetworkDisplayView()
        {
            InitializeComponent();
        }

        private void TreeView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeView treeView = sender as TreeView;
            _draggedMeter = GetTreeViewItemUnderMouse(treeView, e.GetPosition(treeView)) as Meter;
            if (_draggedMeter != null)
            {
                DragDrop.DoDragDrop(treeView, _draggedMeter, DragDropEffects.Move);
            }
        }

        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            if (_draggedMeter != null)
            {
                Canvas canvas = sender as Canvas;
                var viewModel = DataContext as NetworkDisplayViewModel;

           
                viewModel?.RemoveMeter((Meter)_draggedMeter);

                Image image = new Image();
                image.Source = new BitmapImage(new Uri("pack://application:,,,/NetworkService;component/Assets/" + ((Meter)_draggedMeter).TypeOfMeter.ImageUrl));

                TextBlock textBlock = new TextBlock
                {
                    Text = ((Meter)_draggedMeter).Name,
                    Tag = _draggedMeter 
                };
                textBlock.FontSize = 16;

                TextBlock textBlockId = new TextBlock
                {
                    Text = ((Meter)_draggedMeter).Id.ToString(),
                    Tag = _draggedMeter 
                };
                textBlockId.FontSize = 16;


                TextBlock textBlockMeasure = new TextBlock();
                textBlockMeasure.FontSize = 16;
                textBlockMeasure.Text = ((Meter)_draggedMeter).Measure.ToString();
                if(((Meter)_draggedMeter).Measure < 0.34 || ((Meter)_draggedMeter).Measure > 2.73)
                {
                    textBlockMeasure.Foreground = Brushes.Red;
                    
                }
                canvas.Children.Add(image);
                canvas.Children.Add(textBlock);
                canvas.Children.Add(textBlockId);
                canvas.Children.Add(textBlockMeasure);

                Canvas.SetLeft(image, 15);
                Canvas.SetTop(image, 5);

                Canvas.SetLeft(textBlockId, 20);
                Canvas.SetBottom(textBlockId, 35);

                Canvas.SetLeft(textBlock, 15);
                Canvas.SetBottom(textBlock, 60);

                Canvas.SetLeft(textBlockMeasure, 90);
                Canvas.SetBottom(textBlockMeasure, 35);

                _draggedMeter = null;
            }
        }

        private void KickOutButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void TreeView_Drop(object sender, DragEventArgs e)
        {
            if (_draggedMeter != null)
            {
                var viewModel = DataContext as NetworkDisplayViewModel;
                viewModel?.AddMeter((Meter)_draggedMeter);

                _draggedMeter = null;
            }
        }



        private static object GetTreeViewItemUnderMouse(TreeView treeView, Point position)
        {
            HitTestResult hitTestResult = VisualTreeHelper.HitTest(treeView, position);
            TreeViewItem treeViewItem = hitTestResult?.VisualHit.GetParentOfType<TreeViewItem>();
            return treeViewItem?.DataContext;
        }

    }
}
