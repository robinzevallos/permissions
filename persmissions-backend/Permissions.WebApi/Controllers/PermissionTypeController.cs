using Microsoft.AspNetCore.Mvc;
using Permissions.Services.Models;
using Permissions.Services.Queries;

namespace Permissions.WebApi.Controllers
{
    [ApiController]
    [Route("PermissionTypes")]
    public class PermissionTypeController : ControllerBase
    {
        readonly PermissionTypeQuery query;

        public PermissionTypeController(PermissionTypeQuery query)
        {
            this.query = query;
        }

        [HttpGet]
        public ActionResult<PermissionTypeModel> List()
        {
            return Ok(query.List());
        }
    }
}
