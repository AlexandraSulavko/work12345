using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work5.Model
{
    public class Person
    {
        // Класс Person, который хранит поля, данные по заданию
        public int ID { get; set; }
        public long Shifer { get; set; }
        public long Inn { get; set; }
        public string Type { get; set; }
        public DateTime DateReg { get; set; }
        public Person() { }
        //Конструктор для дальнейшего использования этих полей
        public Person(int id, long shifer, long inn, string type, DateTime date)
        {
            this.ID = id;
            this.Shifer = shifer;
            this.Inn = inn;
            this.Type = type;
            this.DateReg = date;
        }
        // клон для тестирования(в данном случае не используется)
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }
    }
}
