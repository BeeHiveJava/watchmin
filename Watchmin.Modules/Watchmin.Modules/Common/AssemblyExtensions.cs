using System.Reflection;

namespace Watchmin.Modules.Common;

internal static class AssemblyExtensions
{
    public static IEnumerable<T> GetInstances<T>(this Assembly assembly) =>
        assembly.GetInstantiableTypes<T>().GetInstances<T>();

    public static IEnumerable<T> GetInstances<T>(this IEnumerable<Assembly> assemblies) =>
        assemblies.SelectMany(assembly => assembly.GetInstances<T>());

    public static IEnumerable<T> GetInstances<T>(this IEnumerable<Type> types) =>
        types.Select(Activator.CreateInstance).Cast<T>();

    public static IEnumerable<Type> GetInstantiableTypes<T>(this Assembly assembly) =>
        new[] { assembly }.GetInstantiableTypes<T>();

    public static IEnumerable<Type> GetInstantiableTypes<T>(this IEnumerable<Assembly> assemblies) =>
        assemblies.SelectMany(assembly => assembly.GetTypes())
            .Where(type => type is { IsClass: true, IsAbstract: false, IsGenericType: false })
            .Where(type => type.IsAssignableTo(typeof(T)));
}
