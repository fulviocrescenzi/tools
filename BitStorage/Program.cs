using System;

class Program
{
    static void Main(string[] args)
    {
        BitStorage bitStore = new BitStorage();
        Console.WriteLine("Bits: " + bitStore.bits.ToString());
        bitStore.Add(1); 
        Console.WriteLine("Bits added(1): " + bitStore.bits.ToString());
        bitStore.Add(2); 
        Console.WriteLine("Bits added(2): " + bitStore.bits.ToString());

        Console.WriteLine("Bits has (1): " + bitStore.Has(1).ToString());
        Console.WriteLine("Bits has (4): " + bitStore.Has(4).ToString());

        bitStore.Remove(1);
        Console.WriteLine("Bits removed(1): " + bitStore.bits.ToString());
        Console.WriteLine("Bits has (1): " + bitStore.Has(1).ToString());
        Console.WriteLine("Bits has (2): " + bitStore.Has(2).ToString());
    }
}
