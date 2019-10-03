using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int huzasokSzama = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowNewCard_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("ShowNewCard has clicked.");

            // kell egy hatlapos kártyacsomag
            //var card1 = FontAwesome.WPF.FontAwesomeIcon.Car;
            //var card2 = FontAwesome.WPF.FontAwesomeIcon.SnowflakeOutline;
            //var card3 = FontAwesome.WPF.FontAwesomeIcon.Briefcase;
            //var card4 = FontAwesome.WPF.FontAwesomeIcon.Book;
            //var card5 = FontAwesome.WPF.FontAwesomeIcon.Male;
            //var card6 = FontAwesome.WPF.FontAwesomeIcon.Female;

            var kartyak = new FontAwesome.WPF.FontAwesomeIcon[6] {
                    FontAwesome.WPF.FontAwesomeIcon.Car,
                    FontAwesome.WPF.FontAwesomeIcon.SnowflakeOutline,
                    FontAwesome.WPF.FontAwesomeIcon.Briefcase,
                    FontAwesome.WPF.FontAwesomeIcon.Book,
                    FontAwesome.WPF.FontAwesomeIcon.Male,
                    FontAwesome.WPF.FontAwesomeIcon.Female
            };

            // dobunk dobókockával
            var dobokocka = new Random();
            var dobas = dobokocka.Next(6);

            //System.Diagnostics.Debug.WriteLine(dobas);

            // amelyik kártyát kijelöli a kocka, megjelenítjük a jobboldali kártyahelyen
            huzasokSzama++;
            if (huzasokSzama == 2)
            {
                btnAlmost.IsEnabled = true;
                btnNo.IsEnabled = true;
                btnYes.IsEnabled = true;
            }
            CardRight.Icon = kartyak[dobas];

        }
    }
}
