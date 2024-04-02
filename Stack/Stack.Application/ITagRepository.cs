using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application;

public interface ITagRepository
{
    Task<bool> AnyAsync();
    Task BulkInsertToDbAsync(List<Tag> tags)
    IQueryable<Tag> GetAllTags();
    Task<IEnumerable<Tag>> GetAllTagsAsIEnumerable();
    Task<bool> DeleteAllTags();
}
