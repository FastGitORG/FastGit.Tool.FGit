using System;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace FastGit.Tool.FGit.Test
{
    public class ReorganizeArgsUnitTest
    {
        [Fact]
        public void replace_repo_url_correct_1()
        {
            // Arrange
            var executor = new Executor();
            var args = new[] { "clone", "https://github.com/FastGitORG/www" };

            // Act
            var result = executor.ReplaceRepoUrl(args);

            // Assert
            string.Join(' ', result).ShouldBe("clone https://hub.fastgit.org/FastGitORG/www");
        }

        [Fact]
        public void do_nothing_1()
        {
            // Arrange
            var executor = new Executor();
            var args = new[] { "clone", "https://hub.fastgit.org/FastGitORG/www" };

            // Act
            var result = executor.ReplaceRepoUrl(args);

            // Assert
            string.Join(' ', result).ShouldBe(string.Join(' ', args));
        }

        [Fact]
        public void do_nothing_2()
        {
            // Arrange
            var executor = new Executor();
            var args = new[] { "clone", "git@github.com/FastGitORG/www" };

            // Act
            var result = executor.ReplaceRepoUrl(args);

            // Assert
            string.Join(' ', result).ShouldBe(string.Join(' ', args));
        }

        [Fact]
        public void do_nothing_3()
        {
            // Arrange
            var executor = new Executor();
            var args = new[] { "--version" };

            // Act
            var result = executor.ReplaceRepoUrl(args);

            // Assert
            string.Join(' ', result).ShouldBe(string.Join(' ', args));
        }

        [Fact]
        public void set_progress_correct_1()
        {
            // Arrange
            var executor = new Executor();
            var args = new[] { "clone", "https://github.com/FastGitORG/www" };

            // Act
            var result = executor.SetProgressOption(args);

            // Assert
            string.Join(' ', result).ShouldBe("clone --progress https://github.com/FastGitORG/www");
        }

        [Fact]
        public void set_progress_correct_2()
        {
            // Arrange
            var executor = new Executor();
            var args = new[] { "clone", "-q", "https://github.com/FastGitORG/www" };

            // Act
            var result = executor.SetProgressOption(args);

            // Assert
            string.Join(' ', result).ShouldBe("clone -q https://github.com/FastGitORG/www");
        }

        [Fact]
        public void set_progress_correct_3()
        {
            // Arrange
            var executor = new Executor();
            var args = new[] { "clone", "-q", "-v", "--depth 1", "https://github.com/FastGitORG/www" };

            // Act
            var result = executor.SetProgressOption(args);

            // Assert
            string.Join(' ', result).ShouldBe("clone -q -v --depth 1 https://github.com/FastGitORG/www");
        }

        [Fact]
        public void set_progress_correct_4()
        {
            // Arrange
            var executor = new Executor();
            var args = new[] { "clone", "-v", "--depth 1", "https://github.com/FastGitORG/www" };

            // Act
            var result = executor.SetProgressOption(args);

            // Assert
            string.Join(' ', result).ShouldBe("clone --progress -v --depth 1 https://github.com/FastGitORG/www");
        }
    }
}
