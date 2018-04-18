using Android.App;
using Android.Widget;
using Android.Views;
using Android.OS;
using System;
using System.IO;
using System.Timers;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Support.V4.App;
using Android.Support.V4.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Util;
using v7Toolbar = Android.Support.V7.Widget.Toolbar;
using Newtonsoft.Json;

namespace OmniPlace
{
	[Activity(Label = "OmniPlace", MainLauncher = true, Theme = "@style/Blue")]
	public class MainActivity : AppCompatActivity
	{


		#region variable
		private DrawerLayout drawerLayout;
		private NavigationView navView;
		private IMenu menu;
		private static TextView console;
		private static DisplayMetrics metrics;
		public OmniPlaceEnvironment env;
		public static int DeviceDpHeight { get; set; }
		public static int DeviceDpWidth { get; set; }
		public static int DevicePxHeight { get; set; }
		public static int DevicePxWidth { get; set; }
		#endregion

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.layout_Main);
			metrics = Resources.DisplayMetrics;
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			navView = FindViewById<NavigationView>(Resource.Id.nav_view);
			menu = navView.Menu;
			env = new OmniPlaceEnvironment();
			DeviceDpWidth = ConvertPxToDp(metrics.WidthPixels);
			DeviceDpHeight = ConvertPxToDp(metrics.HeightPixels);
			DevicePxWidth = ConvertDpToPx(DeviceDpWidth);
			DevicePxHeight = ConvertDpToPx(DeviceDpHeight);
			console = FindViewById<TextView>(Resource.Id.mainActivity_txtConsole);



			env.initializeDB();


			var customtoolbar = FindViewById<v7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(customtoolbar);
			SupportActionBar.Title = "OmniPlace";
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);
			//SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);
		}

		public void updateMenuOptions()
		{

		}
		#region consoleLOG
		public static void consWrite(string message)
		{
			
			if (console.LineCount > 25)
			{
				console.Text = "";
				console.Text = console.Text + "\n" + message;
			}
			else
			{
				console.Text = console.Text + "\n" + message;
			}
		}
		#endregion
		#region ScreenSize
		public int ConvertPxToDp(float pixelValue)
		{
			var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
			return dp;
		}
		public int ConvertDpToPx(float dpValue)
		{
			var pix = ((dpValue) * Resources.DisplayMetrics.Density);
			return (int)pix;
		}
		#endregion
	}
}