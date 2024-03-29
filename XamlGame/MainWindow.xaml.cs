﻿using System;
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
using FontAwesome.WPF;
using System.Diagnostics;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace XamlGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int huzasokSzama = 0;
        Random dobokocka = new Random();
        FontAwesomeIcon[] kartyak = new FontAwesomeIcon[6];
 
        FontAwesomeIcon elozoKartya = FontAwesomeIcon.None;

        TimeSpan visszalevoIdo;
        DispatcherTimer ingaora;

        public MainWindow()
        {
            InitializeComponent();

            kartyak[0] = FontAwesomeIcon.Car;
            kartyak[1] = FontAwesomeIcon.SnowflakeOutline;
            kartyak[2] = FontAwesomeIcon.Briefcase;
            kartyak[3] = FontAwesomeIcon.Book;
            kartyak[4] = FontAwesomeIcon.Male;
            kartyak[5] = FontAwesomeIcon.Female;

            // Felparaméterezzük az ingaórákat:
            // másodpercenként adjon egy eseményt
            ingaora = new DispatcherTimer(
                    TimeSpan.FromSeconds(1)         // egy másodpercenként kérem az eseményt
                    ,DispatcherPriority.Normal      // semmi különlegest nem kérek, néhány századmásodperc nem számít
                    ,IngaoraUt                    // ezt hívjuk minden alkalommal
                    ,Application.Current.Dispatcher // ennek a segítségével tudunk a felületre adatot küldeni
                ); ;
            // mivel azonnal elindul meg kell állítani
            ingaora.Stop();
        }

        /// <summary>
        /// Ezt hívja az ingaóra minden alkalommal amikor üt
        /// </summary>
        /// <returns></returns>
        private void IngaoraUt(object sender, EventArgs e)
        {
            visszalevoIdo = visszalevoIdo.Add(TimeSpan.FromSeconds(-1));
            lblCountDown.Content = $"Visszaszámlálás: {visszalevoIdo.ToString(@"mm\:ss")}";

            if (visszalevoIdo == TimeSpan.Zero)
            {
                JatekVege();
            }

        }

        private void JatekVege()
        {
            throw new NotImplementedException();
        }

        private void ShowNewCard_Click(object sender, RoutedEventArgs e)
        {
            UjKartyaHuzasa();

        }

        /// <summary>
        /// Egy kocka dobása és új kártya húzása a dobás alapján
        /// </summary>
        private void UjKartyaHuzasa()
        {
            //System.Diagnostics.Debug.WriteLine("ShowNewCard has clicked.");

            // kell egy hatlapos kártyacsomag
            //var card1 = FontAwesome.WPF.FontAwesomeIcon.Car;
            //var card2 = FontAwesome.WPF.FontAwesomeIcon.SnowflakeOutline;
            //var card3 = FontAwesome.WPF.FontAwesomeIcon.Briefcase;
            //var card4 = FontAwesome.WPF.FontAwesomeIcon.Book;
            //var card5 = FontAwesome.WPF.FontAwesomeIcon.Male;
            //var card6 = FontAwesome.WPF.FontAwesomeIcon.Female;

            

            // dobunk dobókockával
            
            var dobas = dobokocka.Next(6);

            //System.Diagnostics.Debug.WriteLine(dobas);

            // amelyik kártyát kijelöli a kocka, megjelenítjük a jobboldali kártyahelyen
            huzasokSzama++;
            if (huzasokSzama == 2)
            {
                // Egyelőre nem kell
                //btnAlmost.IsEnabled = true;
                btnNo.IsEnabled = true;
                btnYes.IsEnabled = true;
                ShowNewCard.IsEnabled = false;

                JatekKezdete();
            }

            elozoKartya = CardRight.Icon;

            // eltüntetni az előző kártyát

            var animationOut = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(100));
            CardRight.BeginAnimation(OpacityProperty, animationOut);
            
            CardRight.Icon = kartyak[dobas];

            // megjeleníteni az új kártyát
            var animationIn = new DoubleAnimation(0, 1, TimeSpan.FromMilliseconds(100));
            CardRight.BeginAnimation(OpacityProperty, animationIn);
        }

        private void JatekKezdete()
        {
            visszalevoIdo = TimeSpan.FromSeconds(55);
            ingaora.Start();
        }

        private void btnAlmost_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            YesAnswer();
        }

        private void YesAnswer()
        {
            if (elozoKartya == CardRight.Icon)
            {

                HelyesValasz();
            }
            else
            {
                HelytelenValasz();
            }
            UjKartyaHuzasa();
        }

        private void HelytelenValasz()
        {
            System.Diagnostics.Debug.WriteLine("Helytelen");
            CardLeft.Foreground = Brushes.Red;
            CardLeft.Icon = FontAwesomeIcon.Times;
            AnswerSlowAnimation();
        }

        private void HelyesValasz()
        {
            System.Diagnostics.Debug.WriteLine("Helyes");
            CardLeft.Foreground = Brushes.Green;
            CardLeft.Icon = FontAwesomeIcon.Check;
            AnswerSlowAnimation();
        }

        /// <summary>
        /// Animáció segítségével az Opacity tulajdonságot a CardLeft-nek 1-ről 0-ra állítjuk
        /// </summary>
        private void AnswerSlowAnimation()
        {
            var animation = new DoubleAnimation(1, 0, TimeSpan.FromMilliseconds(1000));
            CardLeft.BeginAnimation(OpacityProperty, animation);
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            NoAnswer();
        }

        private void NoAnswer()
        {
            if (elozoKartya == CardRight.Icon)
            {
                HelytelenValasz();
            }
            else
            {
                HelyesValasz();
            }
            UjKartyaHuzasa();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Debug.WriteLine(e.Key);
            if (huzasokSzama < 2)
            {
                // még nincs két kártya a gombok nem élnek
                return;
            }

            if (e.Key == Key.Left)
            {
                // Nem gomb
                NoAnswer();
            }
            else if (e.Key == Key.Right)
            {
                // Igen gomb
                YesAnswer();
            }
            else if (e.Key == Key.Down)
            {
                // Hasonló gomb
            }
        }
    }
}
