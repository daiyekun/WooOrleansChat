using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Woo.Code.MSBuild
{
     class HelloWorld
    {
        static void Main()
        {
#if DebugConfig
        Console.WriteLine("WE ARE IN THE DEBUG CONFIGURATION");
#endif

            Console.WriteLine("Hello, world!");
        }
    }
}
