    Stack<Point[]> v = new Stack<Point[]>();
    Point[] c = new Point[4];
    v.Push(c);
    c[0] = new Point(5, 5);
    Point[] cc = new Point[c.Length];
    Array.Copy(c, cc, c.Length);
    cc[0] = cc[0];
    c[0].X = 20;
    c[0].Y = 20;
    var cx = v.Pop();
    Console.WriteLine(c[0]);
    Console.WriteLine(cx[0]);
    Console.WriteLine(cc[0]);
