using System;
using System.Collections.Generic;

namespace Northwind.Entities.Models
{
    public partial class Region : IEntityWithId
    {
        public Region()
        {
            Territories = new HashSet<Territory>();
        }

        public int RegionId { get; set; }
        public string RegionDescription { get; set; }

        public virtual ICollection<Territory> Territories { get; set; }

        public int Id => RegionId;
    }
}
