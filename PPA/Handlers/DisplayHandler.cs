using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Enums;
using CefSharp.Structs;

namespace PPA.Handlers
{
	internal class DisplayHandler : IDisplayHandler
	{
		private readonly Form form;

		internal DisplayHandler(Form form)
		{
			this.form = form;
		}

		public void OnAddressChanged(IWebBrowser chromiumWebBrowser, AddressChangedEventArgs addressChangedArgs)
		{
		}

		public bool OnAutoResize(IWebBrowser chromiumWebBrowser, IBrowser browser, CefSharp.Structs.Size newSize)
		{
			return false;
		}

		public bool OnConsoleMessage(IWebBrowser chromiumWebBrowser, ConsoleMessageEventArgs consoleMessageArgs)
		{
			return false;
		}

		public bool OnCursorChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IntPtr cursor, CursorType type, CursorInfo customCursorInfo)
		{
			return false;
		}

		public void OnFaviconUrlChange(IWebBrowser chromiumWebBrowser, IBrowser browser, IList<string> urls)
		{
		}

		public void OnFullscreenModeChange(IWebBrowser chromiumWebBrowser, IBrowser browser, bool fullscreen)
		{
		}

		public void OnLoadingProgressChange(IWebBrowser chromiumWebBrowser, IBrowser browser, double progress)
		{
			form.Invoke(new Action(() => form.Cursor = progress < 1.0 ? Cursors.AppStarting : Cursors.Default));
		}

		public void OnStatusMessage(IWebBrowser chromiumWebBrowser, StatusMessageEventArgs statusMessageArgs)
		{
		}

		public void OnTitleChanged(IWebBrowser chromiumWebBrowser, TitleChangedEventArgs titleChangedArgs)
		{
		}

		public bool OnTooltipChanged(IWebBrowser chromiumWebBrowser, ref string text)
		{
			return true;
		}
	}
}
