using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Work5.View;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Work5
{
    //Класс формы основное меню, на каждом событии есть метод Show, благодаря которому при нажатии на кнопки меню будет открываться новая форма
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Company_OnClick(object sender, RoutedEventArgs e)
        {
            WindowCompany wCompany = new WindowCompany();
            wCompany.Show();
        }
        private void Reg_OnClick(object sender, RoutedEventArgs e)
        {
            WindowReg wReg = new WindowReg();
            wReg.Show();
        }
        private void Person_OnClick(object sender, RoutedEventArgs e)
        {
            WindowPerson wPerson = new WindowPerson();
            wPerson.Show();
        }
        private void Leg_OnClick(object sender, RoutedEventArgs e)
        {
            WindowLeg wLeg = new WindowLeg();
            wLeg.Show();
        }
        public static int IdPerson { get; set; }
        public static int IdCompany { get; set; }
    }
}
