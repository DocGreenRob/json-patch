using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json.Serialization;
using NSubstitute;
using System.Collections.Generic;
using Xunit;
using JsonPatch.Extensions;

// https://docs.microsoft.com/en-us/aspnet/core/web-api/jsonpatch?view=aspnetcore-6.0

namespace JsonPatch.Tests.Extensions
{
    public class JsonPathDocumentExtensionsTests
    {

        [Fact]
        public void Should_Parse_Operation()
        {
            //Arrange
            var operation = new Operation<XIn>
            {
                value = "val",
                path = "/path",
                op = "op",
                from = "from"
            };

            //Act
            var result = operation.Map<XIn, XOut>();

            //Assert
            Assert.True(result is Operation<XOut>);
            Assert.Equal("val", operation.value);
            Assert.Equal("/path", operation.path);
            Assert.Equal("op", operation.op);
            Assert.Equal("from", operation.from);
        }

        [Fact]
        public void Should_Map_JsonPathDocument()
        {
            //Arrange
            IContractResolver _contractResolver = Substitute.For<IContractResolver>();
            List<Operation<XIn>> _operations = Substitute.For<List<Operation<XIn>>>();
            JsonPatchDocument<XIn> jsonPatchDocument = new JsonPatchDocument<XIn>(_operations, _contractResolver);

            //Act
            var result = jsonPatchDocument.Map<XIn, XOut>();

            //Assert
            Assert.NotNull(result);
            Assert.True(result is JsonPatchDocument<XOut>);
        }
    }

    public class XIn { }
    public class XOut { }
}
