    public static void Initialize(Control control, DocumentContainer container, ErrorProvider provider)
    {
        if (control == null) return;
        
        dynamic c = control;       
        InitializeControl(c, container, provider);
    
        foreach (Control subControl in control.Controls)
            Initialize(subControl, container, provider);
    }
    
    public static void InitializeControl(ICustomControlWithText controlWithTextBase, DocumentContainer container, ErrorProvider provider)
    {
        controlWithTextBase.DocumentLoaded = true;
        controlWithTextBase.Initialize(container, provider);
    }
    
    public static void InitializeControl(CustomCheckbox custom, DocumentContainer container, ErrorProvider provider)
    {
        custom.DocumentLoaded = true;
        custom.Initialize(container);
    }
    
    public static void InitializeControl(object _, DocumentContainer container, ErrorProvider provider)
    {
        // do nothing if the control is neither a ICustomControlWithText nor a CustomCheckbox
    }
