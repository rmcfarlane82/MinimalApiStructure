using System.Reflection;

namespace Application;

public class ApplicationAssemblyHook
{
    public static Assembly Assembly => typeof(ApplicationAssemblyHook).Assembly;
}