using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace PoverkaServer.Models;

public class ApplicationUser : IdentityUser
{
    [StringLength(100)]
    public string? LastName { get; set; }

    [StringLength(100)]
    public string? FirstName { get; set; }

    [StringLength(100)]
    public string? MiddleName { get; set; }

    [StringLength(150)]
    public string? Position { get; set; }
}

