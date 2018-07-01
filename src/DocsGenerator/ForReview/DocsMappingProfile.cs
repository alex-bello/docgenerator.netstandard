// using System.Linq;
// using System.Reflection;
// using AutoMapper;
// using DocsGenerator.Extensions;
// using DocsGenerator.Files;

// namespace DocsGenerator
// {
//     public class DocsMappingProfile : Profile
//     {
//         public DocsMappingProfile() : base()
//         {
//             CreateMap<Assembly, AssemblyDocsFileInfo>()
//                 .ForMember( dest => dest.ExportedTypes, opt => opt.ResolveUsing( f => f.GetUserTypes())); // Add adults and children to get total
//         }

//     }
// }