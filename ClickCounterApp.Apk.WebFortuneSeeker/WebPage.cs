using Xamarin.Forms;

namespace ClickCounterApp.Apk.WebFortuneSeeker
{
    public class WebPage : ContentPage
    {
        public WebPage()
        {
            WebView browser = new WebView();
            browser.Source = "http://www.thecomputerscientist.net/FortuneSeeker/";
            Content = browser;
        }
    }
}