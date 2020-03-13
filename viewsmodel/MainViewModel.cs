using GalaSoft.MvvmLight.CommandWpf;
using System;
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

        public ObservableCollection<DayViewList> DayList { get; set; }


        public ICommand Add_daily_task { get; set; }

        public ICommand Show_Daily_Task { get; set; }

        public int Selected_KW_Idx { get; set; }

        public int Selected_Day_Idx { get; set; }

        public string NewDailyTask { get; set; }

       

        public int Selected_KW => Selected_KW_Idx + 1;
        public string SL_KW_TXT => String.Format("Woche {0}", Selected_KW);

        public int Selected_Day => Selected_Day_Idx + 1;

        // ToDo Wochentag anzeigen => Aufgaben 

        public string ShowDailyTask => Day_Name[Selected_Day];






        public MainViewModel()
        {
            KW_Week = new ObservableCollection<Wochenansicht>();
            DayList = new ObservableCollection<DayViewList>();
            Add_daily_task = new RelayCommand(Open_day, () => true);
            Show_Daily_Task = new RelayCommand(ShowTask, () => true);

            CreatWeeks();
            CreatDay();
          
            // OUTPUT TEST CONSOLE 
            ConsolOutput();

        }

        /// <summary>
        ///  make a weekly list for the year (Range 1 => 52)
        /// </summary>
        public void CreatWeeks()
        {
            IEnumerable<int> weekRange = Enumerable.Range(1, 52);

            foreach (int kw_num in weekRange)
            {
                KW_Week.Add(new Wochenansicht() { Woche = " Woche " + kw_num });
            }
        }

        /// <summary>
        ///      Daily list list for the year (Range 0 => 5)
        /// </summary>
        public void CreatDay()
        {
            IEnumerable<int> dayRange = Enumerable.Range(1, 5);


            foreach (int range in dayRange)
            {
                DayList.Add(new DayViewList() { WeekDay = Day_Name[range] });
            }
        }




        readonly IDictionary<int, string> Day_Name = new Dictionary<int, string>()
        {
            { 1, "Montag" },
            {2, "Dienstag" },
            {3, "Mittwoch" },
            {4, "Donnerstag" },
            {5, "Freitag" },

        };




        // ToDo Binding Week and WeekDay
        // ToTo Binding WeekDay and Task
        // Output Current Week
        // ToDo Output daily task
         

          private void ShowTask ()
         {

         }
       
        private void Open_day()
        {



            ConsolOutput();
        }

     


          // OUTPUT TEST CONSOLE 
        private void ConsolOutput ()
        {
            Debug.WriteLine("----TEST---");
            Debug.WriteLine(SL_KW_TXT);
            Debug.WriteLine(Selected_Day_Idx);
           // Debug.WriteLine(SL_Day_TXT);
            Debug.Write(NewDailyTask);

            Debug.WriteLine(Day_Name[Selected_Day]);


            Debug.WriteLine(ShowDailyTask);

        }
    }
}