using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.StoredModel.Entities
{
    [Table("kitchenManager")]
    public class KitchenManagerStoredModel
    {
        [Key]
        [Column("id")]
        [Required]
        public Guid Id { get; set; } 

        [Column("name")]
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [Column("shift")]
        [StringLength(100)]
        [Required]
        public string Shift { get; set; }
    }

}
