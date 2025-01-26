using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float smooth = 0.125f;

    private Vector3 velocity = Vector3.zero;
    

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPosition = new Vector3(player.position.x, transform.position.y, player.position.z - 3);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition,ref velocity,smooth);
    }

    public void zoom()
    {
        gameObject.GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, 55, 0.1f);
    }

    public void dezoom()
    {
        gameObject.GetComponent<Camera>().fieldOfView = Mathf.Lerp(GetComponent<Camera>().fieldOfView, 60, 0.1f);
    }
}
