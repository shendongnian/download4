using NUnit.Framework;
using NUnitLite;
public class Runner {
    public static int Main(string[] args) {
        <b>return new AutoRun(Assembly.GetExecutingAssembly())
                       .Execute(new String[] {"/test:Runner.Foo.TestSomething"});</b>
    }
    [TestFixture]
    public class Foo {
        [Test]
        public void TestSomething() {
            // test something
        }
    }
}
