using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    //сущность сотрудники агенства
    public class Employee
    {
        [Display(Name = "Сотрудник")]
        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "ФИО")]
        public string FirsLastMidName { get; set; }
       
        [Range(18, 100, ErrorMessage = "Значение должно быть в пределах от {1} до {2}")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Адрес")]
        public string Addres { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Паспорт")]
        public string Passport { get; set; }

        [Display(Name = "Должности")]
        public int PositionID { get; set; }

        public Position Position { get; set; }

        public ICollection<Service> Services { get; set; }
    }
}
