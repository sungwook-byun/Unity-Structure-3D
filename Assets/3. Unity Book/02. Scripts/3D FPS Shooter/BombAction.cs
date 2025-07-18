using UnityEngine;

public class BombAction : MonoBehaviour
{
    public GameObject bombEffet;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject eff = Instantiate(bombEffet);
        eff.transform.position = transform.position;

        Destroy(gameObject);
    }
}
