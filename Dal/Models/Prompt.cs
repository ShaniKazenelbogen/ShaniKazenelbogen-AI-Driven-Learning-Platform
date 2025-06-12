using System;
using System.Collections.Generic;

namespace Dal.models;

public partial class Prompt
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int CategoryId { get; set; }

    public int SubCategoryId { get; set; }

    public string? Prompt_a { get; set; } 

    public string? Response { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Category? Category { get; set; } 

    public virtual SubCategory? SubCategory { get; set; }

    public virtual User? User { get; set; }
}
