using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Work5.Model;

namespace Work5.Helper
{
    // Нужно для корректного отображения ID(В данном случае не используется)

    public class FindReg
    {
        int id;
        public FindReg(int id)
        {
            this.id = id;
        }
        public bool RegPredicate(OrgRegistration reg)
        {
            return reg.ID == id;
        }
    }
}
