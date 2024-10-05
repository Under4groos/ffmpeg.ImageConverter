#region hide

//Console.WriteLine();
//Console.WriteLine("-- Environment members --");

////  Invoke this sample with an arbitrary set of command line arguments.
//Console.WriteLine("CommandLine: {0}", Environment.CommandLine);

//string[] arguments = Environment.GetCommandLineArgs();
//Console.WriteLine("GetCommandLineArgs: {0}", String.Join(", ", arguments));

////  <-- Keep this information secure! -->
//Console.WriteLine("CurrentDirectory: {0}", Environment.CurrentDirectory);

//Console.WriteLine("ExitCode: {0}", Environment.ExitCode);

//Console.WriteLine("HasShutdownStarted: {0}", Environment.HasShutdownStarted);

////  <-- Keep this information secure! -->
//Console.WriteLine("MachineName: {0}", Environment.MachineName);

//Console.WriteLine("NewLine: {0}  first line{0}  second line{0}  third line",
//                      Environment.NewLine);

//Console.WriteLine("OSVersion: {0}", Environment.OSVersion.ToString());

//Console.WriteLine("StackTrace: '{0}'", Environment.StackTrace);

////  <-- Keep this information secure! -->
//Console.WriteLine("SystemDirectory: {0}", Environment.SystemDirectory);

//Console.WriteLine("TickCount: {0}", Environment.TickCount);

////  <-- Keep this information secure! -->
//Console.WriteLine("UserDomainName: {0}", Environment.UserDomainName);

//Console.WriteLine("UserInteractive: {0}", Environment.UserInteractive);

////  <-- Keep this information secure! -->
//Console.WriteLine("UserName: {0}", Environment.UserName);

//Console.WriteLine("Version: {0}", Environment.Version.ToString());

//Console.WriteLine("WorkingSet: {0}", Environment.WorkingSet);

//  No example for Exit(exitCode) because doing so would terminate this example.

//  <-- Keep this information secure! -->
//string query = "My system drive is %SystemDrive% and my system root is %SystemRoot%";
//string str = Environment.ExpandEnvironmentVariables(query);
//Console.WriteLine("ExpandEnvironmentVariables: {0}  ", str);

//Console.WriteLine("GetEnvironmentVariable: {0}  My temporary directory is",
//                       Environment.GetEnvironmentVariable("TEMP"));

//Console.WriteLine("GetEnvironmentVariables: ");
//IDictionary environmentVariables = Environment.GetEnvironmentVariables();

//foreach (DictionaryEntry item in environmentVariables)
//{
//    Console.WriteLine("  {0} = {1}", item.Key, item.Value);
//}
//foreach (DictionaryEntry item in environmentVariables)
//{
//    Console.WriteLine("  {0} = {1}", item.Key, item.Value);
//}

//Console.WriteLine("GetFolderPath: {0}",
//             Environment.GetFolderPath(Environment.SpecialFolder.System));

//string[] drives = Environment.GetLogicalDrives();
//Console.WriteLine("GetLogicalDrives: {0}", String.Join(", ", drives));

#endregion


using ffmpeg.ImageConverter.Provides;

string ffmpeg = PathEnvironment.GetEnvironmentVariableFind("ffmpeg");
ffmpeg = Path.Combine(ffmpeg, "ffmpeg.exe");
if (File.Exists(ffmpeg))
{

    Console.WriteLine(string.Join("\n", ffmpeg));
}
else
{

    Console.WriteLine($"Error: " + string.Join("\n", ffmpeg));
}

Console.ReadKey();