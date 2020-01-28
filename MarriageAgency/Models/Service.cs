using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    //сущность услуги агенства
    public class Service
    {
        [Key]
        [Display(Name = "Номер Услуги")]
        public int ServiseID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата услуги")]
        public DateTime Date { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Стоимость")]
        public decimal Cost { get; set; }


        [Display(Name = "Клиент")]
        public int ClientID { get; set; }

        [Display(Name = "Сотрудник")]
        public int EmployeeID { get; set; }

        //связи таблиц        
        public Client Clients { get; set; }       
        public Employee Employee { get; set; }
    }
}
