using Permissions.Services.Models;
using System.Threading.Tasks;
using Xunit;

namespace Permissions.Test.Api_Test
{
    public class PermissionTypeApi_Test : BaseApiTest
    {
        [Fact]
        public async Task Get_list()
        {
            var listResponse = await GetClient<PermissionTypeModel[]>("/permissionTypes");

            Assert.True(listResponse.Length > 0);
        }
    }
}
