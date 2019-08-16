using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Views.InputMethods;
using Debug = System.Diagnostics.Debug;

namespace RPGController
{
    [Activity(Label = "RPGController"
        , MainLauncher = true
        , Icon = "@drawable/icon"
        , Theme = "@style/Theme.Splash"
        , AlwaysRetainTaskState = true
        , LaunchMode = Android.Content.PM.LaunchMode.SingleInstance
        , ScreenOrientation = ScreenOrientation.FullUser
        , ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize | ConfigChanges.ScreenLayout)]
    public class Activity1 : Microsoft.Xna.Framework.AndroidGameActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            var g = new Game1(this);
            var view = (View)g.Services.GetService(typeof(View));
            SetContentView(view);

            //var inputMethodManager = Application.GetSystemService(Context.InputMethodService) as InputMethodManager;
            //Debug.Assert(inputMethodManager != null, nameof(inputMethodManager) + " != null");
            //inputMethodManager.ShowSoftInput(view, ShowFlags.Forced);
            //inputMethodManager.ToggleSoftInput(ShowFlags.Forced, HideSoftInputFlags.ImplicitOnly);
            g.Run();
        }
    }
}

