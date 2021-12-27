using JsonPatch.Controllers;
using JsonPatch.Extensions;
using JsonPatch.Models;
using JsonPatch.Models.Patch;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json.Serialization;
using NSubstitute;
using Xunit;

namespace JsonPatch.Tests.Controllers
{
    public class PatchControllerTests
    {
        private StudentController _studentController;
        private List<Operation<PatchStudent>> _operations;
        private IContractResolver _contractResolver;

        public PatchControllerTests()
        {
            _operations = Substitute.For<List<Operation<PatchStudent>>>();
            _contractResolver = Substitute.For<IContractResolver>();
        }

        [Fact]
        [Trait(TestGlobals.TraitNames.Method, nameof(StudentController.PatchAsync))]
        [Trait(TestGlobals.TraitNames.Outcome, TestGlobals.TestTypes.Positive)]
        public async void Should_SwapBuyers_Using_JsonPatch()
        {
            // Arrange
            JsonPatchDocument<PatchStudent> jsonPatchDocument = new JsonPatchDocument<PatchStudent>(_operations, _contractResolver);
            

            // Act
            await _studentController.PatchAsync("id", jsonPatchDocument);

            // Assert
            await _vehicleOrderProcessor.Received().UpdateAsync(_testOrderEntity);
        }

        [Fact]
        [Trait(TestGlobals.TraitNames.Method, nameof(OrdersController.Patch))]
        [Trait(TestGlobals.TraitNames.Outcome, TestGlobals.TestTypes.Negative)]
        public async void Should_Get_UnprocessableEntityResult_When_Order_AlreadySubmitted_For_Patch()
        {
            // Arrange
            JsonPatchDocument<PatchOrder> jsonPatchDocument = new JsonPatchDocument<PatchOrder>(_operations, _contractResolver);
            var orderPatchDocument = jsonPatchDocument.Map<PatchOrder, DataAccess.Entities.Order>();

            // Act
            var actionResult = await _studentController.Patch("id", jsonPatchDocument);

            // Assert
            Assert.IsType<ConflictResult>(actionResult);
        }
    }
}