using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace wochenuebersicht_2
{
   public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Wochenansicht>KW_Week{ get; set; }

        public ICommand Open_KW { get; set; }

        public int Selected_KW_Idx { get; set; }

        public MainViewModel()
        {
            KW_Week = new ObservableCollection<Wochenansicht>(Enumerable.Range(1, 52).Select(SeedKw));
            Open_KW = new RelayCommand(Open_Day, () => true);

        }

        private Wochenansicht SeedKw(int seed)
        {
            return new Wochenansicht
            {
                KW = seed,
                Woche = "Woche",
            };
        }


        private void Open_Day()
        {

            Wochenansicht e = KW_Week[Selected_KW_Idx];
            string pstring = JsonConvert.SerializeObject(e);
            Debug.WriteLine("Hallo");
            Debug.WriteLine(pstring);
          

            DayView dayWindow = new DayView();
            
        }
    }
}