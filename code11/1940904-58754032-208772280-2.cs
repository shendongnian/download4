static public class JaggedArrayHelper
{
  static public void Save(string filename, byte[][] array)
  {
    using ( var file = new FileStream(filename, FileMode.Create, FileAccess.Write) )
    {
      foreach ( var row in array )
      {
        var sizeRow = BitConverter.GetBytes(row.Length);
        file.Write(sizeRow, 0, sizeRow.Length);
        file.Write(row, 0, row.Length);
      }
      file.Flush();
      file.Close();
    }
  }
  static public byte[][] Load(string filename)
  {
    var array = new byte[0][];
    using ( var file = new FileStream(filename, FileMode.Open, FileAccess.Read) )
    {
      int countRead;
      int countItems;
      int sizeInt = sizeof(int);
      var sizeRow = new byte[sizeInt];
      while ( true )
      {
        countRead = file.Read(sizeRow, 0, sizeInt);
        if ( countRead != sizeInt )
          break;
        countItems = BitConverter.ToInt32(sizeRow, 0);
        var data = new byte[countItems];
        countRead = file.Read(data, 0, countItems);
        if ( countRead != countItems )
          break;
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = data;
      }
      file.Close();
    }
    return array;
  }
}
**Test**
    static void TestJaggedArray()
    {
      string filename = "c:\\test.bin";
      byte[][] data = new byte[4][];
      data[0] = new byte[] { 10, 20, 30, 40, 50 };
      data[1] = new byte[] { 11, 21, 31, 41, 51, 61, 71, 71, 81, 92 };
      data[2] = new byte[] { 12, 22, 32 };
      data[3] = new byte[] { 13, 23, 33, 43, 53, 63, 73 };
      Action print = () =>
      {
        foreach ( var row in data )
        {
          Console.Write("  ");
          foreach ( var item in row )
            Console.Write(item + " ");
          Console.WriteLine();
        }
      };
      Console.WriteLine("Jagged array before save:");
      print();
      JaggedArrayHelper.Save(filename, data);
      data = JaggedArrayHelper.Load(filename);
      Console.WriteLine();
      Console.WriteLine("Jagged array after load:");
      print();
    }
**Output**
Jagged array before save:
  10 20 30 40 50
  11 21 31 41 51 61 71 71 81 92
  12 22 32
  13 23 33 43 53 63 73
Jagged array after load:
  10 20 30 40 50
  11 21 31 41 51 61 71 71 81 92
  12 22 32
  13 23 33 43 53 63 73
**Future improvements**
We can add some fields to define a header to help to recognize file format.
We can also manage the case of data readed does not match the intended count and show a message or raise an exception in addition of breaking the loop.
