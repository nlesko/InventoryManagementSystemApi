using InventoryManagementSystem.API.Domain.Common;

namespace InventoryManagementSystem.API.Domain.Entities;

public class ProductCategory : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    #region Navigation Properties
    public virtual ICollection<ProductSubCategory> ProductSubCategories { get; set; } = new List<ProductSubCategory>();
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    #endregion
}