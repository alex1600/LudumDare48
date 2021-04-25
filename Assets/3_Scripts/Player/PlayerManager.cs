using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    public PlayerMovement playerMovement;
    public PlayerController playerController;
    public PlayerInput playerInput;
}
