    public class Label
    {
        public string Text{get;set;}
    }
    public interface Clickable
    {
        Click();
    }
    public interface Resizable
    {
        Resize();
    }
    public interface Dragable
    {
        Drag();
    }
    public interface ClickableDragable : Clickable, Draggable
    {
    }
    public interface ClickableResizable : Clickable, Resizable
    {
    }
    public interface ResizableDragable : Resizable, Draggable
    {
    }
    public interface ClickableDragableResizeable : Resizable, Clickable, Draggable
    {
    }
    public class ComlexLabel : Lable, ClickableDragableResizeable
    {
        Click();
        Drag();
        Resize();
    }
