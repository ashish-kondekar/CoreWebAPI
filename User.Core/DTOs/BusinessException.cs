﻿using System;
using System.Collections.Generic;
using System.Text;

namespace User.Core
{
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message)
        {

        }
    }
}
