using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;

    [SerializeField]
    private float lifeTime = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += speed * Time.deltaTime * transform.forward;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag != "Player")
        {
            try
            {
                collision.gameObject.GetComponent<EnemyController>().death();
            }
            catch
            {
                Debug.Log("Not touching an enemy");
            }
            Destroy(gameObject);
        }
    }
}
