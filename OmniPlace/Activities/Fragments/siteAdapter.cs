using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Lang;
using OmniPlace.Model;

namespace OmniPlace
{
	public class siteAdapter : BaseAdapter
	{
		public siteAdapter(Activity _contxt, List<site> db)
		{
			context = _contxt;items = db;
		}
		Activity context;
		List<site> items;

		public override int Count { get { return items.Count; } }

		public override Java.Lang.Object GetItem(int position)
		{
			return null;
		}

		public override long GetItemId(int position)
		{
			return long.Parse(items[position].id);
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View row = context.LayoutInflater.Inflate(Resource.Layout.siteView_Row,parent,false);
			TextView txt = row.FindViewById<TextView>(Resource.Id.siteView_Title);
			ImageButton imgBtn =row.FindViewById<ImageButton>(Resource.Id.siteView_locationBtn);
			return row;
		}
	}
}