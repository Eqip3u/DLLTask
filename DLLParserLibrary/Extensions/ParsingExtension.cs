using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using DLLParserLibrary.Models;

namespace DLLParserLibrary.Extensions
{
    public static class ParsingExtension
    {
        public static List<DLLStruct> DLLParsing(this string[] dllFiles)
        {
            if (dllFiles.Count() == 0)
                throw new System.Exception("Нет DLL-файлов в текущей директории");

            var dllList = new List<DLLStruct>();

            foreach (var dll in dllFiles)
            {
                var types = Assembly.LoadFrom(dll).GetTypes();

                foreach (var type in types)
                {
                    var dllStruct = new DLLStruct(type.Name);

                    MethodInfo[] methodInfos = type.GetMethods(
                        BindingFlags.DeclaredOnly |
                        BindingFlags.Instance |
                        BindingFlags.Public |
                        BindingFlags.NonPublic);

                    dllStruct.Methods = methodInfos.Where(x => x.IsPublic || x.IsFamily).Select(x => x.Name);

                    dllList.Add(dllStruct);
                }
            }

            return dllList;
        }
    }
}
