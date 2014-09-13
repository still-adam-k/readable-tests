using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ReadableTests.Printing
{
    public class ConsolePrettyPrinter : StringWriter
    {
        private TextWriter consoleOutput;
        
        public void HijackConsole()
        {
            consoleOutput = Console.Out;
            Console.SetOut(this);
        }

        public void ReleaseConsole()
        {
            Console.SetOut(consoleOutput);
        }

        public override void Write(object value)
        {
            consoleOutput.Write(JsonConvert.SerializeObject(value, Formatting.Indented));
        }

        public override void WriteLine(object value)
        {
            consoleOutput.WriteLine(JsonConvert.SerializeObject(value, Formatting.Indented));
        }    
    }
}
