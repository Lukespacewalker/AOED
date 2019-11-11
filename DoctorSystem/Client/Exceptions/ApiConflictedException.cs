using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DoctorSystem.Client.Exceptions
{
    public class ApiConflictedException<TEntity> : Exception
    {
        public ApiConflictedException(TEntity clientEntity, TEntity serverEntity)
        {
            ClientEntity = clientEntity;
            ServerEntity = serverEntity;
        }

        public TEntity ClientEntity { get; }
        public TEntity ServerEntity { get;  }
    }

    public class ApiServerErrorException : Exception
    {
        public ApiServerErrorException(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }

        public HttpStatusCode StatusCode { get; }
    }
}
