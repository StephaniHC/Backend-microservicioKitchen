using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.StoredModel.Entities
{
    [Table("label")]
    public class LabelStoredModel
    {
        [Key]
        [Column("batchCode")]
        [Required]
        public Guid BatchCode { get; set; } 

        [Column("productionDate")]
        [Required]
        public DateTime ProductionDate { get; set; }

        [Column("expirationDate")]
        [Required]
        public DateTime ExpirationDate { get; set; }

        [Column("detail")]
        [StringLength(500)]
        public string Detail { get; set; }

        [Column("patientId")]
        [Required]
        public Guid PatientId { get; set; }

        [Column("address")]
        [StringLength(250)]
        public string Address { get;  set; }
    }
}
