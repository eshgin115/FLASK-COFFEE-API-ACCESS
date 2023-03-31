﻿using APICOFFE.Database.Models.Common;

namespace APICOFFE.Database.Models;
public class User : BaseEntity<int>, IAuditable
{
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public Basket? Basket { get; set; }

    public int? RoleId { get; set; }
    public Role? Role { get; set; }
    public int? UserActivationId { get; set; }

    public UserActivation? UserActivation { get; set; }
    //public int? ContactId { get; set; }
    //public Contact? Contact { get; set; }

    public bool IsEmailConfirmed { get; set; }
    //public List<Order>? Orders { get; set; }
    //public List<Blog>? Blogs { get; set; }
}