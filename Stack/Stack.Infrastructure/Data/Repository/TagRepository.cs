using Microsoft.EntityFrameworkCore;
using Stack.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Infrastructure.Data.Repository;

internal class TagRepository : ITagRepository
{
    private readonly ApplicationDbContext _context;

    public TagRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync()
        => await _context.tags.AnyAsync();
}
