﻿using Microsoft.AspNetCore.Identity;

namespace Lab1.Models;

public class ApplicationUser : IdentityUser
{
    public string Name { get; set; }
}