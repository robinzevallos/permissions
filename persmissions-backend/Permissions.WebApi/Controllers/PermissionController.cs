using Microsoft.AspNetCore.Mvc;
using Permissions.Services.Models;
using Permissions.Services.Modifiers;
using Permissions.Services.Queries;
using System.Threading.Tasks;

namespace Permissions.WebApi.Controllers
{
    [ApiController]
    [Route("permissions")]
    public class PermissionController : ControllerBase
    {
        readonly PermissionQuery query;
        readonly PermissionModifier modifier;

        public PermissionController(
            PermissionQuery query,
            PermissionModifier modifier)
        {
            this.query = query;
            this.modifier = modifier;
        }

        [HttpGet]
        public ActionResult<PermissionModel> List()
        {
            return Ok(query.List());
        }

        [HttpGet("{id}")]
        public ActionResult<PermissionModel> ById(int id)
        {
            return Ok(query.ById(id));
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Create([FromBody] PermissionModifierModel model)
        {
            return Ok(await modifier.Create(model));
        }

        [HttpPut]
        public async Task<ActionResult<bool>> Update([FromBody] PermissionModifierModel model)
        {
            return Ok(await modifier.Update(model));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Remove(int id)
        {
            return Ok(await modifier.Remove(id));
        }
    }
}
