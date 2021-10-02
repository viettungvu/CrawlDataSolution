using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Responses
{
    public class ResponseSuccess<T>:Response<T>
    {
        public ResponseSuccess(T data)
        {
            IsSuccess = true;
            Data = data;
        }
        public ResponseSuccess()
        {
            IsSuccess = true;
        }
    }
}
