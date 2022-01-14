using Microsoft.Extensions.Caching.Memory;
using System.Reflection;
namespace Catharsium.Util.Caching;

public class CachedService<T> where T : class
{
    private readonly T instance;
    private readonly IMemoryCache cache;


    public CachedService(T instance, IMemoryCache cache)
    {
        this.instance = instance;
        this.cache = cache;
    }


    public virtual TResult GetData<TResult>(string method, params object[] parameters) where TResult : class
    {
        var type = this.instance.GetType();
        var parameterTypes = parameters != null ? parameters.Select(x => x.GetType()).ToArray() : Array.Empty<Type>();
        var bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        var methodInfo = type.GetMethod(method, bindingFlags, null, CallingConventions.Any, parameterTypes, null);

        if (methodInfo == null || methodInfo.ReturnType != typeof(TResult)) {
            return default;
        }

        var cacheKey = parameters != null
                ? $"{type.Name}.{method}({string.Join(",", parameters)})"
                : $"{type.Name}.{method}()";

        var result = this.cache.Get<TResult>(cacheKey);
        if (result != null) {
            return result;
        }

        result = methodInfo.Invoke(this.instance, parameters) as TResult;
        this.cache.Set(cacheKey, result);

        return result;
    }
}