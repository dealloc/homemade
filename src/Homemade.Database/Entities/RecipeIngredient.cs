using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Homemade.Database.Entities;

/// <summary>
/// Represents an ingredient in a recipe.
/// </summary>
public class RecipeIngredient
{
    /// <summary>
    /// Gets or sets the unique identifier for the recipe ingredient.
    /// </summary>
    public required long Id { get; set; }

    /// <summary>
    /// Gets or sets the ingredient text (e.g., "2 cups flour" or "500g chicken breast").
    /// </summary>
    [Required]
    [MaxLength(500)]
    public required string Ingredient { get; set; }

    /// <summary>
    /// Gets or sets the order in which this ingredient should be displayed.
    /// </summary>
    [Required]
    public required int Order { get; set; }

    /// <summary>
    /// Gets or sets the recipe this ingredient belongs to.
    /// </summary>
    [Required]
    public required Recipe Recipe { get; set; }
}
