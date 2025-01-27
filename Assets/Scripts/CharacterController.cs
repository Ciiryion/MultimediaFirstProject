using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference moveActionReference;

    [SerializeField]
    private InputActionReference boostActionReference;

    [SerializeField]
    private float speed = 4f;

    [SerializeField]
    private float boostSpeed = 5f;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform bulletStartPos;

    [SerializeField]
    private float bulletCooldown = 2.0f;

    [SerializeField]
    private Animator playerAnimator;

    private float initialSpeed;
    private const string isMoving = "isMoving";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        initialSpeed = speed;
        moveActionReference.action.Enable();
        boostActionReference.action.Enable();
        InvokeRepeating(nameof(shoot), bulletCooldown, bulletCooldown);
    }

    // Update is called once per frame
    private void Update()
    {
        playerAnimator.SetBool(isMoving, false);
        // Check the boost button
        if (boostActionReference.action.phase == InputActionPhase.Performed)
        {
            speed = boostSpeed;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamera>().zoom();
        }
        else
        {
            speed = initialSpeed;
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<MainCamera>().dezoom();
        }

        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x, 0, frameMovement.y);
        Vector3 newPos = transform.position + frameMovement3D * speed * Time.deltaTime;
        Vector3 directorPos = newPos - transform.position;

        if (directorPos.magnitude != 0)
        {
            Quaternion orientation = Quaternion.LookRotation(directorPos, Vector3.up);
            // Slerp permet de faire une rotation fluide
            transform.rotation = Quaternion.Slerp(transform.rotation, orientation, 0.03f + Time.deltaTime);
            // Lancement de l'animation de course
            playerAnimator.SetBool(isMoving, true);
        }

        transform.position = newPos;
    }

    private void shoot()
    {
        Instantiate(bullet, bulletStartPos.position, bulletStartPos.rotation);
    }
}