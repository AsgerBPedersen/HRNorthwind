using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Entities.Models
{
    public interface IEntityWithId
    {
        int Id { get; }
    }
}
