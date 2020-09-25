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
            if (args.Length > 1 && args[0] == "clone")
            {
                var repoUriIndex = FindRepoUriIndex(args);
                if (repoUriIndex > 0)
                {
                    args[repoUriIndex] = args[repoUriIndex].Replace("://github.com/", "://hub.fastgit.org/", StringComparison.OrdinalIgnoreCase);
                }

                if (NoProgressOption(args))
                {
                    Array.Resize(ref args, args.Length + 1);
                    Array.Copy(args, 1, args, 2, args.Length - 2);
                    args[1] = "--progress";
                }
            }
            using var stdOut = Console.OpenStandardOutput();
            using var stdErr = Console.OpenStandardError();
            var cmd = Cli.Wrap("git").WithArguments(string.Join(' ', args)).WithValidation(CommandResultValidation.None) | (stdOut, stdErr);
            await cmd.ExecuteAsync();
        }

        private static bool NoProgressOption(string[] args)
        {
            return Array.FindIndex(args, i => i == "--progress") < 0 && Array.FindIndex(args, i => i == "-q") < 0;
        }

        private static int FindRepoUriIndex(string[] args)
        {
            return Array.FindIndex(args, i => i.StartsWith("http"));
        }
    }
}
