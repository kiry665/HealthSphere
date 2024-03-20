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

        [DisplayName("Фамилия Имя Отчество")]
        public string fio { get; set; }

        [DisplayName("Пол")]
        public string sex { get; set; }

        [DisplayName("Дата рождения")]
        public DateOnly date { get; set; }

        [DisplayName("№ Полиса")]
        public int policy_number { get; set; }
        
    }

    public class Doctor
    {
        [NotMapped]
        [DisplayName(" ")]
        public bool isSelect { get; set; } = false;

        [DisplayName("№")]
        public int id { get; set; }

        [DisplayName("Фамилия Имя Отчество")]
        public string fio { get; set; }

        public int specializationid { get; set; }

        public virtual Specialization specialization { get; set; }
    }

    public class Specialization
    {
        [NotMapped]
        [DisplayName(" ")]
        public bool isSelect { get; set; } = false;

        [DisplayName("№")]
        public int id { get; set; }

        [DisplayName("Название специальности")]
        public string name_speciality { get; set; }
    }

    public class Records
    {
        public int id { get; set; }
        public int patienid { get; set; }
        public DateOnly date { get; set; }
        public TimeOnly time { get; set; }
    }
}
