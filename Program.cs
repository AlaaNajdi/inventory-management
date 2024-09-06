using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

class Item
{
    private string _name;
    private int _quantity;
    private DateTime _createddate;

    // var coffee = mew Item("coffee", 20, new DateTime(2024-09-05))
    public Item(string name, int quantity, DateTime? createddate = null)
    {
        _name = name;
        _quantity = quantity;
        _createddate = createddate ?? DateTime.Now;
    }

    public string Name
    {
        get { return _name; }
        set
        {
            if (string.IsNullOrEmpty(value)) { throw new ArgumentException("name can't be null or empty"); }
            _name = value;
        }
    }

    public int Quantity
    {
        get { return _quantity; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("value can't be neqative");
            }
            _quantity = value;
        }
    }

    public DateTime Createddate { get { return _createddate; } set { _createddate = value; } }

    class Store
    {
        // inside store, there are many items, the items will be stored in a list

        // var tamimi = new Store() // inside the tamimi market, there will be an array to store items 
        // var manuel = new Store() // []
        private List<Item> _storeItem;

        public Store()
        {
            _storeItem = new List<Item>();
        }
        public bool Additemtostore(Item item)
        {

            if (_storeItem.Any(_storeItem => _storeItem._name.Equals(item._name)))
            {
                Console.WriteLine($"The item is alredy exist");
                return false;
            };

            _storeItem.Add(item);
            Console.WriteLine($"item is added to the store");
            return true;
        }
        public void DeleteItem(string name)
        {
            _storeItem.RemoveAll(i => i.Name == name);
        }
        public int GetCurrentVolume()
        {
            return _storeItem.Sum(i => i.Quantity);
        }
        public Item FindItemByName(string name)
        {
            return _storeItem.FirstOrDefault(i => i.Name == name);
        }
        public List<Item> SortByNameAsc()
        {
            return _storeItem.OrderBy(i => i.Name).ToList();
        }
    }
    public static void Main(string[] args)
    {
        try
        {

            var waterBottle = new Item("Water Bottle", 10, new DateTime(2023, 1, 1));
            var chocolateBar = new Item("Chocolate Bar", 15, new DateTime(2023, 2, 1));
            var notebook = new Item("Notebook", 5, new DateTime(2023, 3, 1));
            var pen = new Item("Pen", 20, new DateTime(2023, 4, 1));
            var tissuePack = new Item("Tissue Pack", 30, new DateTime(2023, 5, 1));
            var chipsBag = new Item("Chips Bag", 25, new DateTime(2023, 6, 1));
            var sodaCan = new Item("Soda Can", 8, new DateTime(2023, 7, 1));
            var soap = new Item("Soap", 12, new DateTime(2023, 8, 1));
            var shampoo = new Item("Shampoo", 40, new DateTime(2023, 9, 1));
            var toothbrush = new Item("Toothbrush", 50, new DateTime(2023, 10, 1));
            var coffee = new Item("Coffee", 20);
            var sandwich = new Item("Sandwich", 15);
            var batteries = new Item("Batteries", 10);
            var umbrella = new Item("Umbrella", 5);
            var sunscreen = new Item("Sunscreen", 8);

            Store store = new Store();

            Console.WriteLine("Current volume: " + store.GetCurrentVolume());

            Item item = store.FindItemByName("Chips Bag");

            Console.WriteLine("Sorted items:");
            foreach (var sortedItem in store.SortByNameAsc())
            {
                Console.WriteLine(sortedItem);
            }

            Console.WriteLine("Found item: " + item);
            Console.WriteLine(waterBottle.Name);

            store.Additemtostore(waterBottle);
            store.DeleteItem("Pen");
            Console.WriteLine("After deleting 'Pen':");
            Console.WriteLine(store);

        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ex.message");
        }
    }



}
