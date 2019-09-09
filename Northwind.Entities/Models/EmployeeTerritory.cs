using System;
using System.Collections.Generic;

namespace Northwind.Entities.Models
{
    public partial class EmployeeTerritory : IEntityWithId
    {
        public int EmployeeId { get; set; }
        public string TerritoryId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Territory Territory { get; set; }

        public int Id => throw new NotImplementedException();
    }
}
