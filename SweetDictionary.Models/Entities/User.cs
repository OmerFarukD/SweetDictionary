﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Entities;

public sealed class User : Entity<long>
{
    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<Post> Posts { get; set; }

    public List<Comment> Comments { get; set; }

}
