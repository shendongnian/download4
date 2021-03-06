    void MyControl::OnFooChanged(...)
    {
        if (someNamedPart != null && someOtherNamedPart != null && ...)
        {
            // Do something to the named parts that are impacted by Foo when Foo changes
        }
    }
    void MyControl::FooChangedCallback(...)
    {
        // Called by WinRT when Foo changes
        OnFooChanged(...)
    }
    void MyControl::OnApplyTemplate(...)
    {
        // Theoretically, this can get called every time the consumer of
        // this custom control changes the template for this control.
        // If the control has named parts which must react to the properties
        // this control exposes, all that work must be done here EVERY TIME
        // a new template is applied.
        // Get and save named parts as local variables first
        OnFooChanged(...)
    }
