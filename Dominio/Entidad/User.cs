using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidad
{
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set;}

        public string avatar { get; set; }

    }
}
