using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineDataCollection.Models
{
    public class ClinicalTrial
    {
        [Key]
        public int TrialID { get; set; }
        [StringLength(250)]
        [Required]
        public string TrialName { get; set; }
        [StringLength(5000)]
        [Required]
        public string TrialDesc { get; set; }
        [StringLength(250)]
        [Required]
        public string TrialLocation { get; set; }
        public int VaccineID { get; set; }
        [ReadOnly(true)]
            [ForeignKey("VaccineID")]
        public virtual Vaccine Vaccine { get; set; }

    }
}
