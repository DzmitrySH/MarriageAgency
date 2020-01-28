using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    //сущность знак зодиака
    public class ZodiacSign
    {
        [Key]
        [Display(Name = "Знак Зодиака")]
        public int ZodiacSignID { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        //связь
        public ICollection<Client> Clients { get; set; }

    }
}
