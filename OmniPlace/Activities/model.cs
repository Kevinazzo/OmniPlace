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
using Newtonsoft.Json;

namespace OmniPlace.Model
{
	[JsonObject(MemberSerialization.OptIn)]
	public class site //el objeto principal de negocio,  un sitio
	{
		public site()
		{

		}

		[JsonProperty("id")]
		public string id { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("address")]
		public string address { get; set; }

		[JsonProperty("coord")]
		public string coord { get; set; }

		[JsonProperty("category")]
		public category Parent { get; set; }
	}
	[JsonObject]
	public class category //categoria para agrupar sitios, todo sitio tiene una categoria padre
	{
		public category()
		{

		}
		[JsonProperty("id")]
		public string id { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("parentCategory")]
		public category parent_category { get; set; }

		[JsonProperty("imgPath")]
		public string imgPaht { get; set; }

		[JsonProperty("child_sites")]
		public List<site> child_sites = new List<site>();

		[JsonProperty("child_cat")]
		public List<category> child_cat = new List<category>();
	}


	//public class siteList
	//{
	//	[JsonProperty("site")]
	//	public site site { get; set; }
	//}
	//public class categoryList
	//{
	//	[JsonProperty("category")]
	//	public category category { get; set; }
	//}
}