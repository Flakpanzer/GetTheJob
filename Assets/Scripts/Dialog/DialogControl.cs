using UnityEngine;
using System.Collections;

namespace BranchEngine.Dialog {

	public static class DialogControl {
	
		
		private static DialogScript activeScript;
		
		public static void setInactive (){
			activeScript = null;
		}
		
		public static void setActive (DialogScript script){
			
			if(activeScript != null){
				activeScript = script;
			} else {	
				Debug.LogError("There's already an active script. Deactivate first");
			}
		}
		
		public static DialogScript getActiveScript () {
			return activeScript;
		}
		
	}
}	