using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkService.ViewModel
{
    public class MainWindowViewModel : MyBinding
    {
        private NetworkEntitiesViewModel networkEntitiesViewModel;
        private NetworkDisplayViewModel networkDisplayViewModel;
        private MeasurementGraphViewModel measurementGraphViewModel;
        private MyBinding currentViewModel;
        private MyBinding prevViewModel;
        private string appTitle;
        public static ObservableCollection<Meter> meters;

        public MyICommand<string> NavCommand { get; private set; }
        public MyICommand<Window> ExitCommand { get; private set; }
        public MyICommand PrevCommand { get; private set; }


        private int count = 0; // Inicijalna vrednost broja objekata u sistemu
                                // ######### ZAMENITI stvarnim brojem elemenata
                                //           zavisno od broja entiteta u listi

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
            ExitCommand = new MyICommand<Window>(CloseWindow);
            PrevCommand = new MyICommand(PrevWindow);

            meters = LoadData();
            networkEntitiesViewModel = new NetworkEntitiesViewModel();
            CurrentViewModel = networkEntitiesViewModel;
            prevViewModel = CurrentViewModel;

            AppTitle = "Network Entities View";

            networkDisplayViewModel = new NetworkDisplayViewModel();
            measurementGraphViewModel = new MeasurementGraphViewModel();

            using (var fileStream = new FileStream("log.txt", FileMode.Create)) { }

            createListener(); //Povezivanje sa serverskom aplikacijom
        }

        public ObservableCollection<Meter> LoadData()
        {
            ObservableCollection<Meter> list = new ObservableCollection<Meter>();
          
            if (File.Exists("data.txt"))
            {
                // Read entire text file content in one string
                string[] lines = File.ReadAllLines("data.txt");
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                    string[] components = line.Split(',');
                    list.Add(new Meter(Int32.Parse(components[0]), components[1], MeterType.generateTypeOfMeter(components[2]), Double.Parse(components[3])));
                    count++;
                }

            }
            return list;

        }

        private void OnNav(string destination)
        {
            if(destination.Equals("nemv"))

            {
                prevViewModel = CurrentViewModel;
                CurrentViewModel = networkEntitiesViewModel;
                AppTitle = "Network Entities View";
            }else if(destination.Equals("ndmv"))
            {
                prevViewModel = CurrentViewModel;
                CurrentViewModel = networkDisplayViewModel;
                AppTitle = "Network Display View";
            }
            else if(destination.Equals("mgmv"))
            {
                prevViewModel = CurrentViewModel;
                CurrentViewModel = measurementGraphViewModel;
                AppTitle = "Measurement Graph View";
            }
        
        }
        private void PrevWindow()
        {
            CurrentViewModel = prevViewModel;
        }

        private void CloseWindow(Window window)
        {
            window.Close();
        }

        private void createListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25675);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        //Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        //Primljena poruka je sacuvana u incomming stringu
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        //Ukoliko je primljena poruka pitanje koliko objekata ima u sistemu -> odgovor
                        if (incomming.Equals("Need object count"))
                        {
                            //Response
                            /* Umesto sto se ovde salje count.ToString(), potrebno je poslati 
                             * duzinu liste koja sadrzi sve objekte pod monitoringom, odnosno
                             * njihov ukupan broj (NE BROJATI OD NULE, VEC POSLATI UKUPAN BROJ)
                             * */
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(count.ToString());
                            stream.Write(data, 0, data.Length);
                        }
                        else
                        {
                            //U suprotnom, server je poslao promenu stanja nekog objekta u sistemu
                            //Console.WriteLine(incomming); //Na primer: "Entitet_1:272"

                            string[] message = incomming.Split(':');

                            double newMeasure = Math.Round(Double.Parse(message[1]), 2);
                            Console.WriteLine(newMeasure);
                            int index = Int32.Parse(message[0].Split('_')[1]);
                            networkEntitiesViewModel.UpdateMeterMeasure(index, newMeasure);

                            using (var streamWriter = new StreamWriter("log.txt", append: true))
                            {
                                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); 
                                 streamWriter.WriteLine(index + "," + newMeasure + "," + date);
                            }


                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

        public MyBinding CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }

            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }

        public string AppTitle
        {
            get { return appTitle; }
            set
            {
                if (appTitle != value)
                {
                    appTitle = value;
                    OnPropertyChanged(nameof(AppTitle));
                }
            }
        }

        public ObservableCollection<Meter> Meters
        {
            get { return meters; }
            set
            {
                if (meters != value)
                {
                    meters = value;
                    OnPropertyChanged(nameof(Meters));
                }
            }

        }


    }
}
