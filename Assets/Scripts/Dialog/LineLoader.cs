using UnityEngine;
using System.Collections;
using System.Xml;

namespace BranchEngine.Dialog {
	
	
	
	public class LineLoader {
			
			
		
		private XmlDocument database;
		
		//El constructor importa el xml
		public LineLoader () {
			database = new XmlDocument();
			database.Load("Assets/Scripts/Dialog/GetTheJobDialog.xml");
		}
		
		public Line LoadLine (string conversation, int id) {
			
			Line line;
			
			XmlNodeList conversationLine = null;
			XmlNodeList root = database.GetElementsByTagName("ROOT");
			XmlNodeList lines = ((XmlElement)root[0]).GetElementsByTagName("Lines");
			XmlNodeList lineSet = ((XmlElement)lines[0]).GetElementsByTagName("LineSet");
			
			foreach (XmlElement element in lineSet){
				

				if(element.GetAttribute("conversation").Equals(conversation)){
					conversationLine = element.GetElementsByTagName("Line");
					//Debug.Log ("Comparation matched with: " + conversation);
				}
						
			}
			
			if(conversationLine.Count == 0){
				//Debug.Log ("No lines for comparison");	
			}
			
			foreach(XmlElement element in conversationLine){
				
				int idComp = int.Parse(element.GetAttribute("id"));
				if(id == idComp){
					//Debug.Log ("Id matched with: " + idComp.ToString());
					line = new Line();
					line.image = getImage(element.GetAttribute("image"));
					line.text = element.GetAttribute("text");
					line.audio = getAudio(element.GetAttribute("audio"));
					line.id = id;
					//Debug.Log ("line loaded with id: " + line.id.ToString() + " text: " + line.text); // + " image: " + line.image.ToString() + " and audio: " + line.audio.ToString());
					return line;
					}
				}
			//Debug.Log ("No lines matched. closing");
			return null;
		}	
		
		public LineSet LoadLineSet (string conversation, int start, int end){
			
			LineSet lineSet = new LineSet();
			
			for(int i = start ; i <= end; i++){
				
				Line line = LoadLine(conversation, i);
				lineSet.setList.Add (line);
					
			}
			return lineSet;
				
		}		
			
		public Texture2D getImage (string imageString){
			Texture2D image = (Texture2D)Resources.Load("/Images/Faces/"+imageString+".jpg");
			//Debug.Log("Image: " + imageString + " loaded.");
			return image;	
		}
			
		
		public AudioClip getAudio (string audioString){
			AudioClip audio = (AudioClip)Resources.Load ("/Audio/Dialog/"+audioString+".mp3");
			//Debug.Log("audio: " + audioString + " loaded.");
			return audio;	
		}
		
		
		
	}	
		
}
	
