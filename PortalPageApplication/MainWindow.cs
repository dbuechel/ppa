using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using PortalPageApplication.Handlers;

namespace PortalPageApplication
{
	public partial class MainWindow : Form
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			var url = ConfigurationManager.AppSettings["StartUrl"];
			var browser = new ChromiumWebBrowser(url)
			{
				Dock = DockStyle.Fill
			};

			browser.LoadError += Browser_LoadError;
			browser.DisplayHandler = new DisplayHandler(this);
			browser.MenuHandler = new ContextMenuHandler();
			browser.TitleChanged += Browser_TitleChanged;

			Height = Screen.PrimaryScreen.WorkingArea.Height;
			Location = new Point(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Top);
			Width = Screen.PrimaryScreen.WorkingArea.Width / 2;

			Controls.Add(browser);
		}

		private void Browser_TitleChanged(object sender, TitleChangedEventArgs e)
		{
			Invoke(new Action(() => Text = e.Title));
		}

		private void Browser_LoadError(object sender, LoadErrorEventArgs e)
		{
			e.Frame.LoadHtml($"<html><body>Failed to load '{e.FailedUrl}'!<br />{e.ErrorText} ({e.ErrorCode})</body></html>");
		}
	}
}
