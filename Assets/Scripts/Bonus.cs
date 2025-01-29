using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private int exp = 1;

    [SerializeField]
    private float lifeTime = 30;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<ExpManager>().GainExp(exp);
            //TODO : Ajouter un son pour la recuperation de l'item

            Destroy(gameObject);
        }
    }
}
