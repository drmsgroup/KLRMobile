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
			LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}
	}
}