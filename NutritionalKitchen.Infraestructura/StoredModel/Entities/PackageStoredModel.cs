using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Infraestructura.StoredModel.Entities
{
    [Table("package")]
    public class PackageStoredModel
    {
        [Key]
        [Column("id")]
        [Required]
        public Guid Id { get; set; } 

        [Column("status")]
        [StringLength(100)]  
        [Required]
        public string Status { get; set; }

        [ForeignKey("label")]
        [Column("batchCode")]
        [Required]
        public string BatchCode { get; set; }

        [ForeignKey("preparedRecipe")]
        [Column("preparedRecipeId")]
        [Required]
        public Guid PreparedRecipeId { get; set; }
    }

}
