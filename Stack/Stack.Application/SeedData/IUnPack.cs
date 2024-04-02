using Stack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.SeedData;

public interface IUnPack
{
    Task<List<Tag>> UnPackObjects();
}
