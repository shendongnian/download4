    public class Drogon : MotherOfDragons
    {
        private String dragonsName;
        public override String DragonsName { get { return dragonsName; } }
        
        public void Change_WindowTitle(String name)
		{
			dragonsName = name;
		}
    }
