    public class MyCustomFiler : JobFilterAttribute, IElectStateFilter
    {
        public void IElectStateFilter.OnStateElection(ElectStateContext context)
        {
            var failedState = context.CandidateState as FailedState;
            if (failedState != null)
            {
                //Job has filed
                //Job ID => context.BackgroundJob.Id,
                //Exception =>failedState.Exception
            }
        }
    }
