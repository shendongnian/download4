csharp
public async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
{
    var activity = turnContext.Activity;
    var dc = await Dialogs.CreateContextAsync(turnContext);
    // Execute on incoming messages
    if (activity.Type == ActivityTypes.Message)
    {
        if (string.IsNullOrWhiteSpace(activity.Text) && activity.Value != null)
        {
            activity.Text = JsonConvert.SerializeObject(activity.Value);
        }
    }
    var dialogResult = await dc.ContinueDialogAsync();
    // Execute based on different situations within a Dialog. See BasicBot for examples:
    // https://github.com/Microsoft/BotBuilder-Samples/blob/master/samples/csharp_dotnetcore/13.basic-bot/BasicBot.cs#L112
    if (!dc.Context.Responded)
    {
        switch (dialogResult.Status)
        {
            case DialogTurnStatus.Empty:
            case DialogTurnStatus.Waiting:
                break;
            case DialogTurnStatus.Complete:
                await dc.EndDialogAsync();
                break;
            default:
                await dc.CancelAllDialogsAsync();
                break;
        }
    }
    // Here's where we show welcome messages
    if (activity.Type == ActivityTypes.ConversationUpdate)
    {
        if (activity.MembersAdded != null)
        {
            foreach (var member in activity.MembersAdded)
            {
                // This makes sure the new user isn't the bot. It's a little different from some of the samples
                // because code has changed in the SDK and emulator
                if (member.Name != "Bot" && member.Name != null)
                {
                    await SendWelcomeMessageAsync(turnContext, cancellationToken);
                    await dc.BeginDialogAsync(ReservationDialog, cancellationToken);
                }
            }
        }
    }
    // Be sure you're saving ConversationState at the end since DialogContext derives from it
    await _conversationState.SaveChangesAsync(turnContext);
}
