namespace AdvancedCsharp01
{
    public class Container<T,U>:IRepository<T>
    {
        T First;
        U Second;
        public void Add(T value,U val)
        {
            First = value;
            Second = val;
        }
        public T GetFirst()
        {
            return First;
        }
        public U GetSecond()
        {
            return Second;
        }
        public void Swap<T>(T value1,T value2)
        {
            T Temp = value1;
            value1 = value2;
            value2 = Temp;
        }
        public V Max<V>(V value1, V value2) where V : IComparable<V>
        {
            return value2.CompareTo(value1) > 0 ? value2 : value1;
        }
        public void Adds(T Item)
        {
            First = Item;
        }
        public T Get()
        {
            return First;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Container<int,string> container= new Container<int,string>();
            container.Add(10,"seif");
            Console.WriteLine(container.GetFirst());
            Console.WriteLine(container.GetSecond());
            container.Swap<int>(10,15);
            Console.WriteLine(container.Max<int>(10, 15));

        }
    }
}
