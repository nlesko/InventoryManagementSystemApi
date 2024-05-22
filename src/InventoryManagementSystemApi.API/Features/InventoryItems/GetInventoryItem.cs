using AutoMapper;
using AutoMapper.QueryableExtensions;

using InventoryManagementSystemApi.API.Common.Exceptions;
using InventoryManagementSystemApi.API.Contracts.InventoryItems;
using InventoryManagementSystemApi.API.Domain.Entities;
using InventoryManagementSystemApi.API.Infrastructure.Persistence;

using MediatR;

using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystemApi.API.Features.InventoryItems;

public static class GetInventoryItem
{
    public record Query(int Id) : IRequest<InventoryItemResult>;

    internal sealed class Handler : IRequestHandler<Query, InventoryItemResult>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public Handler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InventoryItemResult> Handle(Query request, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                throw new OperationCanceledException();
            }

            var entity = await _context.InventoryItems
                .ProjectTo<InventoryItemResult>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity is null)
            {
                throw new NotFoundException(nameof(InventoryItem), request.Id);
            }

            return entity;
        }
    }
}