    public static IEnumerable<AutomationElement> FindInRawView(this AutomationElement root)
    {
        TreeWalker rawViewWalker = TreeWalker.RawViewWalker;
        Queue<AutomationElement> queue = new Queue<AutomationElement>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
           var element = queue.Dequeue();
           yield return element;
    
           var sibling = rawViewWalker.FindNextSibling(element);
           if (sibling != null)
           {
              queue.Enqueue(sibling);
           }
    
           var child = rawViewWalker.FindFirstChild(element);
           if (child != null)
           {
              queue.Enqueue(child);
           }
        }
    }
