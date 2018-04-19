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
	class categoryAdapter :BaseAdapter
	{
		public categoryAdapter(Activity context, List<category> db)
		{
			this.context = context;
			items = db;
		}
		private List<category> items;
		private Activity context;

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
			View row = context.LayoutInflater.Inflate(Resource.Layout.catView_mainLayout, parent, false);
			Button btn = row.FindViewById<Button>(Resource.Id.catView_expandBtn);

			btn.Text = items[position].name;

			return row;
		}
	}
}