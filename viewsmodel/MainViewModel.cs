using GalaSoft.MvvmLight.CommandWpf;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;

namespace wochenuebersicht_2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Wochenansicht> KW_Week { get; set; }



        // make a weekly list for the year (Range 1 => 52)
        public void CreatWeeks ( )
        {
            IEnumerable<int> weekRange =Enumerable.Range(1,52);

            foreach ( int kw_num in weekRange )
            {
                KW_Week.Add ( new Wochenansicht ( ) { KW = kw_num, Woche = " Woche " + kw_num } );
            }
        }


        // Butten Command to oben Days for Selected Week
        public ICommand Open_KW { get; set; }
        public int Selected_KW_Idx { get; set; }
     
    
        private void Open_Day ( )
        {
            Wochenansicht e = KW_Week[Selected_KW_Idx];
            string pstring = JsonConvert.SerializeObject(e);
            Debug.WriteLine ( "Hallo" );
            Debug.WriteLine ( pstring );

            DayView dayWindow = new DayView();
        }
      
        public MainViewModel ( )
        {
            KW_Week = new ObservableCollection<Wochenansicht> ( );
            CreatWeeks ( );
            Open_KW = new RelayCommand ( Open_Day, ( ) => true );
        }

     

     
    }
}