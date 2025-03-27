using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace TripOrganization.Models;

public class TripUser{
    public int TripId { get; set; }
    public string UserId { get; set; }

    public Trip Trip { get; set; }
    public IdentityUser User { get; set; }

}