using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Work5.ViewModel;
using Work5.Model;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Work5.View
{
    // Создаем необходимые экземпляры для дальнейшей работы. В Public WindowLeg() используем их для корректного вывода на форму полей

    public partial class WindowLeg : Window
    {
        OrgLegViewModel vmLeg = new OrgLegViewModel();
        public WindowLeg()
        {
            InitializeComponent();
            lvLeg.ItemsSource = vmLeg.ListLeg;
        }
        //Кнопка добавить
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewLeg wnLeg = new WindowNewLeg
            {
                Title = "Новая форма",
                Owner = this
            };
            int maxIdLeg = vmLeg.MaxId() + 1;
            OrgLegForm leg = new OrgLegForm
            {
                ID = maxIdLeg
            };
            wnLeg.DataContext = leg;
            if (wnLeg.ShowDialog() == true)
            {
                vmLeg.ListLeg.Add(leg);
            }
        }
        //Кнопка редактировать
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewLeg wnLeg = new WindowNewLeg
            {
                Title = "Редактирование",
                Owner = this
            };
            OrgLegForm leg = lvLeg.SelectedItem as OrgLegForm;
            if (leg != null)
            {
                OrgLegForm tempLeg = leg.ShallowCopy();
                wnLeg.DataContext = tempLeg;
                if (wnLeg.ShowDialog() == true)
                {
                    leg.NameFull = tempLeg.NameFull;
                    leg.NameShort = tempLeg.NameShort;

                    lvLeg.ItemsSource = null;
                    lvLeg.ItemsSource = vmLeg.ListLeg;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать поле для редактированния",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        //Кнопка удалить
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            OrgLegForm leg = (OrgLegForm)lvLeg.SelectedItem;
            if (leg != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить " +
                leg.NameShort, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmLeg.ListLeg.Remove(leg);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать поле для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
