using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work5.Model
{
    public class OrgRegistration
    {
        //Класс OrgRegistration, который хранит поля, данные по заданию
        public int ID { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public OrgRegistration() { }
        // Конструктор, чтобы использоваться поля
        public OrgRegistration(int id, string nameF, string nameS)
        {
            this.ID = id;
            this.NameFull = nameF;
            this.NameShort = nameS;
        }
        // клон для тестов( в данном случае не используется)

        public OrgRegistration ShallowCopy()
        {
            return (OrgRegistration)this.MemberwiseClone();
        }
    }
}
