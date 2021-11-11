using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Work5.Model;

namespace Work5.ViewModel
{
    class OrgLegViewModel
    {
        //Коллекция класса OrgLegForm, которая содержит поля данного класса
        public ObservableCollection<OrgLegForm> ListLeg { get; set; } = new ObservableCollection<OrgLegForm>();
        //Заполнение полей данного класса(можно сколько угодно)

        public OrgLegViewModel()
        {
            this.ListLeg.Add(new OrgLegForm
            {
                ID = 1,
                NameFull = "Хозяйственные товарищества",
                NameShort = "1 10 00"
            });
            this.ListLeg.Add(new OrgLegForm
            {
                ID = 2,
                NameFull = "Хозяйственные общества",
                NameShort = "1 20 00"
            });
            this.ListLeg.Add(new OrgLegForm
            {
                ID = 3,
                NameFull = "Акционерные общества",
                NameShort = "1 22 00"
            });
        }
        //Нужно для корректного добавления нового ID 

        public int MaxId()
        {
            int max = 0;
            foreach (var l in this.ListLeg)
            {
                if (max < l.ID)
                {
                    max = l.ID;
                };
            }
            return max;
        }
    }
}
