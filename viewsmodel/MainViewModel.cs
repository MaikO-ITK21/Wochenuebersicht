using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace wochenuebersicht_2
{
   public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Wochenansicht>KW_Week{ get; set; }

        public MainViewModel()
        {
            KW_Week = new ObservableCollection<Wochenansicht>(Enumerable.Range(1, 52).Select(SeedKw));

        }

        private Wochenansicht SeedKw(int seed)
        {
            return new Wochenansicht
            {
                KW = seed,
                Woche = "Woche",
            };
        }
    }
}