using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Homemade.Database.Entities;

/// <summary>
/// Represents a tag that can be associated with recipes (e.g., "Italian", "Vegetarian", "Quick & Easy").
/// </summary>
public class Tag
{
    /// <summary>
    /// Gets or sets the unique identifier for the tag.
    /// </summary>
    public required long Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the tag.
    /// </summary>
    [Required]
    [MaxLength(50)]
    public required string Name { get; set; }

    /// <summary>
    /// The recipes that are associated with this tag.
    /// </summary>
    public List<Recipe> Recipes { get; set; } = [];
}
