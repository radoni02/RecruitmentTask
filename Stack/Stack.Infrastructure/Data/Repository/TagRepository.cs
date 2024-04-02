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
            await Console.Out.WriteLineAsync($"{ex.Message}   {ex.InnerException}");
            return false;
        }
    }

    public IQueryable<Tag> GetAllTags()
        => _context.tags.AsQueryable();

    public async Task<IEnumerable<Tag>> GetAllTagsAsIEnumerable()
        => await _context.tags.ToListAsync();


    public async Task<bool> DeleteAllTags()
    {
        try
        {
            await _context.tags.ExecuteDeleteAsync();
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
        
    } 
    

    
    
}
