using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
    // Создаем необходимые экземпляры для дальнейшей работы. В Public WindowReg() используем их для корректного вывода на форму полей

    public partial class WindowReg : Window
    {
        public WindowReg()
        {
            InitializeComponent();
            OrgRegViewModel vmReg = new OrgRegViewModel();
            lvReg.ItemsSource = vmReg.ListReg;
        }
    }
}
