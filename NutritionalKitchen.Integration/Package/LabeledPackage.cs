using Joseco.Communication.External.Contracts.Message;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalKitchen.Integration.Package
{
    public record LabeledPackage : IntegrationMessage
    {
        public string BatchCode { get; set; }

        public LabeledPackage(string batchCode, string? correlationId = null, string? source = null)
            : base(correlationId, source)
        {
            BatchCode = batchCode;
        }
    }
}
