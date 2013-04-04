
using System;
using System.Collections.Generic;
using UnityEngine;

namespace BranchEngine.Dialog {
	
	public class AnswerSet {
	
	
		public List<Answer> setList = new List<Answer>();
	
	
	
		//Getter, setter y reemplazador
		public Answer SetAnswerAtIndex(int index){
		
			return setList[index];
		
		}
	
		public void SetAnswerAtIndex(Answer answer, int index){
		
			setList.Insert(index, answer);
		}
	
		public void ReplaceAnswerAtIndex(Answer answer, int index){
		
			setList.RemoveAt(index);
			setList.Insert(index, answer);
		}
		
		
		public void CopyMultipleAnswerAtIndex(AnswerSet toAnswerSet, int[] index){
			
			for(int i = 0; i < index.Length; i++){
				toAnswerSet.setList.Add(this.setList[index[i]]);
			}
		}
		
		public void CopyAnswerSetAtIndex(AnswerSet answerSet, int index){
			
			this.setList.Add(answerSet.setList[index-1]);	
			
		}
		
		
		public AnswerSet() {}
		
	
		
		
		
	}
	
}

