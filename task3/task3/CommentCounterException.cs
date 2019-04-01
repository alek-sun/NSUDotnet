using System;
using System.Collections.Generic;
using System.Text;

namespace task3
{
    class CommentCounterException : System.Exception
    {
        public CommentCounterException(string message) : base(message)
        {
        }
    }
}
