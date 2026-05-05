using UnityEngine;

public class BinaryTask
{
    public int A;
    public int B;
    public bool isAdd;

    public int result;

    public void Generate(int bits = 4)
    {
        int max = 1 << bits;

        A = Random.Range(0, max);
        B = Random.Range(0, max);

        isAdd = Random.value > 0.5f;

        if (isAdd)
            result = A + B;
        else
            result = A - B;
    }

    public string GetBinary(int value, int bits = 4)
    {
        return System.Convert.ToString(value, 2).PadLeft(bits, '0');
    }
}