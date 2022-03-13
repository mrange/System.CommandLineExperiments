
using System.CommandLine;

namespace CsCommandLine;

static partial class Program
{
  static partial void OnExecute(
      FileInfo input
    , FileInfo? output
    );

  static void RootHandler(
      FileInfo input
    , FileInfo? output
    )
  {
    OnExecute(
      input
    , output
    );
  }

  public static int Main(string[] args)
  { 
    var root = new RootCommand("My sample console app powered by T4");

    // Option: input
    var opt_input = new Option<FileInfo>(name: "--input", description: "The input file")
      {
        IsRequired = true
      };
    root.AddOption(opt_input);
    // Option: output
    var opt_output = new Option<FileInfo?>(name: "--output", description: "The output file")
      {
        IsRequired = false
      };
    root.AddOption(opt_output);

    Action<FileInfo, FileInfo?> handler = RootHandler;
    root.SetHandler(
        handler
      , opt_input
      , opt_output
      );

    // To my understanding the handlers are synchronous meaning
    //  I don't see much point invoking the command handler has
    //  async.
    return root.Invoke(args);
  }
}

