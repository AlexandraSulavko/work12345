using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Work5.Model;
using Work5.ViewModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Work5.View
{
    // Создаем необходимые экземпляры для дальнейшей работы. В Public WindowPerson() используем их для корректного вывода на форму полей

    public partial class WindowPerson : Window
    {
        PersonViewModel vmPerson = new PersonViewModel();
        public WindowPerson()
        {
            InitializeComponent();
            lvPerson.ItemsSource = vmPerson.ListPerson;
        }
        // Кнопка добавить
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPerson wnPerson = new WindowNewPerson
            {
                Title = "Новый клиент",
                Owner = this
            };
            int maxIdPerson = vmPerson.MaxId() + 1;
            Person person = new Person
            {
                ID = maxIdPerson
            };
            wnPerson.DataContext = person;
            if (wnPerson.ShowDialog() == true)
            {
                vmPerson.ListPerson.Add(person);
            }
        }
        // Кнопка редактировать
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPerson wnPerson = new WindowNewPerson
            {
                Title = "Редактирование",
                Owner = this
            };
            Person person = lvPerson.SelectedItem as Person;
            if (person != null)
            {
                Person tempPerson = person.ShallowCopy();
                wnPerson.DataContext = tempPerson;
                if (wnPerson.ShowDialog() == true)
                {
                    person.Shifer = tempPerson.Shifer;
                    person.Inn = tempPerson.Inn;
                    person.Type = tempPerson.Type;
                    person.DateReg = tempPerson.DateReg;

                    lvPerson.ItemsSource = null;
                    lvPerson.ItemsSource = vmPerson.ListPerson;
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
            Person person = (Person)lvPerson.SelectedItem;
            if (person != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить " +
                person.Shifer, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    vmPerson.ListPerson.Remove(person);
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
