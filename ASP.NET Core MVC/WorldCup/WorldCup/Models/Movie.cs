using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime Date_Of_Birth { get; set; }
    public string? Genre { get; set; }
    public decimal Market_Price { get; set; }
    public string? Current_Club { get; set; }
}