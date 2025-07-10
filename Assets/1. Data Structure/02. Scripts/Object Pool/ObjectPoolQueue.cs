using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolQueue : MonoBehaviour
{
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    public GameObject objPrefab;
    public Transform parent;


    private void Start()
    {
        CreateObject();
    }

    private void CreateObject() // 오브젝트를 생성하는 기능 -> Pool을 채우는 기능
    {
        for (int i = 0; i < 30; i++)
        {
           GameObject obj = Instantiate(objPrefab, parent); // 오브젝트를 생성하고, 계층구조를 parent의 자식으로 변경

            EnqueueObject(obj);
        }
    }

    public void EnqueueObject(GameObject newObj)
    {
        newObj.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        newObj.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        objQueue.Enqueue(newObj);
        newObj.SetActive(false); // 오브젝트가 작동되지 않도록 꺼줌
    }

    public GameObject DequeueObject()
    {
        if (objQueue.Count < 10) 
            CreateObject();

        GameObject obj = objQueue.Dequeue();
        obj.SetActive(true);

        return obj;
    }
}
