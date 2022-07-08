using NetCore2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore2.Models
{
    public class User: IUsers
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string printFormatName()
        {
            return Name.ToUpper();
        }

        public override String ToString()
        {
            return $@"El usuario con el Id {Id} se llama { printFormatName() }";
        }

    }
}
