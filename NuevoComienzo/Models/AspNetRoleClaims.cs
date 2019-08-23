using System;
using System.Collections.Generic;

namespace NuevoComienzo.Models
{
    public partial class AspNetroleClaims
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
