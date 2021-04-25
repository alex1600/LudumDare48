using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("COMPONENTS")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Rigidbody2D rigi;

    [Header("CONFIG")]
    [SerializeField] private float speedWalk = 1;

    public bool canMove = true;

    private Vector2 inputMovement = Vector2.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
            rigi.MovePosition(rigi.position + inputMovement * Time.deltaTime * speedWalk);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
        if (inputMovement.x >= 0.1f || inputMovement.x <= -0.1f || inputMovement.y >= 0.1f || inputMovement.y <= -0.1f)
        {
            playerController.SetWalkStatus(true);
            if (inputMovement.x >= 0.1)
                playerController.SetDirection(false);
            else if (inputMovement.x <= -0.1)
                playerController.SetDirection(true);
        }
        else
        {
            playerController.SetWalkStatus(false);
        }

    }
}
