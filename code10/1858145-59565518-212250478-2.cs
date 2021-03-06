 namespace bot.Core.Commands
 {
    public class Kick : ModuleBase<SocketCommandContext>
    {
        [Command("kick"), Summary("")]
        public async Task kick(IGuildUser user, [Remainder] string reason = "no reason")
        {
            user.KickAsync(reason);
        }
    }
 }
Otherwise, in a command such as:
"$kick @Username Sending NSFW Pics"
Everything after "Sending" would be considered as extra parameters and not part of `reason`, so the command would fail since it only accepts two parameters. Adding `[Remainder]` tells the command to look at everything that is typed afterwards as part of the same parameter.
That said, the command should word if you don't specify a reason. Is this true? And have you tried kicking without recording a reason? (Just `user.KickAsync()`)
