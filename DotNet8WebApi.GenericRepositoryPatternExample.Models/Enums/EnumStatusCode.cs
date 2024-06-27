using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8WebApi.GenericRepositoryPatternExample.Models.Enums
{
    public enum EnumStatusCode
    {
        Success = 200,
        Created = 201,
        Accepted = 202,
        BadRequest = 400,
        NotFound = 404,
        Duplicate = 409,
        InternalServerError = 500
    }
}
