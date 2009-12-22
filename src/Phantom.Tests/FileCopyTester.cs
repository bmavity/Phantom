#region License

// Copyright Jeremy Skinner (http://www.jeremyskinner.co.uk)
// 
// Licensed under the Microsoft Public License. You may
// obtain a copy of the license at:
// 
// http://www.microsoft.com/opensource/licenses.mspx
// 
// By using this source code in any fashion, you are agreeing
// to be bound by the terms of the Microsoft Public License.
// 
// You must not remove this notice, or any other, from this software.
// 
// The latest version of this file can be found at http://github.com/JeremySkinner/Phantom

#endregion

namespace Phantom.Tests {
	using System.IO;
	using Core;
	using NUnit.Framework;

	[TestFixture]
	public class FileCopyTester {
		BuildRunner runner;
		PhantomOptions options;

		[SetUp]
		public void Setup() {
			runner = new BuildRunner();
			options = new PhantomOptions { File = "Scripts/FileCopy.boo" };
		}

		[Test]
		public void Copies_file_to_output_directory() {
			options.AddTarget("copyFile");
			runner.Execute(options);

			new FileInfo("copy_output/Test1.txt").Exists.ShouldBeTrue();
		}

		[Test]
		public void Copies_files_and_subdirectories_to_output_Directory() {
			options.AddTarget("copySubDirectories");
			runner.Execute(options);

			new FileInfo("copy_output/SubDirectory2/Test1.txt").Exists.ShouldBeTrue();
			new FileInfo("copy_output/SubDirectory3/Test2.txt").Exists.ShouldBeTrue();
			new FileInfo("copy_output/SubDirectory3/Test3.txt").Exists.ShouldBeTrue();
			new FileInfo("copy_output/SubDirectory3/SubDirectory4/Test4.txt").Exists.ShouldBeTrue();


		}
	}
}