using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L21E04
{
    class EmailExistenteException : Exception
    {
        public EmailExistenteException()
        {

        }
        public EmailExistenteException(string message) : base(message)
        {

        }
        public EmailExistenteException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
