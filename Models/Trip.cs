using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace TripOrganization.Models;

public class Trip{
    [Required]
    public int Id { get; set; }

    [BindNever]
    public string OwnerId { get; set; }
    [Required]
    public string? Title {get;set;}
    [Required]
    public int Capacity {get; set;}
    [Required]
    public string? Data {get; set;}

    [Range(0, double.MaxValue, ErrorMessage = "Cost must be a positive number")]
    [DataType(DataType.Currency)]
    public decimal Cost { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTime Date { get; set; }

}