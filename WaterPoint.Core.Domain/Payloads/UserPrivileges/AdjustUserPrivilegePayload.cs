using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace WaterPoint.Core.Domain.Payloads.UserPrivileges
{
    public class AdjustUserPrivilegePayload : IPayload
    {
        [Required]
        public IList<int> PrivilegeIds { get; set; }
    }
}
