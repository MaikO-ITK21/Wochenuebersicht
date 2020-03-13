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

        public ICommand Open_Day { get; set; }

        public ICommand SelectedDay { get; set; }

        public int Selected_KW_Idx { get; set; }

        public string NewDailyTask { get; set; }

        public string CurrentWeek { get; set; }

        public int Selected_KW => Selected_KW_Idx + 1;
        public string SL_KW_TXT  => String.Format("Week {0}", Selected_KW);

        public MainViewModel()
        {
            KW_Week = new ObservableCollection<Wochenansicht>();
            DayList = new ObservableCollection<DayViewList>();
            Open_Day = new RelayCommand(Open_day, () => true);

            CreatWeeks();
            CreatDay();
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
            IEnumerable<int> dayRange = Enumerable.Range(0, 5);

            string[] days = { "Montag", "Dienstag", "Mittwoch", "Donnerstag", "Freitag" };

            foreach (int range in dayRange)
            {
                DayList.Add(new DayViewList() { WeekDay = days[range] });
            }
        }

        // ToDo Binding Week and WeekDay
        // ToTo Binding WeekDay and Task
        // Output Current Week
        // ToDo Output daily task


       
        private void Open_day()
        {

            DayViewList  crWeek= new DayViewList
            {
                CurrentWeek = SL_KW_TXT,
            };
            
            Debug.WriteLine("Hallo");
            Wochenansicht e = KW_Week[Selected_KW_Idx];
            Debug.WriteLine(Selected_KW_Idx);
            Debug.WriteLine(SL_KW_TXT);
        }
    }
}