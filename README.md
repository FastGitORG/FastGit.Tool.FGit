# FastGit.Tool.FGit

[![NuGet][main-nuget-badge]][main-nuget]

[main-nuget]: https://www.nuget.org/packages/fgit/
[main-nuget-badge]: https://img.shields.io/nuget/v/fgit.svg?style=flat-square&label=nuget

🔧 A C#-written tool to do git operation with fastgit easily

## Installation

Download and install the [.NET Core 2.1 SDK](https://www.microsoft.com/net/download) or newer. Once installed, run the following command:

```bash
dotnet tool install -g fgit
```

## Usage

All commands and behaviors are exactly the same as the original git except for the `clone` command.

```bash
fgit clone https://github.com/FastGitORG/www
```
It will be replaced with the FastGit source.


## TODO

* [ ] using the FastGit source for `pull/push/submodule update` commands
