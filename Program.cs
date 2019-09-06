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
using System.Buffers;
using ShellBind;
using PairStream;

namespace ProxyClient
{
	class Program
	{
		StreamWriter sw = new StreamWriter(Console.Out)
		StreamWriter sr = new StreamReader(Console.In)
		ShellSocket SS = new ShellSocket("ls", "-lah");
		Stream S = SS.GetPair();
		
		BindStreams (P, S);
		SS.Start();
	}
}
