using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Stack.Application.Abstractions.Commands;

public interface ICommandDispatcher
{
    Task SendAsync<T>(T command, CancellationToken cancellationToken = default) where T : class, ICommand;
}
