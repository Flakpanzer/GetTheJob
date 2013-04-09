using UnityEngine;
using System.Collections;
using BranchEngine.Dialog;

public class KarlScript : DialogScript {
	
	
	//Flags
	
	bool gotTheBox = false;
	//bool interrupted = false;
	
	
	//Carga de elementos
	LineSet karl;
	AnswerSet billyFull;
	AnswerSet billy1 = new AnswerSet();
	AnswerSet billy2 = new AnswerSet();
	AnswerSet billy3 = new AnswerSet();
	AnswerSet billy4 = new AnswerSet();
	
	void Awake () {
		
		this.LoadElements ();
		
	}
	
	public override void LoadElements() {
		
		LineLoader lLoader = new LineLoader();
		AnswerLoader aLoader = new AnswerLoader();
		karl = lLoader.LoadLineSet ("Karl", 1, 27);
		billyFull = aLoader.LoadAnswerSet ("Karl", 1 ,12);

        this.billy1 = new AnswerSet();
        this.billy2 = new AnswerSet();
        this.billy3 = new AnswerSet();
        this.billy4 = new AnswerSet();

        billyFull.CopyMultipleAnswerAtIndex(billy1, new int[] {0,1,2});
		billyFull.CopyMultipleAnswerAtIndex(billy2, new int[] {3,4,5});
		billyFull.CopyMultipleAnswerAtIndex(billy3, new int[] {6,7,8});
		billyFull.CopyMultipleAnswerAtIndex(billy4, new int[] {9,10,11});
	}
	
	//-----
	
	

	//Arbol de diálogo
	public override void ExecuteOrder(){
		int control = this.getFlow();
		switch(control){
				
		case 0:
			EndConversation();
			break;
				
		case 1:
			SayLine(karl.LineWithId(1));
			AskForAnswer(billy1);
			break;
				
		case 2:
			SayLine(karl.LineWithId(2));
			AskForContinue(5);
			break;
			
		case 3:
			SayLine(karl.LineWithId(3));
			AskForContinue(5);
			break;
			
		case 4:
			SayLine (karl.LineWithId(4));
			AskForContinue(5);	
			break;
				
		case 5:
			SayLine (karl.LineWithId(5));
			AskForAnswer(billy2);
			break;
				
		case 6:
			SayLine (karl.LineWithId(6));
			AskForContinue(9);
			break;
				
		case 7:
			SayLine (karl.LineWithId(7));
			AskForContinue(9);
			break;
				
		case 8:
			SayLine (karl.LineWithId(8));
			AskForContinue(9);
			break;
				
		case 9:
			SayLine (karl.LineWithId(9));
			AskForAnswer(billy3);
			break;
				
		case 10:
			SayLine (karl.LineWithId(10));
			AskForContinue(13);
			break;
			
		case 11:
			SayLine (karl.LineWithId(11));
			AskForContinue(13);
			break;	
			
		case 12:
			SayLine (karl.LineWithId(12));
			AskForContinue(13);
			break;
			
		case 13:	
			SayLine (karl.LineWithId(13));
			AskForContinue(14);
			break;
			
		case 14:
			SayLine (karl.LineWithId(14));
			AskForAnswer(billy4);
			break;
				
		case 15:
			SayLine (karl.LineWithId(15));
			AskForContinue(18);
			break;
			
		case 16:
			SayLine (karl.LineWithId(16));
			AskForContinue(18);
			break;	
			
		case 17:
			SayLine (karl.LineWithId(17));
			AskForContinue(18);
			break;
				
		case 18:
			SayLine(karl.LineWithId(18));
			AskForContinue(19);
			break;
				
		case 19:
			SayLine(karl.LineWithId(19));
			AskForContinue ((!gotTheBox) ? 20 : 23 );
			break;
				
		case 20: //Didn't got the box
			SayLine(karl.LineWithId(20));
			AskForContinue(21);
			break;
				
		case 21: 
			SayLine(karl.LineWithId(21));
			AskForContinue(22);
			break;
			
		case 22:
			SayLine(karl.LineWithId(22));
			AskForEndConversation();
			//Didnt got the job: [GAME OVER]
			break;	
			
		case 23: 
			SayLine(karl.LineWithId(23));
			AskForContinue(24);
			break;
				
		case 24: 
			SayLine(karl.LineWithId(24));
			AskForContinue(25);
			break;
				
		case 25: 
			SayLine(karl.LineWithId(25));
			AskForContinue(26);
			break;
				
		case 26: 
			SayLine(karl.LineWithId(27));
			AskForEndConversation();
			//Got the job [YOU WIN]
			break;	
				
		}
	}
	
	
	
	
	
}
