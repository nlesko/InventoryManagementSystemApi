namespace InventoryManagementSystem.Shared.Contracts.ProductCategories;

public class ProductCategoryRequest
{
    public string Name { get; set; } = null!;
    public string? Description { get; set; }    
}