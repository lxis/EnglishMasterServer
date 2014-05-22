using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ResponseMessage<T>
    {
        public ExceptionMessage Error { get; set; }
        public T Data { get; set; }
    }
}
