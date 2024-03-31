using Microsoft.EntityFrameworkCore;
using Stack.Application;
using Stack.Application.Dtos;
using Stack.Domain.Model;
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

    public async Task<bool> BulkInsertToDbAsync(List<Tag> tags)
    {
        try
        {
            foreach (var t in tags)
            {
                await _context.tags.AddAsync(t);
            }
            await _context.SaveChangesAsync();
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }

    public async Task<List<Tag>> GetAllTags()
        => await _context.tags.ToListAsync();
    
}
