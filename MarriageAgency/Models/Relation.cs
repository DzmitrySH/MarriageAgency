using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models
{
    //сущность отношения
    public class Relation
    {
        [Key]
        [Display(Name = "Отношения")]
        public int RelationID { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [StringLength(20, MinimumLength = 5)]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        //связь таблиц
        public ICollection<Client> Clients { get; set; }

    }
}
