using System;
using Xamarin.Forms;

namespace ClickCounterApp.Apk.WebFortuneSeeker
{
    public class App : Application // superclass new in 1.3
    {
        public App()
        {
            var tabs = new TabbedPage();
                        
            tabs.Children.Add(new WebPage {  });            

            MainPage = tabs;
        }
    }
}