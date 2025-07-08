
using System;
using System.Collections;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody bombRb;
    public float bombTime = 4f;
    public float bombRange = 10f;
    public LayerMask layerMask;

    private void Awake()
    {
        bombRb = GetComponent<Rigidbody>();
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(bombTime);

        BombForce();
    }

    private void BombForce()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, bombRange, layerMask);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();

            // AddExplosionForce(Æø¹ßÆÄ¿ö, Æø¹ßÀ§Ä¡, Æø¹ß¹üÀ§, Æø¹ß³ôÀÌ)
            rb.AddExplosionForce(500f, transform.position, bombRange, 1f);
        }
        Destroy(gameObject);
    }
}
