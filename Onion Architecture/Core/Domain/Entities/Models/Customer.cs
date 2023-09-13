using Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Models;

public partial class Customer:BaseEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public DateTime Updatedate { get; set; }

    public DateTime Deletedate { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
