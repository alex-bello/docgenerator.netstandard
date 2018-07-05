using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DocsGenerator.Extensions
{
    public static class AssemblyTools
    {
        
        public static IEnumerable<string> GetAllNamespaces(this Assembly assembly)
        {
            try
            {
                return assembly.ExportedTypes.Select(t => t.Namespace).Where(n => !string.IsNullOrWhiteSpace(n)).Distinct();
            }
            catch (ReflectionTypeLoadException ex)
            {
                foreach (var x in ex.LoaderExceptions) Console.WriteLine("{0} could not be loaded.", x.Message);
                throw new Exception();
            }            
        }

        public static string GetSimpleName(this string fullName)
        {
            return fullName.Split(',').First();
        }

        public static string GetSimpleName(this Assembly assembly)
        {
            return assembly.FullName.Split(',').First();
        }

        public static string GetSimpleName(this AssemblyName assemblyName)
        {
            return assemblyName.FullName.Split(',').First();
        }

        public static string ToFileName(this Assembly assembly)
        {
            return assembly.GetSimpleName().Replace(".", "-").ToLower();
        }
        
        public static IEnumerable<Type> GetUserTypes(this Assembly assembly)
        {
            return assembly
                .ExportedTypes
                .Where(t => !t.IsDefined(typeof(CompilerGeneratedAttribute), true));
        }

        // public static void LoadAssemblyFromName(this Assembly assembly, string assemblyName)
        // {
        //     return Assembly.LoadFrom()
        //         .DefinedTypes
        //         .Where(t => !t.IsDefined(typeof(CompilerGeneratedAttribute), true));
        // }

    }
}