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
        persons.Add("繹熱", new PersonData(10, "繹熱", 150f, 30f));
        persons.Add("繹熱", new PersonData(10, "艙��", 150f, 30f));
        persons.Add("繹熱", new PersonData(10, "翕熱", 150f, 30f));

        Debug.Log(persons["繹熱"].age);
        Debug.Log(persons["繹熱"].name);
        Debug.Log(persons["繹熱"].weight);
        Debug.Log(persons["繹熱"].heigth);
    }
}
