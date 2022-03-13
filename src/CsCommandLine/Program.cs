namespace CsCommandLine;

static partial class Program
{
  static partial void OnExecute(
      FileInfo  input
    , FileInfo? output
    )
  {
    Console.WriteLine($"input: {input}");
    Console.WriteLine($"output: {output}");
  }
}

