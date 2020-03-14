using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarriageAgency.Models.ViewModels
{
    public class DateClient
    {
        [DataType(DataType.Date)]
        public DateTime? DateofBirth { get; set; }

        public int ClientCount { get; set; }
        //public int Summa { get; set; }
    }
}
