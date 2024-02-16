using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
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
        [NotMapped]
        [DisplayName(" ")]
        public bool isSelect { get; set; } = false;

        [DisplayName("№")]
        public int id { get; set; }

        [DisplayName("Фамилия")]
        public string last_name { get; set; }

        [DisplayName("Имя")]
        public string first_name { get; set; }

        [DisplayName("Отчество")]
        public string patronymic { get; set; }

        [DisplayName("Пол")]
        public string sex { get; set; }

        [DisplayName("Дата рождения")]
        public DateOnly date { get; set; }
        
    }
}
