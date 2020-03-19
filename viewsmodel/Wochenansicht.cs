namespace wochenuebersicht_2
{
    public class Wochenansicht
    {

        public string Week { get; set; }
        public string Day { get;  set; }
        public int Week_NR { get; internal set; }
        public Daily_View Week_Day { get; set;  }    

    };
}