using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "Hello World**";

    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    void Start()
    {
        Debug.Log(str1[0]); // H
        Debug.Log(str1[2]); // l

        Debug.Log(str2[0]); // Hello
        Debug.Log(str2[2]); // World

        Debug.Log(str1.Length); // 문자열의 길이, 띄어쓰기도 포함
        Debug.Log(str1.Trim()); // 맨앞과 맨뒤만 공백제거
        Debug.Log(str1.Trim('*')); // 문자 맨앞과 뒤중에 '*'가 있다면 제거

        Debug.Log(str1.Contains('H')); // 대문자 H가 있는지
        Debug.Log(str1.Contains('h')); // 소문자 h가 있는지
        Debug.Log(str1.Contains("Hello")); // Hello라는 단어가 있는지

        Debug.Log(str1.ToUpper()); // 대문자 변환
        Debug.Log(str1.ToLower()); // 소문자 변환

        str1 = str1.Replace("World", "Unity");
        // Debug.Log(str1.Replace("World", "Unity")); // 로그만 뜨고 원본은 바뀌지 않아서 위에처럼 값을 담아서 써야 원본도 바뀜

        string text = "Apple,Banana,Orange,Melon,Watre Melon,Mango";

        string[] fruits = text.Split(','); // 특정 문자로 쪼개기

        foreach(var fruit in fruits)
            Debug.Log(fruit);
    }
}
