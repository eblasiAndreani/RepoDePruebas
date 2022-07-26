using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTest.Domain.Common
{
    public class ErrorMessage
    {
        public const string NOT_STORED_RECORD = "El registro: {0} no se encuentra almacenado";
        public const string NONEXISTENT_RECORDS = "No existen registros almacenados momentaneamente";
    }
}
