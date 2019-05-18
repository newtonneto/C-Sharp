using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L21E04
{
    class PontuacaoInferiorException : Exception
    {
        public PontuacaoInferiorException()
        {

        }
        public PontuacaoInferiorException(string message) : base (message)
        {

        }
        PontuacaoInferiorException(string message, Exception inner) : base (message, inner)
        {

        }
    }
}
