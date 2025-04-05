using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Application.KitchenManager.GetKitchenManager
{
    public class KitchenManagerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Shift { get; set; }

    }
}
