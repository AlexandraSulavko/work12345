using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work5.Model
{
    public class OrgLegForm
    {
        // Класс OrgLegForm, хранит поля данные по заданию 
        public int ID { get; set; }
        public string NameFull { get; set; }
        public string NameShort { get; set; }
        public OrgLegForm() { }
        // Конструктор для использования полей
        public OrgLegForm(int id, string nameF, string nameS)
        {
            this.ID = id;
            this.NameFull = nameF;
            this.NameShort = nameS;
        }
  // Клон для тестов(в данном случае не используется)
        public OrgLegForm ShallowCopy()
        {
            return (OrgLegForm)this.MemberwiseClone();
        }
    }
}
