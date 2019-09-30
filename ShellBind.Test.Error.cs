/* Copyright [2019] RISHIKESHAN LAVAKUMAR <github-public [at] ris.fi>
   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at
http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 */


using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Rishi.ShellBind;
using Rishi.PairStream;
using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.RuntimeInformation;

namespace ProxyClient
{
		class Program_Error
		{
				static int Main(string[] args){
						ShellSocket SS;
#if !(NETSTANDARD2_0 || NETCOREAPP2_0 || NETCOREAPP2_1 || NETCOREAPP2_2)
						if ( IsOSPlatform(OSPlatform.Linux) ||  IsOSPlatform(OSPlatform.FreeBSD) ||  IsOSPlatform(OSPlatform.OSX))
#else
								if ( IsOSPlatform(OSPlatform.Linux) ||  IsOSPlatform(OSPlatform.OSX))
#endif
										SS = new ShellSocket("bash -c \"yes hi 1>&2\"", "hi");
								else
										SS = new ShellSocket("cmd /c \"echo hi 1>&2\"", "");
						System.Console.WriteLine("Starting...");
						SS.RedirectErrorsToConsole=true;
						SS.Start();
						Stream S = SS.GetStream();
						System.Console.WriteLine("ShellSocket created...");
						pair P = new pair(new StreamReader(Console.OpenStandardInput()), new StreamWriter(Console.OpenStandardOutput()));
						System.Console.WriteLine("Pair created...");
						System.Console.WriteLine("{0}", new StreamWriter(Console.OpenStandardOutput()));
						System.Console.WriteLine("Binding...");
						System.Console.WriteLine("P:{0} S:{1}", P, S);
						Rishi.PairStream.pair.BindStreams(P, S);
						return 0;
				}
		}
}

