using System;
using System.Collections.Generic;
using System.Text;

namespace StatelessDapperSample.Domain.ValueObj
{
    public enum StatusEnum
    {
        Initial = 0,
        Wait = 1,
        Blocked = 2,
        Registered = 3,
        Retry = 4,
        Error = 5,
        Archived = 6
    }
}
