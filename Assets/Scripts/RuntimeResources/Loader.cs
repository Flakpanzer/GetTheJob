using UnityEngine;
using System.Collections;

namespace BranchEngine.RuntimeResources {
	
	public class Loader {
		public Texture2D LoadImage (string name, string folder){
			
			Texture2D image;
			image = (Texture2D)Resources.Load ("Images/" + folder + "/" + name) as Texture2D;
			return image; 
		}
		
		public AudioClip LoadAudio (string name, string folder){
			
			AudioClip audio;
			
			//Debug.Log ("entered name: " + name + " and folder: " + folder);
			
			audio = (AudioClip)Resources.Load ("Audio/" + folder + "/" + name) as AudioClip;
			
			
			if(audio != null){
				//Debug.Log ("Some audio loaded");
			} else {
				//Debug.Log ("no audio loaded");
			}
			
			
			return audio;
		}
	}
}
