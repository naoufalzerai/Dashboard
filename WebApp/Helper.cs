using System.Linq;
using BL.Interfaces;
using DAL;

namespace WebApp;

public static class Helper
{
    public static List<Type> RegisterServices()
    {
        return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s=> s.GetTypes() )
            .Where(p=>p.GetInterfaces().Contains(typeof(IBLWithUnitOfWork))&&p.IsInterface)
            .ToList<Type>();
    }

    public static Type GetClassFromInterface(Type T)
    {
        return AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .FirstOrDefault(p => Enumerable.Contains(p.GetInterfaces(), T)) ?? throw new InvalidOperationException();
    }
}