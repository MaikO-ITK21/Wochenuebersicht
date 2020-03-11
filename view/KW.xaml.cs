using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wochenuebersicht_2
{
    /// <summary>
    /// Interaktionslogik für KW.xaml
    /// </summary>
    public partial class KW : Page
    {
        public KW()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
