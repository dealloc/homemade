using System.ComponentModel.DataAnnotations;

namespace Homemade.Database.Entities;

/// <summary>
/// Represents nutritional information for a recipe.
/// </summary>
public class NutritionInfo
{
    /// <summary>
    /// Gets or sets the unique identifier for the nutrition information.
    /// </summary>
    public required long Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the recipe this nutrition information belongs to.
    /// </summary>
    [Required]
    public required long RecipeId { get; set; }

    /// <summary>
    /// Gets or sets the calorie content (e.g., "650 kcal").
    /// </summary>
    [Required]
    [MaxLength(20)]
    public required string Calories { get; set; }

    /// <summary>
    /// Gets or sets the protein content (e.g., "42g").
    /// </summary>
    [Required]
    [MaxLength(20)]
    public required string Protein { get; set; }

    /// <summary>
    /// Gets or sets the carbohydrate content (e.g., "58g").
    /// </summary>
    [Required]
    [MaxLength(20)]
    public required string Carbs { get; set; }

    /// <summary>
    /// Gets or sets the fat content (e.g., "26g").
    /// </summary>
    [Required]
    [MaxLength(20)]
    public required string Fat { get; set; }

    /// <summary>
    /// Gets or sets the recipe this nutrition information belongs to.
    /// </summary>
    [Required]
    public required Recipe Recipe { get; set; }
}
