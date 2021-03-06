        public bool UpdateWorkflow(WorkflowState newWorkflowState, Item item)
        {
            Assert.ArgumentNotNull(newWorkflowState, "The new WorkflowState can not be null");
            Assert.ArgumentNotNull(item, "Item can not be null");
            bool successful = false;
            WorkflowState currentWorkflowState = GetWorkflowStateForItem(item);
            if (currentWorkflowState != newWorkflowState)
            {
                IWorkflow workflow = GetWorkflowOfItem(item);
                if (workflow != null)
                {
                    List<WorkflowCommand> applicableWorkflowCommands = workflow.GetCommands(currentWorkflowState.StateID).ToList();
                    foreach (var applicableWorkflowCommand in applicableWorkflowCommands)
                    {
                        Item commandItem = _database.GetItem(applicableWorkflowCommand.CommandID);
                        string nextStateId = commandItem["Next state"];
                        if (nextStateId == newWorkflowState.StateID)
                        {
                            WorkflowResult workflowResult = workflow.Execute(applicableWorkflowCommand.CommandID, item, "", false);
                            successful = workflowResult.Succeeded;
                            break;
                        }
                    }
                }
            }
            else
            {
                successful = true;
            }
            return successful;
        }
        public WorkflowState GetWorkflowStateForItem(Item item)
        {
            var workflow = GetWorkflowOfItem(item);
            return workflow != null ? workflow.GetState(item) : null;
        }
        public IWorkflow GetWorkflowOfItem(Item item)
        {
            return _database.WorkflowProvider.GetWorkflow(item);
        }
        private Database _database
        {
            get
            {
                return Sitecore.Data.Database.GetDatabase("master");
            }
        }
