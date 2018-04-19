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
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OmniPlace.Model;


namespace OmniPlace
{
	/// <summary>
	/// Clase para manejar el esquema de la base de datos
	/// </summary>
	public class OmniPlaceEnvironment
	{
		private string rootDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Directiorio Raiz
		private string dbFileDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "/db.json"; //Ruta del Archivo
		private FileStream fs;
		private dbo db = new dbo();

		#region customMethodClass
		/// <summary>
		/// herencia para añadir metodos personalizados
		/// </summary>
		public class dbo : List<category>
		{
			/// <summary>
			/// añadir categoria al grupo raiz
			/// </summary>
			/// <param name="cat">categoria a añadir</param>
			public void addCategory(category cat)
			{
				// "auto_increment"
				cat.id = (Count + 1.ToString());
				Add(cat);
			}

			/// <summary>
			/// añadir categoria hija
			/// </summary>
			/// <param name="newCat">categoria a agregar</param>
			/// <param name="parent">categoria padre</param>
			//public void addCategory(category newCat, category parent)
			//{
			//	//padre de la categoria padre (si es que existe)
			//	var superParent = parent.parent_category;
			//	parent.child_cat.Add(newCat);
			//}
			public void addSite(site site, category parent)
			{
				Find(a=>a==parent).child_sites.Add(site);
			}
		}
		#endregion
		#region fileVerification
		/// <summary>
		/// Verifica si el archivo existe en el directorio
		/// </summary>
		/// <returns> true si el archivo existe, false si no</returns>

		public void initializeDB()
		{
			if (File.Exists(dbFileDir))
			{
				readFile();
			}
			else
			{
				sampleDB();
				writeFile();
			}
		}
		/// <summary>
		/// Crea una db de ejemplo
		/// </summary>
		private void sampleDB()
		{
			category nuevocat = new category() { id = "1", name = "Sitios Favoritos" };
			site nuevo = new site()
			{
				id = "1",
				name = "nuevo Lugar",
				address = "direccion de prueba",
				coord = "",
				Parent = nuevocat
			};
			db.addCategory(nuevocat);
			db.addSite(nuevo, nuevocat);
		}
		/// <summary>
		/// escribe la base de datos que esta en memoria a un archivo
		/// </summary>
		private void writeFile()
		{
			string jsonText = JsonConvert.SerializeObject(db,Formatting.Indented, new JsonSerializerSettings{ PreserveReferencesHandling = PreserveReferencesHandling.Objects });
			try
			{
				using (fs = new FileStream(dbFileDir, FileMode.Create))
				{
					StreamWriter writer = new StreamWriter(fs);
					writer.WriteLine(jsonText);
					writer.Close();
				}
			}
			catch (Exception)
			{
				MainActivity.consWrite("archivo no creado");
				throw;
			}
			
		}

		/// <summary>
		/// lee el archivo para crear el entorno de base de datos en memoria
		/// </summary>
		private void readFile()
		{
			using(fs = new FileStream(dbFileDir, FileMode.Open))
			{
				StreamReader reader = new StreamReader(fs);
				
				string text = reader.ReadToEnd();
				var result = JsonConvert.DeserializeObject<List<category>>(text);
				db.AddRange(result);
			}
		}
		#endregion

		public dbo getDB()
		{
			return db;
		}
	}
}