using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack.Application.Exceptions;

public class BadConfigurationException : Exception
{
    public string Message { get; }
    public BadConfigurationException(string message): base(message)
    {
        Message = message;
    }
}
