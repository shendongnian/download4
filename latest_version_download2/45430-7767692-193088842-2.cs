    struct V { public int x; }
    class  R { public int y = 0; }
    void F() 
    {
       V a;   // a is an instance of V, a.x is unassigned  
       R b;   // b is a reference to an R
       a.x = 1; // OK, the instance exists
     //b.y = 2; // error, there is no instance yet
       a = new V();  // overwrites the memory of 'a'. a.x == 0
       b = new R();  // allocates new memory on the Heap
       
       b.y = 2; // now this is OK, b points to an instance
    }
   
