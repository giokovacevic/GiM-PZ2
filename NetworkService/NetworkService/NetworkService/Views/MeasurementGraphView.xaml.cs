using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace NetworkService.Views
{
    /// <summary>
    /// Interaction logic for MeasurementGraphView.xaml
    /// </summary>
    public partial class MeasurementGraphView : UserControl
    {
        public MeasurementGraphView()
        {
            InitializeComponent();
        }

        private void MeterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxMeters.SelectedItem is Meter selectedMeter)
            {
                int selectedIndex = ComboBoxMeters.SelectedIndex;
                DrawGraph(selectedMeter, selectedIndex);
            }
        }

        private void DrawGraph(Meter m, int index)
        {
            int id = -1;
            double measure = 0.0;
            string date = "";

            List<double> valuesUnfiltered = new List<double>();
            List<double> values = new List<double>();

            if (File.Exists("log.txt"))
             {
                 
                 string[] lines = File.ReadAllLines("log.txt");
                 foreach (string line in lines)
                 {
                    Console.WriteLine(line);
                    //index,value,date
                    String[] stringArray = line.Split(',');
                    id = Int32.Parse(stringArray[0]);
                    measure = Double.Parse(stringArray[1]);
                    date = stringArray[2];
                    if(id == index)
                    {
                        values.Add(measure);
                        if (values.Count > 5)
                        {
                            values.RemoveAt(0);
                        }
                    }
                 }

             }
            
            GraphCanvas.Children.Clear();
            double startX = 10; 
            double startY = GraphCanvas.ActualHeight / 2; 
            double maxRadius = 50; 
            double spacing = 10; 

            for (int i = 0; i < values.Count; i++)
            {
                double value = values[i];
                double radius = value / values.Max() * maxRadius; 

                Ellipse ellipse = new Ellipse
                {
                    Width = radius * 2,
                    Height = radius * 2,
                    Stroke = Brushes.Black,
                    Fill = Brushes.Red,
                    Opacity = 0.75
                };

              
                Canvas.SetLeft(ellipse, startX);

                Canvas.SetTop(ellipse, startY - radius); 

                GraphCanvas.Children.Add(ellipse);

               
                TextBlock textBlock = new TextBlock
                {
                    Text = $"{value:F2}",
                    FontSize = 14,
                    Foreground = (value > 2.73 || value < 0.34) ? Brushes.Red : Brushes.Black,
                    TextAlignment = TextAlignment.Center
                };

                Canvas.SetLeft(textBlock, startX);
                Canvas.SetTop(textBlock, startY + radius + 5); 

                GraphCanvas.Children.Add(textBlock);

               
                startX += radius * 2 + spacing;
            }
        
        }
    }
}
