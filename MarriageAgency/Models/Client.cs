using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    //сущность клиенты агенства
    public class Client
    {
        [Display(Name = "Клиент")]
        public int ClientID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Ф.И.О")]
        public string FirsLastMidName { get; set; }

        [Range(18, 100, ErrorMessage = "Значение должно быть в пределах от {1} до {2}")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата рождения")]
        public DateTime DateofBirth { get; set; }
        
        [Range(140, 220, ErrorMessage = "Значение должно быть в пределах от {1} до {2}")]
        [Display(Name = "Рост")]
        public int Height { get; set; }
        
        [Range(40, 200, ErrorMessage = "Значение должно быть в пределах от {1} до {2}")]
        [Display(Name = "Вес")]
        public int Weight { get; set; }
        
        [Range(0, 10)]
        [Display(Name = "Дети")]
        public int Children { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Семейное положение")]
        public string MaritalStatus { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Вредные привычки")]
        public string BadHabits { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Хобби")]
        public string Hobby { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Описание")]
        public string Description { get; set; }


      
        [Display(Name = "Знак Зодиака")]
        public int ZodiacSignID { get; set; }
        public ZodiacSign ZodiacSign { get; set; }

        [Display(Name = "Отношения")]        
        public int RelationID { get; set; }
        public Relation Relation { get; set; }

       [Display(Name = "Национальность")]
        public int NationalID { get; set; }
        public Nationalitie Nationalitie { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Адрес")]
        public string Addres { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 8)]
        [Display(Name = "Паспорт")]
        public string Passport { get; set; }

        //связи таблиц
        public ICollection<Service> Services { get; set; }

    }
}
