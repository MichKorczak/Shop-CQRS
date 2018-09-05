using System;
using System.Collections.Generic;
using System.Text;
using Shop_CQRS.Core.Domain.Enum;

namespace Shop_CQRS.Core.Response
{
    public class Failure : IExecutionRespult
    {
        public ResponseStatus ResponseStatus => ResponseStatus.Failure;
    }
}
