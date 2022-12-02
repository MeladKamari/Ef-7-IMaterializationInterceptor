using Ef_7_IMaterializationInterceptor.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Ef_7_IMaterializationInterceptor.Context.Interceptors;

public class SetRetrievedInterceptor : IMaterializationInterceptor
{
    public object InitializedInstance(MaterializationInterceptionData materializationData, object instance)
    {
        if (instance is IHasRetrieved hasRetrieved)
        {
            hasRetrieved.Retrieved = DateTime.UtcNow;
        }

        return instance;
    }
}