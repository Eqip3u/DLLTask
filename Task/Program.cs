using System;

using DLLParserLibrary;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var finale = DLLParser.Parse(@"..\..\..\..\dllfiles"); // C:\DEV\Assemblies

            finale.ConsolePrint();

            Console.ReadLine();
        }
    }
}
