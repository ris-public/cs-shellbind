
using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Buffers;
using PairStream;


namespace ShellBind {
	class ShellSocket{

		protected StreamWriter A;
		protected StreamReader B;
		protected Process Proc = new Process();
		protected string Command;
		protected string Args;
		public string Unbuffer;
		public string Unbuffer_Args;

		public ShellSocket(string Command, string Args){
			this.Proc = new Process();
			this.Command=Command;
			this.Args=Args;
			Unbuffer = "stdbuf";
			Unbuffer_Args="-i0 -o0";

		}
		public ShellSocket(string Command, string Args, string Unbuffer_Command, string Unbuffer_Args){
			this.Proc = new Process();
			this.Command=Command;
			this.Args=Args;
			this.Unbuffer = Unbuffer_Command;
			this.Unbuffer_Args=Unbuffer_Args;

		}
		public void Start(){

			this.Proc.StartInfo.FileName=$"{Unbuffer}";
			this.Proc.StartInfo.UseShellExecute = false;
			this.Proc.StartInfo.RedirectStandardOutput = true;
			Proc.StartInfo.Arguments=$"{Unbuffer_Args} {Command} {Args}";
			SetColour(5,0);
			System.Console.Error.WriteLine(Proc.StartInfo.FileName + " " + Proc.StartInfo.Arguments);
			ResetColour();
			Proc.StartInfo.RedirectStandardInput=true;
			Proc.Start();

			A = Proc.StandardInput;
			B = Proc.StandardOutput;
		}

		public Stream GetStream(){
			return new pair(B,A);
		}
		public void Kill(){
			Proc.Kill();
		}
		public void Close(){
			Proc.Close();
		}
		public void WaitForExit(){
			Proc.WaitForExit();
		}

		private static void SetColour(int fg, int bg){
			System.Console.Error.WriteLine($"\u001b[1;3{fg}m");
			System.Console.Error.WriteLine($"\u001b[4{bg}m");
		}
		private static void ResetColour(){
			System.Console.Error.WriteLine("\u001b[39m");
			System.Console.Error.WriteLine("\u001b[49m");
		}
	}
}
