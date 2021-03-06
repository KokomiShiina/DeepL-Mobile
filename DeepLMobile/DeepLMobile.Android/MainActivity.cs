﻿using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Essentials;

namespace Utosoft.DeepLMobile.Droid
{
    [Activity(Label = "DeepL", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadSelectedTextAsync();
            LoadApplication(new global::Utosoft.DeepLMobile.App());
        }

        /// <summary>
        /// Loads the selected text if app is launched by selection toolbar
        /// </summary>
        private async void LoadSelectedTextAsync()
        {
            var text = Intent!.GetStringExtra("selectedText");
            if (!string.IsNullOrWhiteSpace(text))
            {
                await Clipboard.SetTextAsync(text);
            }
        }

        ///
        /// <inheritdoc />
        ///
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}