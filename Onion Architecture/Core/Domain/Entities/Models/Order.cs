using Domain.Entities.Common;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Models;

public partial class Order : BaseEntity
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public DateTime Createdate { get; set; }

    public DateTime Updatedate { get; set; }

    public DateTime Deletedate { get; set; }

    public Guid CustomeridFororder { get; set; }

    public Guid ProductidFororder { get; set; }

    public virtual Customer CustomeridFororderNavigation { get; set; } = null!;

    public virtual Product ProductidFororderNavigation { get; set; } = null!;
}
