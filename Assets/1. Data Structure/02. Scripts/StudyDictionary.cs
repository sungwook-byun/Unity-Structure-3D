using System.Collections.Generic;
using UnityEngine;

public class PersonData
{
    public int age;
    public string name;
    public float heigth;
    public float weight;

    public PersonData(int age, string name, float heigth, float weight  )
    {
        this.age = age;
        this.name = name;
        this.heigth = heigth;
        this.weight = weight;
    }
}


public class StudyDictionary : MonoBehaviour
{
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();
    private void Start()
    {
        persons.Add("ö��", new PersonData(10, "ö��", 150f, 30f));
        persons.Add("ö��", new PersonData(10, "����", 150f, 30f));
        persons.Add("ö��", new PersonData(10, "����", 150f, 30f));

        Debug.Log(persons["ö��"].age);
        Debug.Log(persons["ö��"].name);
        Debug.Log(persons["ö��"].weight);
        Debug.Log(persons["ö��"].heigth);
    }
}
