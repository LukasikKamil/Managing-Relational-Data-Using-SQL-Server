using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ImaterializationInterceptor, MaterializationInterceptionData
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ALLinONE.Shared;

public class SetLastRefreshedInterceptor : IMaterializationInterceptor
{
    public object InitializedInstance(MaterializationInterceptionData materializationData, object entity)
    {
        if (entity is IHasLastRefreshed entityWithLastRefreshed)
        {
            entityWithLastRefreshed.LastRefreshed = DateTimeOffset.UtcNow;
        }
        return entity;
    }
}
