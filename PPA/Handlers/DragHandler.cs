using System.Collections.Generic;
using CefSharp;
using CefSharp.Enums;

namespace PPA.Handlers
{
	internal class DragHandler : IDragHandler
	{
		public bool OnDragEnter(IWebBrowser chromiumWebBrowser, IBrowser browser, IDragData dragData, DragOperationsMask mask)
		{
			return true;
		}

		public void OnDraggableRegionsChanged(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IList<DraggableRegion> regions)
		{
		}
	}
}
