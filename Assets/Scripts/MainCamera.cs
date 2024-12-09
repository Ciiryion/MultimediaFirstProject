using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    public float smooth = 0.125f;
    private Vector3 velocity = Vector3.zero;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition,ref velocity,smooth);
    }
}
