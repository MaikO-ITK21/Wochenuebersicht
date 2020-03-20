using System;
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

        public ObservableCollection<Wochenansicht> Weeks { get; set; }
        public ObservableCollection<Daily_View> Day { get; set; }

        private string[] dayName = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag" };

        public ICommand Add_daily_task { get; set; }

        public int Selected_KW_Idx { get; set; }

        public int Selected_Day_Idx { get; set; }

        public string NewDailyTask { get; set; }

        public int Selected_KW => Selected_KW_Idx + 1;
        public string SL_KW_TXT => String.Format ( "Woche {0}", Selected_KW );

        public int Selected_Day => Selected_Day_Idx + 1;

        // ToDo Wochentag anzeigen => Aufgaben

        public MainViewModel ( )
        {
            Weeks = new ObservableCollection<Wochenansicht> ( Enumerable.Range ( 1, 53 ).Select ( SeedKW ) );
            Day = new ObservableCollection<Daily_View> ( Enumerable.Range ( 0, 5 ).Select ( SeedDay ) );

            Test ( );
        }

        public void Test ( )
        {
            for ( int i = 1; i < Weeks.Count; i++ )
            {
                for ( int x = 0; x < Day.Count; x++ )
                {
                    Debug.WriteLine ( x );
                }

                Debug.WriteLine ( i );
            }
        }

        private Daily_View SeedDay ( int seed )
        {
            string[] day = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag" };

            return new Daily_View
            {
                DayName = day [ seed ],
            };
        }

        private Wochenansicht SeedKW ( int seed ) => new Wochenansicht
        {
            Week = "Woche",
            Week_NR = seed,
        };
    }
}