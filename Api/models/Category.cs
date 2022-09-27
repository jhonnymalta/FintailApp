using System.ComponentModel.DataAnnotations;

namespace tailfinAPI.models;

public class Category
{
    [Key]
    public int ID { get; set; }
    [Required]
    public string Title { get; set; }
    public string Description { get; set; }
}

