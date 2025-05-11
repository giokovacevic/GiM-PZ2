using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkService.Model
{   
    public class Meter : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private MeterType typeOfMeter;
        private double measure;
        public bool isSelected;
        private string imageUrl;

        public Meter(int id, string name, MeterType typeOfMeter, double measure)
        {
            Id = id;
            Name = name;
            TypeOfMeter = typeOfMeter;
            Measure = measure;
            ImageUrl = TypeOfMeter.ImageUrl;
            IsSelected = false;
        }

        public int Id
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public MeterType TypeOfMeter
        {
            get { return typeOfMeter; }
            set
            {
                if (typeOfMeter != value)
                {
                    typeOfMeter = value;
                    OnPropertyChanged(nameof(TypeOfMeter));
                }
            }
        }

        public string TypeOfMeterString
        {
            get { return typeOfMeter.StringValue; }
            
        }
        

        public double Measure
        {
            get { return measure; }
            set
            {
                if (measure != value)
                {
                   measure = value;
                    OnPropertyChanged(nameof(Measure));
                }
            }
        }

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    OnPropertyChanged(nameof(isSelected));
                }
            }
        }
        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                if (imageUrl != value)
                {
                    imageUrl = value;
                    OnPropertyChanged(nameof(ImageUrl));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
