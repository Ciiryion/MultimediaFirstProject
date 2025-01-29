using UnityEditor;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;

    [SerializeField]
    private float zone = 5.0f;

    [SerializeField]
    private float time = 2.0f;

    [SerializeField]
    private int maxEnnemiesNumber = 50;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(spawnMob), 0f, time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, zone);
    }

    private void spawnMob()
    {
        if(GameObject.FindGameObjectsWithTag("Ennemy").Length >= maxEnnemiesNumber)
            return;
        float x, z;
        x = transform.position.x + Random.Range(-zone, zone);
        z = transform.position.z + Random.Range(-zone, zone);
        Instantiate(enemy, new Vector3(x,transform.position.y, z),Quaternion.identity);
    }
}
