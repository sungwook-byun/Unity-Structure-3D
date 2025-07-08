using UnityEngine;

public class JaggedArray : MonoBehaviour
{
    public int[] array1 = new int[3];
    public int[][] jaggerdArray1 = new int[3][];


    private void Start()
    {
        array1[0] = 1;
        array1[1] = 2;
        array1[2] = 3;

        jaggerdArray1[0] = new int[2] { 1, 2 };
        jaggerdArray1[1] = new int[3] { 3, 4, 5 };
        jaggerdArray1[2] = new int[4] { 6, 7, 8, 9 };
    }
}
