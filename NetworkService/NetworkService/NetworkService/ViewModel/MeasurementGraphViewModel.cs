using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.ViewModel
{                   
    public class MeasurementGraphViewModel : MyBinding
    {
        public ObservableCollection<Meter> meters;

        public MeasurementGraphViewModel()
        {
            Meters = NetworkEntitiesViewModel.meters;
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
