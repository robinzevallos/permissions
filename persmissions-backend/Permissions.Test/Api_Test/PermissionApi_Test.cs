using Permissions.Services.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Permissions.Test.Api_Test
{
    public class PermissionApi_Test : BaseApiTest
    {
        [Fact]
        public async Task Get_list()
        {
            var listResponse = await GetClient<PermissionModel[]>("/permissions");

            Assert.True(listResponse.Length > 0);
        }

        [Fact]
        public async Task Get_by_id()
        {
            var response = await GetClient<PermissionModel>("/permissions/1");

            var expected = new PermissionModel
            {
                Id = 1,
                FirstnameEmployee = "Carlos",
                LastnameEmployee = "Mock",
                Date = new DateTime(2021, 06, 15),
                PermissionType = new PermissionTypeModel
                {
                    Id = 1,
                    Description = "Enfermedad"
                }
            };

            Assert.Equal(expected, response);
        }

        [Fact]
        public async Task Create()
        {
            var actualModel = new PermissionModifierModel
            {
                FirstnameEmployee = "Lola",
                LastnameEmployee = "Landa",
                Date = new DateTime(2021, 06, 15),
                PermissionTypeId = 1
            };

            var createResponse = await PostClient<bool>("/permissions", actualModel);

            Assert.True(createResponse);

            var listResponse = await GetClient<PermissionModel[]>("/permissions");

            var expectedModel = listResponse.Last();

            Assert.Equal(expectedModel.FirstnameEmployee, actualModel.FirstnameEmployee);
            Assert.Equal(expectedModel.LastnameEmployee, actualModel.LastnameEmployee);
            Assert.Equal(expectedModel.Date, actualModel.Date);
            Assert.Equal(expectedModel.PermissionType.Id, actualModel.PermissionTypeId);
        }

        [Fact]
        public async Task Update()
        {
            var expectedModel = await GetClient<PermissionModel>("/permissions/2");

            var actualModel = new PermissionModifierModel
            {
                FirstnameEmployee = expectedModel.FirstnameEmployee,
                LastnameEmployee = expectedModel.LastnameEmployee,
                Id = 2,
                Date = new DateTime(2021, 06, 16),
                PermissionTypeId = 2
            };

            var createResponse = await PutClient<bool>("/permissions", actualModel);

            Assert.True(createResponse);

            Assert.Equal(expectedModel.Date, actualModel.Date);
            Assert.Equal(expectedModel.PermissionType.Id, actualModel.PermissionTypeId);
        }
    }
}
