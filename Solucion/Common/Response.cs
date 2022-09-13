﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public Response()
        {

        }
    }
}
