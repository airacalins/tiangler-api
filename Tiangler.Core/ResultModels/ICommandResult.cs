﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiangler.Core.ResultModels
{
    public interface ICommandResult<T> : IExecuteResult
    {
        T Result { get; }
    }
}
