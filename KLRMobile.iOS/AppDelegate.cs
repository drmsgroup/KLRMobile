using UIKit;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace KLRMobile
{
	[Register("AppDelegate")]
	public partial class AppDelegate : FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			// affects all UISwitch controls in the app
			UISwitch.Appearance.OnTintColor = UIColor.FromRGB(0x91, 0xCA, 0x47);
			Forms.SetFlags("Expander_Experimental");
			Forms.Init();

			Syncfusion.SfPdfViewer.XForms.iOS.SfPdfDocumentViewRenderer.Init();
			Syncfusion.SfRangeSlider.XForms.iOS.SfRangeSliderRenderer.Init();
			LoadApplication(new App());
			Syncfusion.XForms.iOS.Border.SfBorderRenderer.Init();
			Syncfusion.XForms.iOS.Buttons.SfButtonRenderer.Init();
			return base.FinishedLaunching(app, options);
		}
	}
}