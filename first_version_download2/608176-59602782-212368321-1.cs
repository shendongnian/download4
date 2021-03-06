I had nothing to do at home, so I made this program for you. It utilizes a [TreeNode][1] data structure. The TreeNode data structure makes it possible to have an "unlimited" amount of sub categories/products. You need to add/change products to the Populate() method and maybe change the MenuItem properties to your choice (i.e. Price is of type int?).
    public class Program
    {
        private static List<MenuItem> _cart = new List<MenuItem>();
        static void Main()
        {
            var menu = Populate();
            Run(menu);
            ShowCart();
            Console.WriteLine("Goodbye!");
            Console.ReadLine();
        }
        private static void ShowCart()
        {
            Console.WriteLine($"Your cart:");
            for (int i = 0; i < _cart.Count; i++)
            {
                Console.WriteLine($"{i}.{_cart[i].Name}\t{_cart[i].Price}");
            }
            Console.WriteLine("\n----------------------");
            Console.WriteLine($"Total: {_cart.Sum(item => item.Price)}");
        }
        private static void Run(TreeNode<MenuItem> menu)
        {
            while (true)
            {
                var selectedItem = SelectMenuItem(menu);
                switch (selectedItem.Value.MenuType)
                {
                    case MenuType.Category:
                        Console.WriteLine($"\nYou selected {selectedItem.Value.Name}.\n");
                        menu = selectedItem;
                        break;
                    case MenuType.Product:
                        Console.WriteLine($"\nYou added {selectedItem.Value.Name} to the cart.\n");
                        _cart.Add(selectedItem.Value);
                        if (selectedItem.Parent != null)
                            menu = selectedItem.Parent;
                        break;
                    case MenuType.Back:
                        Console.WriteLine();
                        menu = (selectedItem.Parent?.Parent != null) ? selectedItem.Parent.Parent : selectedItem.Parent;
                        break;
                    case MenuType.Exit:
                        Console.WriteLine();
                        return;
                    default:
                        throw new Exception($"{selectedItem.Value.MenuType} not implemented");
                }
            }
        }
        private static TreeNode<MenuItem> SelectMenuItem(TreeNode<MenuItem> menuItem)
        {
            while (true)
            {
                Console.WriteLine($"Please select an option between 1 and {menuItem.Children.Count()}: ");
                foreach (var child in menuItem.Children)
                {
                    var price = child.Value.Price.HasValue ? $"\tPrice: {child.Value.Price.Value}" : string.Empty;
                    Console.WriteLine($"{child.Value.Id}. {child.Value.Name} {price}");
                }
                var selectedId = TryParseInput();
                while (true)
                {
                    var selectedItem = menuItem.Children.FirstOrDefault(m => m.Value.Id == selectedId);
                    if (selectedItem != null)
                    {
                        return selectedItem;
                    }
                    //Selected id does not exist in the menu
                    Console.WriteLine($"Please choose from one of the options.");
                    selectedId = TryParseInput();
                }
            }
        }
        private static TreeNode<MenuItem> Populate()
        {
            var menu = new TreeNode<MenuItem>(new MenuItem(1, "Menu", MenuType.Category));
            var sweets = new TreeNode<MenuItem>(new MenuItem(1, "Sweets", MenuType.Category));
            sweets.AddChild(new MenuItem(1, "Chocolate R10", MenuType.Product, 15));
            sweets.AddChild(new MenuItem(2, "Winegums R12", MenuType.Product, 20));
            sweets.AddChild(new MenuItem(3, "Astros R15", MenuType.Product, 11));
            sweets.AddChild(new MenuItem(4, "Back", MenuType.Back));
            var meats = new TreeNode<MenuItem>(new MenuItem(2, "Meats", MenuType.Category));
            meats.AddChild(new MenuItem(1, "Chicken", MenuType.Product, 13));
            meats.AddChild(new MenuItem(2, "Beef", MenuType.Product, 14));
            meats.AddChild(new MenuItem(3, "Seafood", MenuType.Product, 17));
            meats.AddChild(new MenuItem(4, "Back", MenuType.Back));
            var produce = new TreeNode<MenuItem>(new MenuItem(3, "Produce", MenuType.Category));
            produce.AddChild(new MenuItem(1, "Apple", MenuType.Product, 17));
            produce.AddChild(new MenuItem(2, "Tomato", MenuType.Product, 25));
            produce.AddChild(new MenuItem(3, "Orange", MenuType.Product, 24));
            produce.AddChild(new MenuItem(4, "Back", MenuType.Back));
            var exit = new TreeNode<MenuItem>(new MenuItem(4, "Exit", MenuType.Exit));
            menu.AddChild(sweets);
            menu.AddChild(meats);
            menu.AddChild(produce);
            menu.AddChild(exit);
            return menu;
        }
        private static int TryParseInput()
        {
            int returnInt;
            while (!int.TryParse(Console.ReadLine(), out returnInt))
            {
                //Cannot parse input as an integer
                Console.WriteLine($"Selection is not a number. Please try again.");
            }
            return returnInt;
        }
    }
    public class MenuItem
    {
        public MenuItem(int id, string name, MenuType menuType, int? price = null)
        {
            Id = id;
            Name = name;
            Price = price;
            MenuType = menuType;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int? Price { get; private set; }
        public MenuType MenuType { get; private set; }
    }
    public enum MenuType
    {
        Category,
        Product,
        Back,
        Exit
    }
    public class TreeNode<T>
    {
        private readonly T _value;
        private readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();
        public TreeNode(T value)
        {
            _value = value;
        }
        public TreeNode<T> this[int i] => _children[i];
        public TreeNode<T> Parent { get; private set; }
        public T Value { get { return _value; } }
        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return _children.AsReadOnly(); }
        }
        public TreeNode<T> AddChild(T value)
        {
            var node = new TreeNode<T>(value) { Parent = this };
            _children.Add(node);
            return node;
        }
        public TreeNode<T> AddChild(TreeNode<T> node)
        {
            node.Parent = this;
            _children.Add(node);
            return node;
        }
    }
