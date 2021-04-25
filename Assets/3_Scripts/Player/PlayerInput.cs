using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 inputMovement = Vector2.zero;
    public Vector2 InputMovement { get => inputMovement; }

    // Update is called once per frame
    //void Update()
    //{
    //    inputMovement.x = Input.GetAxis("Horizontale");
    //    inputMovement.y = Input.GetAxis("Vertical");
    //}
}
