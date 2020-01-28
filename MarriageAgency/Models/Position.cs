using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    //сущность должности
    public class Position
    {
        [Display(Name = "Должности")]
        public int PositionID { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Должности")]
        public string NamePosition { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        [Display(Name = "Оклад")]
        public decimal Salary { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Обязанности")]
        public string Responsibilitie { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Требования")]
        public string Requirement { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
