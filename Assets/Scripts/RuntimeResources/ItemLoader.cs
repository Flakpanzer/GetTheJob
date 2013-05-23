using UnityEngine;
using System.Collections;
using System.Xml;
using BranchEngine.Game;

namespace BranchEngine.RuntimeResources {
	
	public class ItemLoader : Loader {
		
		private XmlDocument database;
		
		public ItemLoader () {
			
			database = new XmlDocument();
			database.Load("Assets/Scripts/Data/ItemDB.xml");
			
		}
		
		public ItemData LoadItem (int id){
			
			ItemData item = new ItemData();
			XmlNodeList root = database.GetElementsByTagName("ROOT");
			XmlNodeList items = ((XmlElement)root[0]).GetElementsByTagName("Item");
			
			foreach (XmlElement element in items) {
				
				if(int.Parse(element.GetAttribute("id")) == id){
					
					item.Id = id;
					item.Image = LoadImage(element.GetAttribute("image"), "Items");
					item.Thumb = LoadImage(element.GetAttribute("thumb"), "Items");
					item.Name = element.GetAttribute("name");
				}
				
			}
			
			return item;
		}
	
	}
}