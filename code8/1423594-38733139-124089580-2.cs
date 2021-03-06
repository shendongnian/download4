       public bool ShouldQuit { get; }
       // put other return values or information
    }
    public static class MyProgram {
       // Doing this in advance requires the class to be immutable
       private static KeyActionResult _shouldNotQuit = new KeyActionResult(false);
       private static KeyActionResult _shouldQuit = new KeyActionResult(true);
       // Work up the vocabulary that you want to be able to use
       private static Action<KeyActionResult> KeepLoopingAfter(Action action) =>
          () => {
             action();
             return _shouldNotQuit;
          };
       
       private static Action<KeyActionResult> QuitAfter(Action action) =>
          () => {
             action();
             return _shouldQuit;
          };
       
       private Action<KeyActionResult> Quit() => () => _shouldQuit;
       private void DoSomethingComplicated() { /* whatever */ }
