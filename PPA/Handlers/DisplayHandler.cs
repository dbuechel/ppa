﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Enums;
using CefSharp.Structs;

namespace PPA.Handlers
{
	internal class DisplayHandler : IDisplayHandler
	{
		private readonly Form form;
		private readonly HttpClient httpClient;

		internal DisplayHandler(Form form)
		{
			this.form = form;
			this.httpClient = new HttpClient();
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
			var request = new HttpRequestMessage(HttpMethod.Get, urls.First());
			var response = httpClient.SendAsync(request).ContinueWith(task =>
			{
				if (task.IsCompleted && task.Result.IsSuccessStatusCode)
				{
					task.Result.Content.ReadAsStreamAsync().ContinueWith(stream =>
					{
						if (stream.IsCompleted)
						{
							form.Invoke(new Action(() =>
							{
								try
								{
									form.Icon = new Icon(stream.Result);
								}
								catch
								{
								}
							}));
						}
					});
				}
			});
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
