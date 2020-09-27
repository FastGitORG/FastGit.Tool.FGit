using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;
using CliWrap.EventStream;

namespace FastGit.Tool.FGit
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new Executor().RunAsync(args);
        }
    }
}
