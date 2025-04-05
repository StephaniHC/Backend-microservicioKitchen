using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.StoredModel.Entities
{
    [Table("recipe")]
    public class RecipeStoredModel
    {
        [Key]
        [Column("id")]
        [Required]
        public Guid Id { get; set; } 

        [Column("name")]
        [StringLength(250)]
        [Required]
        public string Name { get; set; }

        [Column("preparationTime")]
        [StringLength(50)] 
        [Required]
        public string PreparationTime { get; set; }
    }
}
