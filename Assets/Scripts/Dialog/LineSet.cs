
using System;
using System.Collections.Generic;
using UnityEngine;
using BranchEngine.Dialog;

namespace BranchEngine.Dialog {
	
	public class LineSet {
		
		
		public List<Line> setList = new List<Line>();
		
		public Line getLineAtIndex(int index){
			
			return setList[index];
			
		}
		
		public void setLineAtIndex(Line line, int index){
			
			setList.Insert(index, line);
		}
		
		public void replaceLineAtIndex(Line line, int index){
			
			setList.RemoveAt(index);
			setList.Insert(index, line);
		}
		
		public Line LineWithId (int id){
			
			foreach(Line element in setList)
				
				if(element.id == id){
				return element;
			}
			return null;
			
		}
		
		
		public LineSet() {}
				
		
	}
}