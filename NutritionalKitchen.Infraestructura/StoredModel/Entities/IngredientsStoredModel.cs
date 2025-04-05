using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.StoredModel.Entities
{
    [Table("ingredients")]
    public class IngredientsStoredModel
    {
        [Key]
        [Column("id")]
        [Required]
        public Guid Id { get; set; } 

        [Column("name")]
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
    }
}
