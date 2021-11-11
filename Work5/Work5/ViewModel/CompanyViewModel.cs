using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Work5.Model;

namespace Work5.ViewModel
{
    class CompanyViewModel
    {
        //коллекция класса Company, которая хранит поля данного класса
        public ObservableCollection<Company> ListCompany { get; set; } = new ObservableCollection<Company>();
        //Заполнение полей данного класса(можно сколько угодно)
        public CompanyViewModel()
        {
            this.ListCompany.Add(new Company
            {
                ID = 1,
                PersonID = 1,
                OrgLegFormID = 1,
                OrgRegistrationID = 1,
                NameFull = "Виктор Иванов",
                NameShort = "Иванов",
                NumberReg = 5955364,
                DateReg = new DateTime(2000, 05, 10)
            });
        }
        //Нужно для корректного добавления нового ID 

        public int MaxId()
        {
            int max = 0;
            foreach (var a in this.ListCompany)
            {
                if (max < a.ID)
                {
                    max = a.ID;
                };
            }
            return max;
        }

    }
}
