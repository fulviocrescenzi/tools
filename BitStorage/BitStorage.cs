using System;
/***
    Save only power of 2 values
    The reason, 
    int | binary
    ------------
    1   |  0001
    2   |  0010
    ------------
    bits|  0011

    If you ask for
    int | binary
    ------------
    3   |  0011

    It will return true and this is an issue because you never saved the value 3
    Values to be saved 1, 2, 4, 8, 16, 32, 64...
*/
[Serializable]
public class BitStorage
{
    public int bits = 0;

    public BitStorage()
    {
        bits = 0;
    }

    public void Add(int bit)
    {
        bits |= bit;
    }

    public bool Has(int bit)
    {
        return (bits & bit) != 0;
    }

    public void Remove(int bit)
    {
        bits &= ~bit;
    }
}