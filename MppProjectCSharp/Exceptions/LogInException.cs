﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MppProjectCSharp.Exceptions
{
    internal class LogInException:Exception
    {
        public LogInException(string message) : base(message)
        {
        }
    }
}
