csharp
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Security.Permissions;
using System.Threading.Tasks;
[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.Default | DebuggableAttribute.DebuggingModes.DisableOptimizations | DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints | DebuggableAttribute.DebuggingModes.EnableEditAndContinue)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("0.0.0.0")]
[module: UnverifiableCode]
internal class Program
{
    [CompilerGenerated]
    private sealed class <TestAsyncAwaitMethods>d__1 : IAsyncStateMachine
    {
        public int <>1__state;
        public AsyncVoidMethodBuilder <>t__builder;
        private TaskAwaiter<int> <>u__1;
        private void MoveNext()
        {
            int num = <>1__state;
            try
            {
                TaskAwaiter<int> awaiter;
                if (num != 0)
                {
                    awaiter = LongRunningMethod().GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <TestAsyncAwaitMethods>d__1 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter<int>);
                    num = (<>1__state = -1);
                }
                awaiter.GetResult();
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult();
        }
        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }
        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }
    [CompilerGenerated]
    private sealed class <LongRunningMethod>d__2 : IAsyncStateMachine
    {
        public int <>1__state;
        public AsyncTaskMethodBuilder<int> <>t__builder;
        private TaskAwaiter <>u__1;
        private void MoveNext()
        {
            int num = <>1__state;
            int result;
            try
            {
                TaskAwaiter awaiter;
                if (num != 0)
                {
                    Console.WriteLine("Starting Long Running method...");
                    awaiter = Task.Delay(5000).GetAwaiter();
                    if (!awaiter.IsCompleted)
                    {
                        num = (<>1__state = 0);
                        <>u__1 = awaiter;
                        <LongRunningMethod>d__2 stateMachine = this;
                        <>t__builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = <>u__1;
                    <>u__1 = default(TaskAwaiter);
                    num = (<>1__state = -1);
                }
                awaiter.GetResult();
                Console.WriteLine("End Long Running method...");
                result = 1;
            }
            catch (Exception exception)
            {
                <>1__state = -2;
                <>t__builder.SetException(exception);
                return;
            }
            <>1__state = -2;
            <>t__builder.SetResult(result);
        }
        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }
        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }
        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }
    private static void Main(string[] args)
    {
        TestAsyncAwaitMethods();
        Console.WriteLine("Press any key to exit...");
        Console.ReadLine();
    }
    [AsyncStateMachine(typeof(<TestAsyncAwaitMethods>d__1))]
    [DebuggerStepThrough]
    public static void TestAsyncAwaitMethods()
    {
        <TestAsyncAwaitMethods>d__1 stateMachine = new <TestAsyncAwaitMethods>d__1();
        stateMachine.<>t__builder = AsyncVoidMethodBuilder.Create();
        stateMachine.<>1__state = -1;
        AsyncVoidMethodBuilder <>t__builder = stateMachine.<>t__builder;
        <>t__builder.Start(ref stateMachine);
    }
    [AsyncStateMachine(typeof(<LongRunningMethod>d__2))]
    [DebuggerStepThrough]
    public static Task<int> LongRunningMethod()
    {
        <LongRunningMethod>d__2 stateMachine = new <LongRunningMethod>d__2();
        stateMachine.<>t__builder = AsyncTaskMethodBuilder<int>.Create();
        stateMachine.<>1__state = -1;
        AsyncTaskMethodBuilder<int> <>t__builder = stateMachine.<>t__builder;
        <>t__builder.Start(ref stateMachine);
        return stateMachine.<>t__builder.Task;
    }
}
As pointed in many other answers on SO (like [that one](https://stackoverflow.com/a/54163263/4636721)), the `async` / `await` rewrite the code as a state machine just like for the `yield` statement with a method returning either `IEnumerator`, `IEnumerable`, `IEnumerator<T>`, `IEnumerable<T>`. Except that for `async` methods, you can return [either](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/async-return-types):
> - [`Task<TResult>`](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=netframework-4.7.2), for an async method that returns a value.
> - [`Task`](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task?view=netframework-4.7.2), for an async method that performs an operation but returns no value.
> - `void`, for an event handler.
> - Starting with C# 7.0, any type that has an accessible `GetAwaiter` method. The object returned by the `GetAwaiter` method must implement the [System.Runtime.CompilerServices.ICriticalNotifyCompletion](https://docs.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.icriticalnotifycompletion?view=netframework-4.7.2) interface.
About the last bullet you can read more about it (the fact that it's pattern based) [here](https://blogs.msdn.microsoft.com/pfxteam/2011/01/13/await-anything/) and [there](https://weblogs.asp.net/dixin/understanding-c-sharp-async-await-2-awaitable-awaiter-pattern). This also involves other subtle choices that are out of the scope of your question but you can have a short explanation [here about `ValueTask<TResult>`, `IValueTaskSource<TResult>`, etc.](https://blog.scooletz.com/2018/05/14/task-async-await-valuetask-ivaluetasksource-and-how-to-keep-your-sanity-in-modern-net-world)
The act of rewriting of the code is delegated to the compiler, Roslyn is basically using the [`AsyncRewriter`](https://github.com/dotnet/roslyn/blob/66c6a7d34d5ca96e8c08120d686203cdbc1b7714/src/Compilers/CSharp/Portable/Lowering/AsyncRewriter/AsyncRewriter.cs) class to know how to rewrite the different execution paths, branching to have an equivalent code.
In both cases where you have a valid code containing either `yield` or `async` keywords you have an initial state and depending on branching, execution path, the `MoveNext()` call that occurs behind the scenes will move from one state to another.
Knowing that in the case of a valid `async` code this kind of snippet below:
csharp
case -1:
    HelperMethods.Before();
    this.awaiter = AsyncMethods.MethodAsync(this.Arg0, this.Arg1).GetAwaiter();
    if (!this.awaiter.IsCompleted)
    {
        this.State = 0;
        this.Builder.AwaitUnsafeOnCompleted(ref this.awaiter, ref this);
    }
    break;
can roughly be translated into (see Dixin's blog for more details):
csharp
case -1: // -1 is begin.
    HelperMethods.Before(); // Code before 1st await.
    this.currentTaskToAwait = AsyncMethods.MethodAsync(this.Arg0, this.Arg1); // 1st task to await
    // When this.currentTaskToAwait is done, run this.MoveNext() and go to case 0.
    this.State = 0;
    this.currentTaskToAwait.ContinueWith(_ => that.MoveNext()); // Callback
    break;
Bear that in mind that if you have `void` as a return type of an `async` method you won't have much `currentTaskToAwait` =]
> few people are saying that Async and Await complete its job on separate background thread means spawn a new background thread and few people are saying no means Async and Await does not start any separate background thread to complete its job.
Regarding your code, you can track which thread is (ie. id) used and whether it is from a pool or not:
csharp
public static class Program
{
    private static void DisplayCurrentThread(string prefix)
    {
        Console.WriteLine($"{prefix} - Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"{prefix} - ThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    }
    public static void Main(params string[] args)
    {
        DisplayCurrentThread("Main Pre");
        
        TestAsyncAwaitMethods();
        
        DisplayCurrentThread("Main Post");
        
        Console.ReadLine();
    }
    private static async void TestAsyncAwaitMethods()
    {
        DisplayCurrentThread("TestAsyncAwaitMethods Pre");
        
        await LongRunningMethod();
        
        DisplayCurrentThread("TestAsyncAwaitMethods Post");
    }
    private static async Task<int> LongRunningMethod()
    {
        DisplayCurrentThread("LongRunningMethod Pre");
        Console.WriteLine("Starting Long Running method...");
        
        await Task.Delay(500);
        
        Console.WriteLine("End Long Running method...");
        DisplayCurrentThread("LongRunningMethod Post");
        
        return 1;
    }
}
Will output for example:
text
Main Pre - Thread Id: 1
Main Pre - ThreadPool: False
TestAsyncAwaitMethods Pre - Thread Id: 1
TestAsyncAwaitMethods Pre - ThreadPool: False
LongRunningMethod Pre - Thread Id: 1
LongRunningMethod Pre - ThreadPool: False
Starting Long Running method...
Main Post - Thread Id: 1
Main Post - ThreadPool: False
End Long Running method...
LongRunningMethod Post - Thread Id: 4
LongRunningMethod Post - ThreadPool: True
TestAsyncAwaitMethods Post - Thread Id: 4
TestAsyncAwaitMethods Post - ThreadPool: True
You can notice that that the `LongRunningMethod` method **terminates after** the `Main` method, it's due to the fact that you used `void` as a return type for asynchronous method. An `async void` method should only be used for event handlers and nothing else (see [Async/Await - Best Practices in Asynchronous Programming](https://msdn.microsoft.com/en-us/magazine/jj991977.aspx))
Also, as already mentionned by i3arnon, since no context has been passed, yes the program does (re)use a thread from the thread pool to resume its execution after the async method call.
About those "contexts", I would suggest you to read [that article](https://blogs.msdn.microsoft.com/pfxteam/2012/06/15/executioncontext-vs-synchronizationcontext), the article will clarify what is a context, in particular a `SynchronizationContext`. 
Beware that I said a threadpool thread to "resume" and not to execute the async piece of code, you can find out more about this [here](https://blog.stephencleary.com/2013/11/there-is-no-thread.html).
`async` methods are usually designed to leverage whathever latency is inherent to the underlying call, usually IO, eg. writing, reading something on a disk, querying something over the network and so forth.
The purpose of truly async methods is to avoid using threads for IO stuff which can help application to scale when you have a lot more requests. Typically can handle more requests in ASP.NET WebAPI with `async` resources since each of them will "free" the thread of the request whenever they will hit the database or whathever `async`-able calls you are making in that resource.
I suggest you to read the answers of that [question](https://stackoverflow.com/q/33821679/4636721)
> Void-returning async methods have a specific purpose: to make asynchronous event handlers possible. It is possible to have an event handler that returns some actual type, but that doesn't work well with the language; invoking an event handler that returns a type is very awkward, and the notion of an event handler actually returning something doesn't make much sense. 
> 
> Event handlers naturally return void, so async methods return void so that you can have an asynchronous event handler. However, some semantics of an async void method are subtly different than the semantics of an async Task or async Task<T> method.
A way to avoid this is to leverage a [C# 7.1 feature](https://blogs.msdn.microsoft.com/mazhou/2017/05/30/c-7-series-part-2-async-main) and expect a `Task` as a return type instead of the `void`:
csharp
public static class Program
{
    private static void DisplayCurrentThread(string prefix)
    {
        Console.WriteLine($"{prefix} - Thread Id: {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"{prefix} - ThreadPool: {Thread.CurrentThread.IsThreadPoolThread}");
    }
    public static async Task Main(params string[] args)
    {
        DisplayCurrentThread("Main Pre");
        
        await TestAsyncAwaitMethods();
        
        DisplayCurrentThread("Main Post");
        
        Console.ReadLine();
    }
    private static async Task TestAsyncAwaitMethods()
    {
        DisplayCurrentThread("TestAsyncAwaitMethods Pre");
        
        await LongRunningMethod();
        
        DisplayCurrentThread("TestAsyncAwaitMethods Post");
    }
    private static async Task<int> LongRunningMethod()
    {
        DisplayCurrentThread("LongRunningMethod Pre");
        Console.WriteLine("Starting Long Running method...");
        
        await Task.Delay(500);
        
        Console.WriteLine("End Long Running method...");
        DisplayCurrentThread("LongRunningMethod Post");
        
        return 1;
    }
}
You'll then get
text
Main Pre - Thread Id: 1
Main Pre - ThreadPool: False
TestAsyncAwaitMethods Pre - Thread Id: 1
TestAsyncAwaitMethods Pre - ThreadPool: False
LongRunningMethod Pre - Thread Id: 1
LongRunningMethod Pre - ThreadPool: False
Starting Long Running method...
End Long Running method...
LongRunningMethod Post - Thread Id: 4
LongRunningMethod Post - ThreadPool: True
TestAsyncAwaitMethods Post - Thread Id: 4
TestAsyncAwaitMethods Post - ThreadPool: True
Main Post - Thread Id: 4
Main Post - ThreadPool: True
Which looks more like what you would normally expect.
More resources about `async` / `await`:
- [Dixin's Blog: Understanding C# `async` / `await` (1) Compilation](https://weblogs.asp.net/dixin/understanding-c-sharp-async-await-1-compilation)
- [Dixin's Blog: Understanding C# `async` / `await` (2) Awaitable-Awaiter Pattern](https://weblogs.asp.net/dixin/understanding-c-sharp-async-await-2-awaitable-awaiter-pattern)
- [Dixin's Blog: Understanding C# `async` / `await` (3) Runtime Context](https://weblogs.asp.net/dixin/understanding-c-sharp-async-await-3-runtime-context)
- [Stephen Cleary: `async` and `await`](http://blog.stephencleary.com/2012/02/async-and-await.html)
- [Stephen Cleary: There is no thread](https://blog.stephencleary.com/2013/11/there-is-no-thread.html)
- [Stephen Toub: `ExecutionContext` vs `SynchronizationContext`](https://blogs.msdn.microsoft.com/pfxteam/2012/06/15/executioncontext-vs-synchronizationcontext)
