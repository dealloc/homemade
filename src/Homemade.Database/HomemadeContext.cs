using Homemade.Database.Entities;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homemade.Database;

/// <summary>
/// Database context for the Homemade application.
/// </summary>
public sealed class HomemadeContext(
    DbContextOptions<HomemadeContext> options
) : IdentityDbContext<User, Role, long>(options)
{
    /// <summary>
    /// Gets or sets the recipes.
    /// </summary>
    public required DbSet<Recipe> Recipes { get; set; }

    /// <summary>
    /// Gets or sets the recipe ingredients.
    /// </summary>
    public required DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    /// <summary>
    /// Gets or sets the recipe instructions.
    /// </summary>
    public required DbSet<RecipeInstruction> RecipeInstructions { get; set; }

    /// <summary>
    /// Gets or sets the tags.
    /// </summary>
    public required DbSet<Tag> Tags { get; set; }

    /// <summary>
    /// Gets or sets the nutrition information.
    /// </summary>
    public required DbSet<NutritionInfo> NutritionInfos { get; set; }
}