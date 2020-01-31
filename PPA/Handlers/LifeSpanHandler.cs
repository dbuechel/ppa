﻿using CefSharp;

namespace PPA.Handlers
{
	internal class LifeSpanHandler : ILifeSpanHandler
	{
		public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
			return false;
		}

		public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
		{
		}

		public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
		{
			newBrowser = default(IWebBrowser);

			return true;
		}
	}
}
