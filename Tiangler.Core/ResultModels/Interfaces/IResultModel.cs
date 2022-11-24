using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiangler.Core.ResultModels.Interfaces
{
    public interface IResultModel<T>
    {
        bool IsSuccess { get; }
        string ErrorMessage { get; }
        T Result { get; }
    }
}
