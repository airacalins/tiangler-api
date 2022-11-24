using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiangler.Core.ResultModels.Interfaces;

namespace Tiangler.Core.ResultModels
{
    public class ResultModel<T> : IResultModel<T>
    {
        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; }
        public string[] ErrorMessages { get; private set; }
        public T Result { get; }


        public ResultModel(T result, bool isSuccess, params string[] errorMessages)
        {
            Result = result;
            IsSuccess = isSuccess;
            ErrorMessages = errorMessages;
            ErrorMessage = errorMessages != null ? string.Join("|", errorMessages) : string.Empty;
        }
        public ResultModel(T result)
        {
            Result = result;
            IsSuccess = true;
            ErrorMessage = null;
            ErrorMessages = null;
        }

        public ResultModel(bool isSuccess, params string[] errorMessages)
        {
            IsSuccess = isSuccess;
            ErrorMessages = errorMessages;
            ErrorMessage = errorMessages != null ? string.Join("|", errorMessages) : string.Empty;
            Result = default;
        }
    }
}
