using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace OmniPlace
{
	public class siteView_listExpander : Fragment
	{
		ListView listview;
		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);

			var customView = inflater.Inflate(Resource.Layout.catView_listView, container, false);
			return customView;
		}

		public override void OnStart()
		{
			base.OnStart();

			listview = View.FindViewById<ListView>(Resource.Id.catView_ListView);
			siteAdapter adapter = new categoryAdapter(Activity, MainActivity.env.getDB());
			listview.Adapter = adapter;
		}
	}
}