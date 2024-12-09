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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        moveActionReference.action.Enable();
        boostActionReference.action.Enable();
    }

    // Update is called once per frame
    private void Update()
    {
        if(boostActionReference.action.phase == InputActionPhase.Performed)
        {
            speed = 6f;
        }
        else
        {
            speed = 4f;
        }

        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x, 0, frameMovement.y);
        Vector3 newPos = transform.position + frameMovement3D * speed * Time.deltaTime;
        transform.position = newPos;

        //Vector3 direction = newPos - transform.position;
        //Quaternion playerOrientation = Quaternion.LookRotation(direction, Vector3.up);
    }
}