using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work5.Model;

namespace Work5.Helper
{
    // Нужно для корректного отображения ID(В данном случае не используется)

    public class FindPerson
    {
        int id;
        public FindPerson(int id)
        {
            this.id = id;
        }
        public bool PersonPredicate(Person pers)
        {
            return pers.ID == id;
        }
    }
}
