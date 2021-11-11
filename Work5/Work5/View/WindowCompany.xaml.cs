using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Work5.ViewModel;
using Work5.Model;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Work5.View
{
    // Создаем необходимые экземпляры для дальнейшей работы. В Public WindowCompany() используем их для корректного вывода на форму полей
    public partial class WindowCompany : Window
    {
        private CompanyViewModel vmCompany;
        private OrgRegViewModel vmReg;
        private PersonViewModel vmPerson;
        private OrgLegViewModel vmLeg;

        private ObservableCollection<CompanyDPO> compDPO;

        private List<OrgLegForm> legList;
        private List<Person> personList;
        private List<OrgRegistration> regList;
        public WindowCompany()
        {
            InitializeComponent();
            vmCompany = new CompanyViewModel();
            vmReg = new OrgRegViewModel();
            vmPerson = new PersonViewModel();
            vmLeg = new OrgLegViewModel();

            legList = vmLeg.ListLeg.ToList();
            personList = vmPerson.ListPerson.ToList();
            regList = vmReg.ListReg.ToList();

            compDPO = new ObservableCollection<CompanyDPO>();
            foreach (var i in vmCompany.ListCompany)
            {
                CompanyDPO comp = new CompanyDPO();
                comp = comp.CopyFromCompany(i);
                compDPO.Add(comp);
            }
            lvCompany.ItemsSource = compDPO;
        }
        //Кнопка добавить
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCompany wnCompany = new WindowNewCompany
            {
                Title = "Новое физ. лицо",
                Owner = this
            };
            int maxIdCompany = vmCompany.MaxId() + 1;
            CompanyDPO compD = new CompanyDPO
            {
                ID = maxIdCompany
            };
            wnCompany.DataContext = compD;
            wnCompany.CbLeg.ItemsSource = legList;
            wnCompany.CbReg.ItemsSource = regList;
            wnCompany.CbPerson.ItemsSource = personList;
            if (wnCompany.ShowDialog() == true)
            {
                OrgLegForm leg = (OrgLegForm)wnCompany.CbLeg.SelectedValue;
                Person pers = (Person)wnCompany.CbPerson.SelectedValue;
                OrgRegistration reg = (OrgRegistration)wnCompany.CbReg.SelectedValue;

                compD.OrgLegFormID = leg.NameShort;
                compD.OrgRegistrationID = reg.NameShort;
                compD.PersonID = pers.Shifer;

                compDPO.Add(compD);

                Company company = new Company();
                company = company.CopyFromCompanyDPO(compD);
                vmCompany.ListCompany.Add(company);
            }
        }
        // Кнопка удалить
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CompanyDPO compD = (CompanyDPO)lvCompany.SelectedItem;
            if (compD != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные : \n" + compD.NameShort,
                "Предупреждение", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    compDPO.Remove(compD);
                    Company comp = new Company();
                    comp = comp.CopyFromCompanyDPO(compD);
                    vmCompany.ListCompany.Remove(comp);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать данные для удаления",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
