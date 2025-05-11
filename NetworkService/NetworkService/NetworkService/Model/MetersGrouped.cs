using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{
    public class MetersGrouped
    {
        public string MType { get; set; }
        public ObservableCollection<Meter> Meters { get; set; }

        public MetersGrouped(string t)
        {
          MType = t;
          Meters = new ObservableCollection<Meter>();
        }
    }
}
