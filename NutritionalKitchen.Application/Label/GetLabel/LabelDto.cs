using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Label.GetLabel
{
    public class LabelDto
    {
        public Guid BatchCode { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }  
        public string Detail { get; set; }  
        public string Address { get; set; }  
        public Guid PatientId { get; set; }   
    }
}
