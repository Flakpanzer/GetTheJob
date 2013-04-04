namespace BranchEngine.UI.Elements.Dialogs
{
    class DialogBox : BaseUIElement
    {
        public string DialogText { get; set; }

        public override void DrawGUI(Context.DrawingContext context)
        {   
            // TODO: Draw image

            var textRect = context.Project(leftDisplacement: this.Height).Shrink(width: this.Height);
            textRect.ContainerHeight = this.Height;

            new UILabel { Text = this.DialogText }.DrawGUI(textRect);
        }
    }
}
