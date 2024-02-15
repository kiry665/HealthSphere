using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSphere
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
    }

    public class Patient
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patronymic { get; set; }
        public string sex { get; set; }
        public DateOnly date { get; set; }

    }
}
