using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Abstractions.Queries;

public interface IQuery<out TResult> : IQuery
{
}

public interface IQuery
{
}
