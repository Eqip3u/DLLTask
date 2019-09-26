using System.Collections.Generic;

namespace DLLParserLibrary.Models
{
    public class DLLStruct
    {
        public DLLStruct(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public IEnumerable<string> Methods { get; set; }
    }
}
