using Android.App;
using Android.OS;

namespace ClickCounterApp.Apk.WebFortuneSeeker
{
    [Activity(Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity // superclass new in 1.3
    {
        protected override void OnCreate(Bundle bundle)
        {            
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App()); // method is new in 1.3
            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);
        }
    }
}

