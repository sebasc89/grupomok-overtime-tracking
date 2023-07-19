using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoMok.OvertimeTracking.Core.Exceptions
{
    public class ApplicationDomainException : Exception
    {
        public ApplicationDomainException(string message) : base(message)
        {
        }

        public ApplicationDomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
