﻿using System.Linq;
using System.Threading.Tasks;
using Pineapple.Domain.Spaces;
using Pineapple.Domain.Spaces.Exceptions;
using Pineapple.Domain.Spaces.ValueObjects;
using Space = Pineapple.Infrastructure.DataAccess.InMemory.Entities.Space;

namespace Pineapple.Infrastructure.DataAccess.InMemory.Repositories
{
    /// <inheritdoc />
    public sealed class SpaceRepository : ISpaceRepository
    {
        private readonly InMemoryContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpaceRepository"/> class.
        /// </summary>
        /// <param name="context">The context holding all in-memory entities.</param>
        public SpaceRepository(InMemoryContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public Task<ISpace> Get(SpaceName name)
        {
            Space space = _context.Spaces.SingleOrDefault(x => x.Name.Equals(name));
            if (space == null)
            {
                throw new SpaceNotFoundException($"The space '{name}' does not exist.");
            }

            return Task.FromResult<ISpace>(space);
        }

        /// <inheritdoc />
        public Task<SpacesCollection> All()
        {
            var spaces = new SpacesCollection();
            spaces.Add(_context.Spaces.Select(x => x.Name));
            return Task.FromResult(spaces);
        }

        /// <inheritdoc />
        public async Task Add(ISpace space)
        {
            if (_context.Spaces.Any(x => x.Name.Equals(space.Name)))
            {
                throw new SpaceAlreadyExistsException($"The space '{space.Name}' already exists.");
            }

            _context.Spaces.Add((Space)space);
            await Task.CompletedTask;
        }
    }
}
