using UnityEngine;

public class Factorial : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            int result = FactorialFunction(5);
            Debug.Log(result);
        }
    }

    private int FactorialFunction(int n)
    {
        if (n == 0)
            return 1;
        else
        {
            return n * FactorialFunction(n - 1);
        }
    }
}
