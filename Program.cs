/*
 * Created by SharpDevelop.
 * User: jgustafson
 * Date: 3/23/2017
 * Time: 4:48 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace DeepFileFind
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			var process = Process.GetCurrentProcess(); // Or whatever method you are using
			string fullPath = process.MainModule.FileName;
			foreach (string s in args) {
				try {
					if (!fullPath.ToLower().EndsWith(s) && !fullPath.ToLower().EndsWith(s+".exe")) {  // add .exe in case was run with Windows
						MainForm.startup_path = s;
						break;
					}
				}
				catch {}
			}
			Application.Run(new MainForm());
		}
		
	}
}
