using NetworkService.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetworkService.ViewModel
{
    public class NetworkEntitiesViewModel : MyBinding
    {

        public ObservableCollection<string> TypesOfMeter { get; set; }
        public static ObservableCollection<Meter> meters;
        public static ObservableCollection<Meter> helperMeters;

        public MyICommand DeleteCommand { get; private set; }
        public MyICommand AddCommand { get; private set; }
        public MyICommand FilterOnCommand { get; private set; }
        public MyICommand FilterOffCommand { get; private set; }
        public MyICommand CmdCommand { get; private set; }

        private string _id;
        private string _name;
        private string _typeOfMeter;
        private string _measure;

        private string errorMessage;

        private string _filterName;
        private bool _filterSmart;
        private bool _filterInterval;
        private bool _filterOn;


        public NetworkEntitiesViewModel()
        {
            DeleteCommand = new MyICommand(DeleteAll);
            AddCommand = new MyICommand(AddMeter);
            FilterOnCommand = new MyICommand(FilterByName);
            FilterOffCommand = new MyICommand(ClearFilter);  

            TypesOfMeter = new ObservableCollection<string>() { "Smart", "Interval" };

            Meters = MainWindowViewModel.meters; 

            Id = "";
            Name = "";
            Measure = "";
            TypeOfMeter = "";
            ErrorMessage = "";

            FilterName = "";
            FilterSmart = true;
            FilterInterval = false;
            FilterOn = false;


            ClearFilter();
  
        }

 

        public void SaveData()
        {
            using (StreamWriter writer = new StreamWriter("data.txt"))
            {
                foreach (Meter m in Meters)
                {
                    writer.WriteLine(m.Id.ToString()+","+m.Name + "," + m.TypeOfMeter.StringValue + "," + m.Measure.ToString());
                }
            }
        }

        public void DeleteAll()
        {
            int deleted = 0;
            for(int i= HelperMeters.Count - 1; i>=0; i--) 
                {
                    if(HelperMeters[i].IsSelected)
                    {
                    int id = HelperMeters[i].Id;
                    for(int j=0; j<Meters.Count; j++)
                    {
                        if(id == Meters[j].Id)
                        {
                            Meters.RemoveAt(j);
                        }
                    }
                        deleted++;
                }
                }
            if(deleted>0)
            {
                ClearFilter();
                SaveData();
                MessageBox.Show("Succesfully Deleted Entities", "Meter Removal", MessageBoxButton.OK, MessageBoxImage.Information);
            } 
        }
        public void AddMeter()
        {
            ErrorMessage = "";
            if(ValidateFields())
            {
                
               
                double resultMeasure;
                int resultId;
                if (double.TryParse(Measure, out resultMeasure) && int.TryParse(Id, out resultId))
                {
                    Meter newMeter = new Meter(resultId, Name, MeterType.generateTypeOfMeter(TypeOfMeter), resultMeasure);
                    Meters.Add(newMeter);
                    ClearFilter();
                    SaveData();
                    MessageBox.Show("Succesfully Added new Meter Entity", "New Meter", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                

            }
            Console.WriteLine(Name);
        }

        public bool ValidateFields()
        {
            bool validation = true;
            if(Name.Equals(""))
            {
                ErrorMessage += " Field Name can't be Empty.";
                validation = false;
            }
            if (Measure.Equals(""))
            {
                ErrorMessage += " A Field Measure can't be Empty.";
                validation = false;
            }
            else
            {
                double result;
                if (double.TryParse(Measure, out result))
                {
                    Console.WriteLine("Conversion succeeded: " + result);
                    if(result < 0.34 || result > 2.73)
                    {
                        validation = false;
                        ErrorMessage += " Measure has to be in range of [0.34 ~ 2.73].";
                    }
                }
                else
                {
                    validation = false;
                    ErrorMessage += " Invalid input for Measure Field. Has to be decimal number.";
                }
            }
            if(Id.Equals(""))
            {
                ErrorMessage += " A Field ID can't be Empty.";
                validation = false;
            }
            else
            {
                int result;
                if (int.TryParse(Id, out result))
                {
                    for(int i=0; i<Meters.Count; i++)
                    {
                        if(Meters[i].Id == result)
                        {
                            validation = false;
                            ErrorMessage += " Choosen ID already exists.";
                        }
                    }

                }
                else
                {
                    validation = false;
                    ErrorMessage += " Invalid input for ID Field. Has to be an Integer.";
                }
            }
            if (TypeOfMeter.Equals(""))
            {
                ErrorMessage += " A Type needs to be selected from ComboBox.";
                validation = false;
            }
            return validation;
        }

        public void FilterByName()
        {
            FilterOn = true;
            MeterType selectedMeterType = null;
            if (FilterSmart)
            {
                selectedMeterType = MeterType.SMART;
            }
            else if(FilterInterval)
            {
                selectedMeterType = MeterType.INTERVAL;
            }
           
            
            HelperMeters.Clear();
            for (int i=0; i<Meters.Count; i++)
            {
                if(Meters[i].Name.Contains(FilterName) && Meters[i].TypeOfMeter == selectedMeterType)
                {
                    HelperMeters.Add(new Meter(Meters[i].Id, Meters[i].Name, Meters[i].TypeOfMeter, Meters[i].Measure));
                }
            }
        }

        public void ClearFilter()
        {
            FilterOn = false;
            HelperMeters = new ObservableCollection<Meter>();
            for (int i = 0; i < Meters.Count; i++)
            {
                HelperMeters.Add(new Meter(Meters[i].Id, Meters[i].Name, Meters[i].TypeOfMeter, Meters[i].Measure));
            }
            FilterName = "";
        }

        public void UpdateMeterMeasure(int index, double newMeasure)
        {
            for(int i=0; i<Meters.Count; i++)
            {
                if(i == index)
                {
                    Meters[i].Measure = newMeasure;
                    HelperMeters[i].Measure = newMeasure;
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

        public ObservableCollection<Meter> HelperMeters
        {
            get { return helperMeters; }
            set
            {
                if (helperMeters != value)
                {
                    helperMeters = value;
                    OnPropertyChanged(nameof(HelperMeters));
                }
            }

        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }

        }

        public string Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }

        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }

        }

        public string Measure
        {
            get { return _measure; }
            set
            {
                if (_measure != value)
                {
                    _measure = value;
                    OnPropertyChanged(nameof(Measure));
                }
            }

        }

        public string TypeOfMeter
        {
            get { return _typeOfMeter; }
            set
            {
                if (_typeOfMeter != value)
                {
                    _typeOfMeter = value;
                    OnPropertyChanged(nameof(TypeOfMeter));
                }
            }

        }
        public string FilterName
        {
            get { return _filterName; }
            set
            {
                if (_filterName != value)
                {
                    _filterName = value;
                    OnPropertyChanged(nameof(FilterName));
                }
            }

        }
        public bool FilterSmart
        {
            get { return _filterSmart; }
            set
            {
                if (_filterSmart != value)
                {
                    _filterSmart = value;
                    OnPropertyChanged(nameof(FilterSmart));
                }
            }

        }
        public bool FilterInterval
        {
            get { return _filterInterval; }
            set
            {
                if (_filterInterval != value)
                {
                    _filterInterval = value;
                    OnPropertyChanged(nameof(FilterInterval));
                }
            }

        }
        public bool FilterOn
        {
            get { return _filterOn; }
            set
            {
                if (_filterOn != value)
                {
                    _filterOn = value;
                    OnPropertyChanged(nameof(FilterOn));
                }
            }

        }
       
    }
}
