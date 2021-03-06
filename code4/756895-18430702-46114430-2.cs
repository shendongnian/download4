    public static class UIElementExtension {
        public static void AttachActionMessage(this DependancyObject control, string eventName, string methodName, object parameter) {
            var action = new ActionMessage();
            action.MethodName = methodName;
            action.Parameters.Add(new Parameter { Value = parameter });
            var trigger = new System.Windows.Interactivity.EventTrigger();
            trigger.EventName = eventName;
            trigger.SourceObject = control;
            trigger.Actions.Add(action);
            Interaction.GetTriggers(control).Add(trigger);
        }
    }
