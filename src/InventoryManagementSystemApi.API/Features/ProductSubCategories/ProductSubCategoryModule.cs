using InventoryManagementSystemApi.API.Common;
using InventoryManagementSystemApi.API.Contracts.ProductSubCategories;
using InventoryManagementSystemApi.API.Features.ProductCategories;

using MediatR;

namespace InventoryManagementSystemApi.API.Features.ProductSubCategories;

public class ProductSubCategoryModule : BaseEndpointModule
{
    public ProductSubCategoryModule() : base("product-sub-categories") { }

    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("", async (ISender sender, CancellationToken cancellationToken = new()) =>
        {
            return await sender.Send(new GetProductSubCategories.Query(), cancellationToken);
        })
        .WithName(nameof(GetProductSubCategories))
        .WithOpenApi()
        .RequireAuthorization();

        app.MapGet("{id}", async (ISender sender, int id, CancellationToken cancellationToken) =>
        {
            return await sender.Send(new GetProductSubCategory.Query(id), cancellationToken);
        })
        .WithName(nameof(GetProductSubCategory))
        .WithOpenApi()
        .RequireAuthorization();

        app.MapPost("", async (ISender sender, ProductSubCategoryRequest data, CancellationToken cancellationToken = new()) =>
        {
            var id = await sender.Send(new CreateProductSubCategory.Command(data), cancellationToken);
            return Results.Created($"product-sub-categories/{id}", id);
        })
        .WithName(nameof(CreateProductSubCategory))
        .WithOpenApi()
        .RequireAuthorization();

        app.MapPut("{id}", async (ISender sender, ProductSubCategoryRequest data, int id, CancellationToken cancellationToken = new()) =>
        {
            await sender.Send(new UpdateProductSubCategory.Command(id, data), cancellationToken);

            return Results.NoContent();
        })
        .WithName(nameof(UpdateProductSubCategory))
        .WithOpenApi()
        .RequireAuthorization();

        app.MapDelete("{id}", async (ISender sender, int id, CancellationToken cancellationToken = new()) =>
        {
            var result = await sender.Send(new DeleteProductSubCategory.Command(id), cancellationToken);
            return Results.Ok(result);
        })
        .WithName(nameof(DeleteProductSubCategory))
        .WithOpenApi()
        .RequireAuthorization();
    }
}