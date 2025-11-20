using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoologico1_Modelos
{
    public class ApiResult<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        //public int RowsAffected { get; set; }

        public static ApiResult<T> Ok(T data)
        {
            return new ApiResult<T>
            {
                Success = true,
                Data = data
            };
        }

        public static ApiResult<T> Fail(string message)
        {
            return new ApiResult<T>
            {
                Success = false,
                Message = message
            };
        }

    }
}
