using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NetworkService.ViewModel
{
    public class NetworkDisplayViewModel : MyBinding
    {
        public ObservableCollection<Meter> meters;
        public ObservableCollection<MetersGrouped> groupedMeters;

        public NetworkDisplayViewModel()
        {
            Meters = NetworkEntitiesViewModel.meters;
            groupedMeters = new ObservableCollection<MetersGrouped>();
            groupedMeters.Add(new MetersGrouped("Smart"));
            groupedMeters.Add(new MetersGrouped("Interval"));
            for(int i=0; i<Meters.Count; i++)
            {
                if(Meters[i].TypeOfMeter == MeterType.SMART)
                {
                    groupedMeters[0].Meters.Add(Meters[i]);
                }
                else
                {
                    groupedMeters[1].Meters.Add(Meters[i]);
                }
            }
        }

        public void RemoveMeter(Meter meter)
        {
            foreach (var group in GroupedMeters)
            {
                if (group.Meters.Contains(meter))
                {
                    group.Meters.Remove(meter);
                    break;
                }
            }
        }

        public void AddMeter(Meter meter)
        {
            Console.WriteLine("AddMeter is called and running");
            var group = GroupedMeters.FirstOrDefault(g => g.MType == meter.TypeOfMeter.ToString());
            group?.Meters.Add(meter);
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
        public ObservableCollection<MetersGrouped> GroupedMeters
        {
            get { return groupedMeters; }
            set
            {
                if (groupedMeters != value)
                {
                    groupedMeters = value;
                    OnPropertyChanged(nameof(GroupedMeters));
                }
            }

        }
    }
}
