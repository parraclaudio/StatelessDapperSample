using System;
using System.Collections.Generic;
using System.Text;

namespace StatelessDapperSample.Domain.ValueObj
{
    public enum TriggerEnum
    {
        NormalPath,
        Blocked,
        Success,
        Error,
        Archive,
        Retry,
        Enqueue
    }
}
