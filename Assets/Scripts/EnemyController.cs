using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.MoveTowards(gameObject.transform.position, player.position, 0.005f);
        Quaternion orientation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);

        transform.position = direction;
        transform.rotation = orientation;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Red rabbit attack the player");
        }
    }

    public void death()
    {
        Debug.Log("Killing red rabbit");
        Destroy(gameObject);
    }
}
