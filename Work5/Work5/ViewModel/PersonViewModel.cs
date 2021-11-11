using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Work5.Model;

namespace Work5.ViewModel
{
    public class PersonViewModel
    {
        //Коллекция класса Person, которая содержит поля данного класса
        public ObservableCollection<Person> ListPerson { get; set; } = new ObservableCollection<Person>();
        //Заполнение полей данного класса(можно сколько угодно)

        public PersonViewModel()
        {
            this.ListPerson.Add(new Person
            {
                ID = 1,
                Shifer = 61546,
                Inn = 5659856523,
                Type = "Покупатель",
                DateReg = new DateTime(1983, 05, 10)

            });
            this.ListPerson.Add(new Person
            {
                ID = 2,
                Shifer = 56456,
                Inn = 68491495959,
                Type = "Услуга нотариуса",
                DateReg = new DateTime(1999, 09, 09)
            });
        }
        //Нужно для корректного добавления нового ID 
        public int MaxId()
        {
            int max = 0;
            foreach (var p in this.ListPerson)
            {
                if (max < p.ID)
                {
                    max = p.ID;
                };
            }
            return max;
        }
    }
}
