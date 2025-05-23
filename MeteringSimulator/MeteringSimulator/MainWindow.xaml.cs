﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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

namespace MeteringSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static double value = -1;
        private static int objectNum = 0;
        private int numObjects = -1;
        private Random r = new Random();
        public string chosenTopic = string.Empty;

        public MainWindow()
        {
            InitializeComponent();

            ProjectTopics.ItemsSource = new List<string>() { "T1", "T2", "T3", "T4", "T5", "T6", "T7" };

            RestartButton.IsEnabled = false;
        }

        private void askForCount()
        {
            try
            {
                //Pita koliko aplikacija ima objekata
                //Request
                Int32 port = 25675;
                TcpClient client = new TcpClient("localhost", port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("Need object count");
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                //Obrada odgovora
                //Response
                Byte[] responseData = new Byte[1024];
                string response = "";
                Int32 bytess = stream.Read(responseData, 0, responseData.Length);
                response = System.Text.Encoding.ASCII.GetString(responseData, 0, bytess);

                //Parsiranje odgovora u int vrednost
                numObjects = Int32.Parse(response);

                //Zatvaranje konekcije
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        private void startReporting()
        {
            //Na radnom vreme posalji izmenu vrednosti nekog random objekta i nastavi da to radis u rekurziji
            int waitTime = r.Next(1000, 5000);
            Task.Delay(waitTime).ContinueWith(_ =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    //Slanje izmene stanja nekog objekta
                    sendReport();
                    //Upis u text box, radi lakse provere
                    textBox.Text = "Entity_" + objectNum + " changed state to: " + value.ToString() + "\n" + textBox.Text;
                    //Pocni proces ispocetka
                    startReporting();
                });
            });
        }

        private void sendReport()
        {
            try
            {
                //Slanje nove vrednosti objekta
                //Request
                Int32 port = 25675;
                TcpClient client = new TcpClient("localhost", port);
                int rInt = r.Next(0, numObjects); //Brojimo od nule, maxValue nije ukljucen u range
                objectNum = rInt;
                //Uzimaju se nasumicne i realne vrednosti
                if (ProjectTopics.SelectedIndex == -1)
                {
                    value = 0;
                }
                else if (ProjectTopics.SelectedValue.ToString().Equals("T1"))
                {
                    value = r.Next(0, 23); 
                }
                else if (ProjectTopics.SelectedValue.ToString().Equals("T2"))
                {
                    value = GetRandomNumber(0.01, 5.50);
                }
                else if(ProjectTopics.SelectedValue.ToString().Equals("T3"))
                {
                    value = r.Next(3000, 21000);
                }
                else if (ProjectTopics.SelectedValue.ToString().Equals("T4"))
                {
                    value = r.Next(0, 10);
                }
                else if (ProjectTopics.SelectedValue.ToString().Equals("T5"))
                {
                    value = r.Next(520, 855);
                }
                else if (ProjectTopics.SelectedValue.ToString().Equals("T6"))
                {
                    value = r.Next(0, 100);
                }
                else if (ProjectTopics.SelectedValue.ToString().Equals("T7"))
                {
                    value = r.Next(150, 450);
                }
                Byte[] data = System.Text.Encoding.ASCII.GetBytes("Entitet_" + rInt + ":" + value);
                NetworkStream stream = client.GetStream();
                stream.Write(data, 0, data.Length);

                //Zatvaranje konekcije
                stream.Close();
                client.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(Application.ResourceAssembly.Location);
            Application.Current.Shutdown();
        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            RestartButton.IsEnabled = true;
            //Proveri broj objekata pod monitoringom
            askForCount();
            //Pocni prijavljivanje novih vrednosti za objekte
            startReporting();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
