using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HealthSphere
{
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int level { get; set; }
    }

    public class Patient
    {
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
        [DisplayName("№")]
        public int id { get; set; }

        [DisplayName("Фамилия Имя Отчество")]
        public string fio { get; set; }

        public int specializationid { get; set; }

        public int shiftid { get; set; }
        public int userid { get; set; }
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
        [DisplayName("№")]
        public int id { get; set; }
        public int patientid { get; set; }
        public int doctorid { get; set; }

        [DisplayName("Дата")]
        public DateOnly date { get; set; }

        [DisplayName("Время")]
        public TimeOnly time { get; set; }

        [DisplayName("Выполнено")]
        public bool completed { get; set; }

        public virtual Doctor doctor { get; set; }
        public virtual Patient patient { get; set; }
    }

    public class Times
    {
        public int id { get; set; }
        public TimeOnly time { get; set; }
        public int shiftid { get; set; }
    }

    public class Mkb
    {
        public int id { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Appointment
    {
        public int id { get; set; }
        public int recordid { get; set; }
        public int mkbid { get; set; }
        public int doctorid { get; set; }
        public int patientid { get; set; }
        public String result { get; set; }

    }
}
