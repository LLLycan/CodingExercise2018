using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandler
{
    [Serializable]
    internal class FileNotExistException : Exception
    {
        public FileNotExistException()
        {
        }

        public FileNotExistException(string message) : base(message)
        {
        }

        public FileNotExistException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
