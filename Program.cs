using System;
using System.Text;
using System.IO;
using System.Diagnostics;


namespace ProxyClient{
		class Program
		{
				static void Main(string[] args)
				{
						Console.WriteLine("Hello World!");
						DTLSServer dtls = new DTLSServer("127.0.0.1", "10000", new byte[] {0xBA,0xA0});
						dtls.Unbuffer="stdbuf";
						dtls.Unbuffer_Args="-i0 -o0";
						dtls.Start();
						dtls.GetStream().Write(Encoding.Default.GetBytes("It's Working!"+Environment.NewLine));
						dtls.WaitForExit();
				}
		}
}
