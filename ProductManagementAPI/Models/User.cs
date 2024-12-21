using System;
using System.Collections.Generic;

namespace ProductManagementAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Passwordhash { get; set; }

    public int? RoleId { get; set; }

    public virtual Role? Role { get; set; }
}
