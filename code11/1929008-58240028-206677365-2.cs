//This is the base class, the one from which others inherit
abstract class WaitableObject
{
     protected WaitableObject(IntPtr handle) { Handle  = handle; }
     public IntPtr Handle { get; }
}
//Inherits from WaitableObject
class Object1 : WaitableObject
{
    public Object1() : base(new IntPtr(1))
    {
    }
    
    void DoSomething();
}
class Object2 : WaitableObject
{
    public Object2() : base(new IntPtr(2))
    {
    }
    int CalculateSomething(int a, int b);
}
and then we have a method which can wait on a object using the object's `Handle` e.g.
bool WaitOn(WaitableObject obj)
{
   // do something with obj.Handle
}
So, instead of creating 2 methods, one which accepts `Object1` and another which accepts `Object2`, we made both of those classes inherit from the same base class sins they both has something in common, aka `Handle`. Same applies to interface inheritance.
> **Use of Composition**
A use of composition is to have a type manage other types so those types don't get accidentally accessed when the main type is destroyed. A good example of this is Unity Engine's `GameObject` class. You can add to a game object components which are separate things but, when the main object is destroyed so are all of it's components, so incase of a class holding onto a destroyed game object's component tries to access it, it will be hit with a null exception sins that component has no meaning as the game object to which it was once attached to was destroyed. Basically, it's so parts of a type, which should only be allowed access to if the main type is alive, don't stay alive after the main type is destroyed, that's AFAIK the main use of composition.
A example which isn't 3rd party would be System.Windows.Forms.Form class, same principle with the components and same thing with the destruction.
> **Use of Polymorphism [Read Edit Note]**
*Polymorphism  is mainly used when multiple classes/structures can use the same thing, like `System.IO`'s `BinaryReader` & `BinaryWriter`, both of them can use the same stream and there is no need to open 2 separate, e.g.*
public void AppendLastByte(string filename)
{
   // opens a Stream of the specified file with read & write rights
   Stream myFileStream = File.Open(filename, FileMode.Open, FileAccess.ReadWrite);
   myFileStream = (myFileStream.Length - 1); //set the position to the last byte.
   //Created a binary reader, so we can read the data of the stream.
   var reader = new BinaryReader(myFileStream);
   //Created a binary write, so we can write data to the stream.
   var writer = new BinaryWriter(newFileStream);
   //
   //Note that when a read/write operation is done the position in the underline stream is moved by the amount of bytes read/written.
   //
  //Read the last byte of the stream, as written above, the underline stream's position is now "myFileStream.Length", sins it was "myFileStream.Length - 1"
  byte lastByte = reader.ReadByte();
  //Wrote the read byte to the end of the file, aka appended it.
  writer.Write(lastByte);
  //disposal
  myFileStream.Close();
}
*So, instead of managing 2 streams, and consuming more resources, we just used 1. Another possibility of using polymorphism is to limit the amount of stuff that can be done to the underline objects. Lets take the same 3 things, `Stream`, `BinaryReader` & `BinaryWriter`, sins `Stream` does have the ability to read and write, `BinaryReader` makes it so the stream is kind of limited to only reading and vise versa for `BinaryWriter`.*
