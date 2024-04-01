using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Abstractions.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TQuery, TResult>(TQuery query, CancellationToken cancellationToken = default) where TQuery : class, IQuery<TResult>;
}
