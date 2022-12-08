using System.ComponentModel.DataAnnotations;

namespace MvcSM.Models;

public class Structure
{
    public int Id { get; set; }
    public string? Name { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string? Gender { get; set; }
    public string? Student_Code { get; set; }
}