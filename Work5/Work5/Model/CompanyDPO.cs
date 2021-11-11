using System;
using Work5.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work5.Model
{
    // Отличие от Company в формате ID других классов(здесь они string), для корректного вывода и использования
    public class CompanyDPO
    {
        public int ID { get; set; }
        public long PersonID { get; set; }
        public string OrgRegistrationID { get; set; }
        public string OrgLegFormID { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public int NumberReg { get; set; }
        public DateTime DateReg { get; set; }
        public CompanyDPO() { }
        public CompanyDPO(int id, long person, string orgReg, string orgLeg, string nameF, string nameS, int number, DateTime date)
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
        public CompanyDPO CopyFromCompany(Company comp)
        {
            CompanyDPO compDPO = new CompanyDPO();

            OrgRegViewModel vmReg = new OrgRegViewModel();
            string regStr = string.Empty;
            foreach (var reg in vmReg.ListReg)
            {
                if (reg.ID == comp.OrgRegistrationID)
                {
                    regStr = reg.NameShort;
                    break;
                }
            }

            PersonViewModel vmPerson = new PersonViewModel();
            long personLong = 0;
            foreach (var person in vmPerson.ListPerson)
            {
                if (person.ID == comp.PersonID)
                {
                    personLong = person.Shifer;
                    break;
                }
            }

            OrgLegViewModel vmLeg = new OrgLegViewModel();
            string legStr = string.Empty;
            foreach (var leg in vmLeg.ListLeg)
            {
                if (leg.ID == comp.OrgLegFormID)
                {
                    legStr = leg.NameShort;
                    break;
                }
            }

            if ((regStr != string.Empty) && (legStr != string.Empty) && (personLong != 0))
            {
                compDPO.ID = comp.ID;
                compDPO.OrgRegistrationID = regStr;
                compDPO.PersonID = personLong;
                compDPO.OrgLegFormID = legStr;
                compDPO.NameFull = comp.NameFull;
                compDPO.NameShort = comp.NameShort;
                compDPO.NumberReg = comp.NumberReg;
                compDPO.DateReg = comp.DateReg;
            }
            return compDPO;
        }
    }
}
