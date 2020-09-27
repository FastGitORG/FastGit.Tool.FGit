using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CliWrap;

namespace FastGit.Tool.FGit
{
    public class Executor
    {

        public Executor()
        {

        }

        public async Task RunAsync(string[] args)
        {
            // only for 'clone' command
            if (args.Length > 1 && args[0] == "clone")
            {
                args = ReorganizeArgs(args);
            }
            using var stdOut = Console.OpenStandardOutput();
            using var stdErr = Console.OpenStandardError();
            var cmd = Cli.Wrap("git").WithArguments(args).WithValidation(CommandResultValidation.None) | (stdOut, stdErr);
            await cmd.ExecuteAsync();
        }

        private string[] ReorganizeArgs(string[] args)
        {
            args = ReplaceRepoUrl(args);

            args = SetProgressOption(args);

            return args;
        }

        public string[] SetProgressOption(string[] args)
        {
            if (NoProgressOption(args))
            {
                // In system shell, the git always display progress information even if no '--progress' specified, so we explicitly add an option '--progress' unless '-q' is specified.
                Array.Resize(ref args, args.Length + 1);
                Array.Copy(args, 1, args, 2, args.Length - 2);
                args[1] = "--progress";
            }

            return args;
        }

        public string[] ReplaceRepoUrl(string[] args)
        {
            var repoUriIndex = FindRepoUrlIndex(args);
            if (repoUriIndex > 0)
            {
                args[repoUriIndex] = args[repoUriIndex]
                    .Replace("://github.com/", "://hub.fastgit.org/", StringComparison.OrdinalIgnoreCase);
            }

            return args;
        }

        private bool NoProgressOption(string[] args) => Array.FindIndex(args, i => i == "--progress") < 0 && Array.FindIndex(args, i => i == "-q") < 0;

        private int FindRepoUrlIndex(string[] args) => Array.FindIndex(args, i => i.StartsWith("http"));
    }
}
