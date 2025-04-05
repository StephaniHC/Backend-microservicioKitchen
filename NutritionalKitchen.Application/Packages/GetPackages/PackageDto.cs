using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.Package.GetPackages
{
    public class PackageDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public Guid PreparedRecipeId { get; set; }
        public string BatchCode  { get; set; }
    }
}
 