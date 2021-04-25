using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Projectile pfProjectile;
    [SerializeField] private Transform spawnProjectilePoint;
    [SerializeField] private SpriteRenderer sprPlayer;
    [SerializeField] private Animator flareRockectAnimFX;
    [SerializeField] private Animator flareRockectAnimFXLeft;

    private int cd = 1;
    private bool canShoot = true;

    private int nbKilled = 0;

    public void AddKillEnemy()
    {
        nbKilled++;
        if (nbKilled >= 4)
        {
            DoorLogic.Instance.CanOpen(true);
            FMODUnity.RuntimeManager.PlayOneShot("event:/success");
        }
    } 

    public void OnShootRocket()
    {
        if (PlayerManager.Instance.playerController.hasRocket && canShoot)
        {
            CameraShake.Shake(3, 0.2f);
            FMODUnity.RuntimeManager.PlayOneShot("event:/rocketShoot");
            if (sprPlayer.flipX)
            {
                flareRockectAnimFXLeft.SetTrigger("Shoot");
            }
            else
            {
                flareRockectAnimFX.SetTrigger("Shoot");
            }
            Projectile.CreateProj(pfProjectile, spawnProjectilePoint.position, sprPlayer.flipX ? -1 : 1);
            canShoot = false;
            Invoke("ResetCanShoot", cd);

        }
    }

    private void ResetCanShoot()
    {
        canShoot = true;
    }
}
