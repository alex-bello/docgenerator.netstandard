// namespace DocsGenerator.Extensions
// {
//     public static class DocsProjectExtensions
//     {
//         public static void LoadReferencedAssemblies(this Assembly assembly)
//         {
//             assembly.GetReferencedAssemblies()
//                 .ToList()
//                 .ForEach(ra => {
//                     try
//                     {
//                         Assembly.Load(ra.FullName);
//                         Console.WriteLine($"{ra.FullName} Loaded.");
//                     }
//                     catch (FileNotFoundException ex)
//                     {
//                         var filename = Path.Combine(Settings.OutputFolder, Settings.TempFolder, ra.FullName.Split(',').First() + ".dll");
//                         Assembly.LoadFrom(filename);
//                         Console.WriteLine($"{ex.FileName} Loaded from file {filename}.");
//                     }
//                 });
//         }
//     }
// }