using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LearningSoftwareApp
{
    public partial class MainPage : ContentPage
    {
        private const string HomePageUrl = "https://nagasudhir.blogspot.com/2020/04/taming-python-table-of-contents.html";
        private const string YoutubeUrl = "https://www.youtube.com/@learningsoftwareskills";
        public MainPage()
        {
            InitializeComponent();
            LoadHomePage();
            WebPage.Navigating += (s, e) =>
            {
                // https://theconfuzedsourcecode.wordpress.com/2016/03/04/how-to-handle-xamarin-forms-webview-internal-navigations/
                if (!e.Url.Equals(HomePageUrl) && !e.Url.StartsWith($"{HomePageUrl}/?"))
                {
                    e.Cancel = true;
                    // https://learn.microsoft.com/en-us/xamarin/essentials/open-browser?tabs=android
                    _ = Browser.OpenAsync(e.Url, BrowserLaunchMode.SystemPreferred);
                }
            };
        }

        private void Reload_Clicked(object sender, EventArgs e)
        {
            WebPage.Reload();
        }

        private void LoadHomePage()
        {
            WebPage.Source = HomePageUrl;
        }

        private void Youtube_Clicked(object sender, EventArgs e)
        {
            //Device.OpenUri(new Uri(YoutubeUrl));
            Launcher.OpenAsync(new Uri(YoutubeUrl));
        }

        protected override bool OnBackButtonPressed()
        {
            if (WebPage.CanGoBack)
            {
                WebPage.GoBack();
                return true;
            }
            return base.OnBackButtonPressed();
        }

        //private void RefreshView_Refreshing(object sender, EventArgs e)
        //{
        //    WebPage.Reload();
        //    RefreshHost.IsRefreshing = false;
        //}
    }
}
