using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

using DLLParserLibrary.Models;
using DLLParserLibrary.Extensions;

namespace DLLParserLibrary
{
    public static class DLLParser
    {
        public static List<DLLStruct> Parse(string path)
        {
            string[] files = Directory.GetFiles(path, "*.dll");

            var result = files.DLLParsing();

            return result;
        }

        public static void ConsolePrint(this List<DLLStruct> list)
        {
            var sortedList = list.OrderBy(x => x.Name).GroupBy(x => x.Name); // группировка по имени класса

            foreach (var groupList in sortedList)
            {
                Console.WriteLine(groupList.Key);

                foreach (var dllStruct in groupList)
                    foreach (var method in dllStruct.Methods)
                        Console.WriteLine($"\t {method}");
            }
        }
    }
}
