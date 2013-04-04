using UnityEngine;
using System.Collections;
using BranchEngine.Dialog;
using BranchEngine.UI;
using BranchEngine.UI.Elements.Windows;
using BranchEngine.UI.Elements.Dialogs;
using BranchEngine.UI.Panels;
using Assets.Scripts.UI.Elements.Dialogs;
using System;



public abstract class DialogScript : MonoBehaviour {

    private UIWindow answersWindow;

    private UIWindow dialogWindow;

    private DialogBox dialogBox = new DialogBox
    {
        Height = 100,
        Width = 1000,
        DialogText = ""
    };

    private DialogOptions answersBox = new DialogOptions
    {
        Height = 200,
        Width = 1000
    };

	//carga las lineas
	void Start () {
		LoadElements ();
        InitilizeUI ();
	}
	
	//Flags
	private int flow = 0;

    private void InitilizeUI()
    {
        Debug.Log("Initializing UI");

        #region Dialog window initialize

        this.dialogWindow = new UIWindow
        {
            Title = "Dialog",
            Padding = 5,
            Autosize = true
        };

        this.dialogWindow.AddChild(this.dialogBox);

        var dialogContainer = new CustomAlignmentContainer();
        dialogContainer.AddChild(this.dialogWindow);

        UIManager.GetInstance().RegisterComponent(dialogContainer);

        #endregion

        #region Answers window initialize

        this.answersWindow = new UIWindow
        {
            Title = "Dialog Options",
            Padding = 5,
            Autosize = true
        };

        this.answersWindow.AddChild(this.answersBox);

        var answersContainer = new CenteredContainerPanel();
        answersContainer.AddChild(this.answersWindow);

        UIManager.GetInstance().RegisterComponent(answersContainer);

        #endregion
    }

	//Secuencia de switches
	public abstract void ExecuteOrder();
	
	//Carga lines y answers
	public abstract void LoadElements ();
		
	//Controlador de flow
	public void SetFlow (int flowNumber){
		Debug.Log("Set flow: " + flowNumber.ToString());

		//cambia el número de flujo y ejecuta la órden acorde
		this.flow = flowNumber;
		this.ExecuteOrder();
		
		
		/*/Activa y desactiva el script
		if(flowNumber == 0 && DialogControl.getActiveScript() == this){
			DialogControl.setInactive();
		}
		
		if(flowNumber != 0 && DialogControl.getActiveScript() == null){
			DialogControl.setActive(this);
		}
		
		if(flowNumber != 0 && DialogControl.getActiveScript() != null && DialogControl.getActiveScript() != this){
			Debug.LogError("There's already an active DialogScript");
			this.flow = 0;
		}*/
		
	}
	
	public int getFlow () {
		return flow;
	}
	
	//ORDENES PREDETERMINADAS
	public void SayLine (Line line){
        //este método debería mostrar en pantalla el line.text y la line.image
        //cada linea nueva que se ejecuta sobreescribe la vieja (nunca se superponen 2 lineas)
        this.dialogBox.DialogText = line.text;
	}
	
	public void AskForAnswer(AnswerSet answerSet){
		//este método muestra en pantalla los botones derivados de los elementos
		//tipo Answer que estan en la lista answerSet.setList
		//estos elementos tienen answer.text y answer.image que es la que se muestra
		//cuando el mouse pasa por encima del botón. Esto ultimo se puede hacer con un tooltip
		
		//cuando se cliquea un boton de Answer, se ejecuta DialogControl.activeScript.SetFlow(answer.order);
		//es decir que el flow del DialogScript se mueve a donde corresponda por la respuesta seleccionada
        this.answersBox.ClearOptions();
        foreach(var option in answerSet.setList)
        {
            Action<Answer> createAnswer = (Answer answer) =>
            {
                this.answersBox.AddOption(answer.text, () =>
                {
                    Debug.Log(answer.text);
                    this.SetFlow(answer.order);
                });
            };

            createAnswer(option);
        }
	}
	
	public void AskForEndConversation(){
		//este método cambia el botón de continuar por el de finalizar conversación.
		//al apretarse este botón hace lo mismo que el método EndConversation
        this.answersBox.ClearOptions();
        this.answersBox.AddOption("END >>>", () => this.EndConversation());
    }
	
	public void EndConversation(){
        //termina automáticamente la conversación
        //DialogControl.activeScript.SetFlow(0)
        //También limpia y oculta el display
        this.answersWindow.Destroy();
        this.dialogWindow.Destroy();
	}
	
	public void AskForContinue(int flow){
        //el boton de continuar, si es cliqueado, hace DialogControl.activeScript.SetFlow(flow);
        //es decir que mueve el flujo de la conversación al numero dado por parámetro.
        this.answersBox.ClearOptions();
        this.answersBox.AddOption("Continue >>>", () => this.SetFlow(flow));
	}
	
	
	
}
