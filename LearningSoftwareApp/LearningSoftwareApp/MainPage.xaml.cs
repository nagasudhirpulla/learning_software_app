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
        public MainPage()
        {
            InitializeComponent();
            LoadWebsite();
        }
        
        private void Button_Clicked(object sender, EventArgs e)
        {
            LoadWebsite();
        }

        private void Reload_Clicked(object sender, EventArgs e)
        {
            WebPage.Reload();
        }

        private void LoadWebsite()
        {
            WebPage.Source = "https://nagasudhir.blogspot.com";
        }

        private void Youtube_Clicked(object sender, EventArgs e)
        {
            //Device.OpenUri(new Uri("https://www.youtube.com/@learningsoftwareskills"));
            Launcher.OpenAsync(new Uri("https://www.youtube.com/@learningsoftwareskills"));
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
