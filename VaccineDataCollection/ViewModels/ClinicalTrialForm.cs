using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineDataCollection.Models;

namespace VaccineDataCollection.ViewModels
{
    public class ClinicalTrialForm
    {
        public ClinicalTrial ClinicalTrial { get; set; }
        public Vaccine Vaccine { get; set; }
        public List<SelectListItem> VaccineList { get; set; }

    }
}
