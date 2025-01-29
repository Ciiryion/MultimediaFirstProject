using System.Collections;
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
    [Range(0f,10f)]
    private float bulletCooldown = 2.0f;

    [SerializeField]
    private Animator playerAnimator;

    private float initialSpeed;
    private const string ISMOVING = "isMoving";
    private const string ATTACKTYPE = "attack";
    private const string ISATTACK = "isAttack";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        initialSpeed = speed;

        // Enable the Inputs Action References
        moveActionReference.action.Enable();
        boostActionReference.action.Enable();

        // Start the instantiation of the bullets
        StartCoroutine(WaitShoot());
    }

    // Update is called once per frame
    private void Update()
    {
        playerAnimator.SetBool(ISMOVING, false);
        playerAnimator.SetBool(ISATTACK, false);

        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x, 0, frameMovement.y);
        Vector3 newPos = transform.position + frameMovement3D * speed * Time.deltaTime;
        Vector3 directorPos = newPos - transform.position;

        if (directorPos.magnitude != 0)
        {
            Quaternion orientation = Quaternion.LookRotation(directorPos, Vector3.up);
            // Slerp is use for a smooth rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, orientation, 0.03f + Time.deltaTime);
            // Launch the running animation
            playerAnimator.SetBool(ISMOVING, directorPos.magnitude > 0);
        }

        // Check the boost button
        if (boostActionReference.action.phase == InputActionPhase.Performed && directorPos.magnitude > 0)
        {
            speed = boostSpeed;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamera>().zoom();
        }
        else
        {
            speed = initialSpeed;
            GameObject.FindGameObjectWithTag("MainCamera").gameObject.GetComponent<MainCamera>().dezoom();
        }

        transform.position = newPos;
    }

    IEnumerator WaitShoot()
    {
        while (true)
        {
            shoot();
            //Debug.Log(nameof(WaitShoot));
            yield return new WaitForSeconds(bulletCooldown);
        }
    }

    private void shoot()
    {
        //Debug.Log("Shoot Method");
        // Start the animation, the animation has an event that create the bullet
        playerAnimator.SetInteger(ATTACKTYPE, 1);
        playerAnimator.SetBool(ISATTACK, true);
    }

    public void createBullet()
    {
        Instantiate(bullet, bulletStartPos.position, bulletStartPos.rotation);
    }

    public void setCooldown(float time)
    {
        bulletCooldown -= time;
    }
}