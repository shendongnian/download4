        public unsafe void PointerTest()
        {
            int x = 100; // Create a variable named x
            
            int *MyPointer = &x; // Store the address of variable named x into the pointer named MyPointer
            textBox1.Text = ((int)MyPointer).ToString(); // Displays the memory address stored in pointer named MyPointer
            textBox2.Text = (*MyPointer).ToString(); // Displays the value of the variable named x via the pointer named MyPointer.
            
        }
