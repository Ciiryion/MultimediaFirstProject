using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField]
    private int exp = 1;

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
