using System;
using System.IO;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace PPA
{
	public static class Program
	{
		[STAThread]
		public static void Main()
		{
			var settings = new CefSettings
			{
				CachePath = Path.Combine(Environment.ExpandEnvironmentVariables("%TEMP%"), Path.GetRandomFileName())
			};

			Cef.Initialize(settings, true);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainWindow());

			Cef.Shutdown();
		}
	}
}
