using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineDataCollection.Models
{
    public class Vaccine
    {
        [Key]
        public int VaccineID { get; set; }
        [StringLength(250)]
        [Required]
        public string VaccineName { get; set; }
        [StringLength(5000)]
        [Required]
        public string VaccineDesc { get; set; }
        public List<ClinicalTrial> ClinicalTrials { get; set; }
    }
}
