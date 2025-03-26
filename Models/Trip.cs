using System.ComponentModel.DataAnnotations;
namespace TripOrganization.Models;

public class Trip{
    public int Id { get; set; }
    public string? Title {get;set;}
    public int Capacity {get; set;}
    public string? Data {get; set;}

    [Range(0, double.MaxValue, ErrorMessage = "Cost must be a positive number")]
    [DataType(DataType.Currency)]
    public decimal Cost { get; set; }

    [DataType(DataType.Date)]
    [Required]
    public DateTime Date { get; set; }

}