using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    //сущность национальность
    public class Nationalitie
    {
        [Key]
        [Display(Name = "Национальность")]
        public int NationalID { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        //связи
        public ICollection<Client> Clients { get; set; }

    }
}
