using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 dir;
    public float speed = 5f;

    public GameObject explosionFactory;

    private void Start()
    {
        int ranValue = UnityEngine.Random.Range(0, 10);

        if( ranValue < 3) // 30%
        {
            GameObject target = GameObject.Find("Player");
            dir = target.transform.position - transform.position;
            dir.Normalize();
        }
        else // 70%
        {
            dir = Vector3.down;
        }
    }

    private void Update()
    {
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject smObject = GameObject.Find("ScoreManager");
        ScoreManager sm = smObject.GetComponent<ScoreManager>();

        // sm.SetScore(sm.GetScore() + 1); // 아래는 풀어서 적은것.
        var score = sm.GetScore() + 1;
        sm.SetScore(score);



        GameObject explosion = Instantiate(explosionFactory);
        explosion.transform.position = transform.position;

        Destroy(other.gameObject);

        Destroy(gameObject);
    }
}
