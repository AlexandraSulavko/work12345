using System;
using Work5.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work5.Model
{
    public class Company
    {
        // Класс Company, который хранит поля данные по заданию( Заметим что тут имеются ID других классов)
        public int ID { get; set; }
        public int PersonID { get; set; }
        public int OrgRegistrationID { get; set; }
        public int OrgLegFormID { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public int NumberReg { get; set; }
        public DateTime DateReg { get; set; }
        public Company() { }
        // Конструктор для использования полей
        public Company(int id, int person, int orgReg, int orgLeg, string nameF, string nameS, int number, DateTime date)
        {
            this.ID = id;
            this.PersonID = person;
            this.OrgRegistrationID = orgReg;
            this.OrgLegFormID = orgLeg;
            this.NameFull = nameF;
            this.NameShort = nameS;
            this.NumberReg = number;
            this.DateReg = date;
        }
        // Поскольку в классе хранится ID другого класса, нужно сверить ID с классом
        public Company CopyFromCompanyDPO(CompanyDPO comp)
        {
            OrgRegViewModel vmReg = new OrgRegViewModel();
            int RegId = 0;
            foreach (var reg in vmReg.ListReg)
            {
                if (reg.NameShort == comp.OrgRegistrationID)
                {
                    RegId = reg.ID;
                    break;
                }
            }
            // Поскольку в классе хранится ID другого класса, нужно сверить ID с классом

            PersonViewModel vmPerson = new PersonViewModel();
            int PersonId = 0;
            foreach (var person in vmPerson.ListPerson)
            {
                if (person.Shifer == comp.PersonID)
                {
                    PersonId = person.ID;
                    break;
                }
            }
            // Поскольку в классе хранится ID другого класса, нужно сверить ID с классом

            OrgLegViewModel vmLeg = new OrgLegViewModel();
            int LegId = 0;
            foreach (var leg in vmLeg.ListLeg)
            {
                if (leg.NameShort == comp.OrgLegFormID)
                {
                    LegId = leg.ID;
                    break;
                }
            }

            if ((RegId != 0) && (PersonId != 0) && (LegId != 0))
            {
                this.ID = comp.ID;
                this.PersonID = PersonId;
                this.OrgLegFormID = LegId;
                this.OrgRegistrationID = RegId;
                this.NameFull = comp.NameFull;
                this.NumberReg = comp.NumberReg;
                this.NameShort = comp.NameShort;
                this.DateReg = comp.DateReg;
            }
            return this;
        }

    }
}
