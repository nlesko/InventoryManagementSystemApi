using InventoryManagementSystem.API.Domain.Common;

namespace InventoryManagementSystem.API.Domain.Entities;

public class ProductSubCategory : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public int ProductCategoryId { get; set; }

    #region Navigation Properties
    public virtual ProductCategory ProductCategory { get; set; } = null!;
    public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    #endregion
}

public class BaseAuditablesEntity
{
}