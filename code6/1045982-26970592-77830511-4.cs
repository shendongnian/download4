    using MyNamespace;
    using System.Windows;
    public void MyMethod()
    {
        // this refers to your Vector class
        MyNamespace.Vector v1;
        // this refers to the existing Vector class from System.Windows namespace
        System.Windows.Vector v2;
    }
