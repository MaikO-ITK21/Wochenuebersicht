using System.ComponentModel;

namespace wochenuebersicht_2
{
     class DayView: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string days { get; set; }


        public DayView()
        {
           
        }

        
    }
}