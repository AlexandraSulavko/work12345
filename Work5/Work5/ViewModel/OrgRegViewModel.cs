using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Work5.Model;

namespace Work5.ViewModel
{
    public class OrgRegViewModel
        //Коллекция класса OrgRegistration, которая содержит поля данного класса
    {
        public ObservableCollection<OrgRegistration> ListReg { get; set; } = new ObservableCollection<OrgRegistration>();
        public OrgRegViewModel()
        //Заполнение полей данного класса(можно сколько угодно)

        {
            this.ListReg.Add(new OrgRegistration
            {
                ID = 1,
                NameFull = "Минестерство России по налогам и сборам",
                NameShort = "МинРФ по налогам и сборам"
            });
        }
    }
}
