using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Shop_CQRS.Core.Domain.Enum;

namespace Shop_CQRS.Core.Response
{
    public interface IExecutionRespult
    {
        ResponseStatus ResponseStatus { get; }
    }
}
