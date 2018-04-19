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
		private ListView catListView;
		private categoryAdapter catListAdapter;
		private IMenu menu;
		private static TextView console;
		private static DisplayMetrics metrics;
		private FloatingActionButton floatBtn;
		public static OmniPlaceEnvironment env;
		public static int DeviceDpHeight { get; set; }
		public static int DeviceDpWidth { get; set; }
		public static int DevicePxHeight { get; set; }
		public static int DevicePxWidth { get; set; }
		#endregion

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main_layout);

			#region varDeclaration
			metrics = Resources.DisplayMetrics;
			drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
			navView = FindViewById<NavigationView>(Resource.Id.nav_view);
			menu = navView.Menu;
			//floatBtn = FindViewById<FloatingActionButton>(Resource.Id.f)
			env = new OmniPlaceEnvironment();
			DeviceDpWidth = ConvertPxToDp(metrics.WidthPixels);
			DeviceDpHeight = ConvertPxToDp(metrics.HeightPixels);
			DevicePxWidth = ConvertDpToPx(DeviceDpWidth);
			DevicePxHeight = ConvertDpToPx(DeviceDpHeight);
			console = FindViewById<TextView>(Resource.Id.mainActivity_txtConsole);
			catListView = FindViewById<ListView>(Resource.Id.catView_ListView);
			catListAdapter = new categoryAdapter(this, env.getDB());
			#endregion

			env.initializeDB();
			catListView.Adapter = catListAdapter;

			#region toolbar config
			var customtoolbar = FindViewById<v7Toolbar>(Resource.Id.toolbar);
			SetSupportActionBar(customtoolbar);
			SupportActionBar.Title = "OmniPlace";
			SupportActionBar.SetDisplayHomeAsUpEnabled(true);
			SupportActionBar.SetHomeButtonEnabled(true);
			//SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp); //open side menu image button
			#endregion
			#region MenuActions
			//control de acciones del menu, swapear entre fragments
			navView.NavigationItemSelected += (sender, e) =>
			{
				Android.App.Fragment fragment = null;

				switch (e.MenuItem.ItemId)
				{
					#region codigoViejo
					//case Resource.Id.nav_campSites:
					//	SupportActionBar.Title = "CampApp - Sitios de Acampar";
					//	logo_container.SetImageResource(0);
					//	fragment = new frg_campingSites();
					//	break;
					//case Resource.Id.nav_climbSites:
					//	SupportActionBar.Title = "CampApp - Rutas de escalada";
					//	logo_container.SetImageResource(0);
					//	fragment = new frg_climbingSites();
					//	break;
					//case Resource.Id.nav_Restaurants:
					//	SupportActionBar.Title = "CampApp - Restaurantes";
					//	logo_container.SetImageResource(0);
					//	fragment = new frg_restaurants();
					//	break;
					//case Resource.Id.nav_uber:
					//	try
					//	{
					//		var uri = Android.Net.Uri.Parse("market://details?id=com.ubercab");
					//		Intent intent = new Intent(Intent.ActionView, uri);
					//		intent.AddFlags(ActivityFlags.NewTask);
					//		BaseContext.StartActivity(intent);
					//	}
					//	catch (System.Exception)
					//	{
					//		var uri = Android.Net.Uri.Parse("https://play.google.com/store/apps/details?id=com.ubercab");
					//		Intent intent = new Intent(Intent.ActionView, uri);
					//		intent.AddFlags(ActivityFlags.NewTask);
					//		BaseContext.StartActivity(intent);
					//	}
					//	break;
					#endregion
					case Resource.Id.menu_addSite:
						break;
					case Resource.Id.menu_addCat:
						break;
					default:
						Toast.MakeText(this, "No hay aplicacion de uber", ToastLength.Short).Show();
						break;
				}
				e.MenuItem.SetChecked(true);
				//react to click here and swap fragments or navigate
				if (fragment != null)
				{
					FragmentManager.BeginTransaction().Replace(Resource.Id.fragment_container, fragment).Commit();
				}
				drawerLayout.CloseDrawers();
			};


		}
		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Android.Resource.Id.Home:
					drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
					return true;
			}
			return base.OnOptionsItemSelected(item);
		}
		#endregion
		//public void updateMenuOptions(IMenu menu, string[] catNames)
		//{
		//	IMenuItem nuevo;
		//	catNames = new string[] { "Añadir Categoria, Añadir Nuevo Sitio" };
		//	foreach (var name in catNames)
		//	{
		//		nuevo.ItemId=
		//	}
		//}
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