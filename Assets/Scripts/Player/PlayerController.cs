using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 move;

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

    void Start()
    {
        
    }

    void Update() 
    {
        movePlayer();
    }

    public void movePlayer ()
    {
        Vector3 movment = new Vector3(move.x, 0, move.y);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movment), 0.15f);

        transform.Translate(movment *  speed * Time.deltaTime, Space.World);
    }
}
