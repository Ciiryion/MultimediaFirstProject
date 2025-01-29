using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;

    [SerializeField]
    private GameObject exp;

    [SerializeField]
    [Range(0f,100f)]
    private float expProba = 10;

    private Transform player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // The ennemies are always looking for the player
        Vector3 direction = Vector3.MoveTowards(gameObject.transform.position, player.position, 0.005f);
        Quaternion orientation = Quaternion.LookRotation(player.position - transform.position, Vector3.up);

        transform.position = direction;
        transform.rotation = orientation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //Debug.Log("Red rabbit attack the player");
            collision.gameObject.GetComponent<LifeManager>().takeDamage(damage);
            // Destruct the ennemi after he hit the player
            Destroy(gameObject);
        }
    }

    public void death()
    {
        //Debug.Log("Killing red rabbit");
        // Instantiate exp for the player
        if(Random.Range(0,100) <= expProba)
        {
            Instantiate(exp, transform.position, Quaternion.Euler(37,0,0));
        }
        // TODO : Ajouter un son de mort du lapin rouge

        GameManager.instance.updScore(10);
        Destroy(gameObject);
    }

    public void getBuff()
    {
        damage++;
    }
}
