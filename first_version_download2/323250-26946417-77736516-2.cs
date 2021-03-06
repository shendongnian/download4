    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication22
    {
        class Program
        {
            static void Main(string[] args)
            {
   
                #region Main Menu
                var m = new Menu() { Title = "MAIN MENU" };
                m.Menus.Add(new MenuItem() { Title = "New Game" });
                m.Menus.Add(new MenuItem() { Title = "Load Game" });
                m.Menus.Add(new MenuItem() { Title = "Exit Game" });
                var result = m.ShowAndWaitUserInput();
                //Console.Write("selected was:" + result);
                //Console.ReadLine();
                #endregion
    
                switch (result)
                {
                    case 0:
                        // Jump to character creation 
                        var m1 = new Menu() { Title = "CHARACTER CREATION" };
                        m1.Menus.Add(new MenuItem() { Title = "New Character" });
                        m1.Menus.Add(new MenuItem() { Title = "Load Character" });
                        m1.Menus.Add(new MenuItem() { Title = "Return" });
                        var result1 = m1.ShowAndWaitUserInput();
                        break;
                    case 1:
                        break;
                    case 2:
                        return;
                }
            }
        }
    
        public class MenuItem
        {
            public string Title { get; set; }
        }
        public class Menu
        {
            public Menu()
            {
                this.Menus = new List<MenuItem>();
            }
            public string Title { get; set; }
            public List<MenuItem> Menus { get; set; }
    
            public int ShowAndWaitUserInput()
            {
                int selectedMenu = 0;
                Console.CursorVisible = false;
    
                do
                {
                    Console.Clear();
                    #region Display Menu and Sub-Menus
                    {
                        var i = 0;
                        Console.WriteLine(" ** " + this.Title.ToUpper() + " ** ");
    
                        foreach (var menu in Menus)
                        {
                            //Console.WriteLine("   New Game");
                            if (i == selectedMenu)
                                Console.Write("  >> ");
                            else
                                Console.Write("     ");
    
                            Console.WriteLine(menu.Title);
    
                            i++;
                        }
                    }
                    #endregion
                    #region Get User Input
                    {
                        ConsoleKeyInfo keyInfo = Console.ReadKey();
                        if (keyInfo.Key == ConsoleKey.UpArrow)
                        {
                            selectedMenu--;
                            if (selectedMenu < 0) selectedMenu = Menus.Count() - 1;
                        }
                        else if (keyInfo.Key == ConsoleKey.DownArrow)
                        {
                            selectedMenu++;
                            if (selectedMenu == Menus.Count()) selectedMenu = 0;
                        }
                        else if (keyInfo.Key == ConsoleKey.Enter)
                        {
                            return selectedMenu;
                        }
                    }
                    #endregion
                } while (true);
    
            }
    
        }
    }
