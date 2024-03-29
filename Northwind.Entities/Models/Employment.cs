﻿using System;
using System.Collections.Generic;

namespace Northwind.Entities.Models
{
    public partial class Employment : IEntityWithId
    {
        public int EmploymentId { get; set; }
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public DateTime? HireDate { get; set; }
        public DateTime? LeaveDate { get; set; }

        public virtual Employee Employee { get; set; }

        public int Id => EmploymentId;
    }
}
