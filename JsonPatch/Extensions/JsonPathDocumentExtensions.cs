using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System.Linq;

namespace JsonPatch.Extensions
{
    public static class JsonPathDocumentExtensions
    {
        public static JsonPatchDocument<TOut> Map<TIn, TOut>(this JsonPatchDocument<TIn> instance)
            where TIn : class, new()
            where TOut : class, new()
        {
            return new JsonPatchDocument<TOut>(instance.Operations.Select(x => x.Map<TIn, TOut>()).ToList(), instance.ContractResolver);
        }

        public static Operation<TOut> Map<TIn, TOut>(this Operation<TIn> instance)
            where TIn : class, new()
            where TOut : class, new()
        {
            return new Operation<TOut>(instance.op, instance.path, instance.from, instance.value);
        }

    }
}
