using UnityEngine;
using System.Collections;

using System.Xml;

namespace BranchEngine.Dialog {
	
	
	
	public class AnswerLoader {
			
			
		
		private XmlDocument database;
		
		//El constructor importa el xml
		public AnswerLoader () {
			database = new XmlDocument();
			database.Load("Assets/Scripts/Dialog/GetTheJobDialog.xml");
		}
		
		public Answer LoadAnswer (string conversation, int id) {
			
			Answer answer;
			XmlNodeList conversationAnswer = null;
			XmlNodeList root = database.GetElementsByTagName("ROOT");
			XmlNodeList answers = ((XmlElement)root[0]).GetElementsByTagName("Answers");
			XmlNodeList answerSet = ((XmlElement)answers[0]).GetElementsByTagName("AnswerSet");
			
			foreach (XmlElement element in answerSet){
				
				if(element.GetAttribute("conversation").Equals(conversation)){
					conversationAnswer = element.GetElementsByTagName("Answer");
				}		
			}
			
			
			foreach(XmlElement element in conversationAnswer){
				
				int idComp = int.Parse(element.GetAttribute("id"));
				if(id == idComp){
					
					answer = new Answer();
					answer.id = id;
					answer.image = getImage(element.GetAttribute("image"));
					answer.text = element.GetAttribute("text");
					answer.order = int.Parse(element.GetAttribute("order"));
					//Debug.Log ("answer loaded with id: " + id.ToString() + " text: " + answer.text);// + " image: " + answer.image.ToString() + " and order: " + answer.order.ToString());
					return answer;
					}
				}
				return null;
		}	
		
		public AnswerSet LoadAnswerSet (string conversation, int start, int end){
			
			AnswerSet answerSet = new AnswerSet();
			
			for(int i = start ; i <= end; i++){
				
				Answer answer = LoadAnswer(conversation, i);
				answerSet.setList.Add (answer);
					
			}
			return answerSet;
				
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
	
