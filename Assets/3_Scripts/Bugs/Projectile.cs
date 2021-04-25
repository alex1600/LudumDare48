using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform BoomFX;
    [SerializeField] private Vector3 boomOffset;

    public int coeffDir = 0;
    public float speed = 2;

    public void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed * coeffDir;
    }

    public static void CreateProj(Projectile prefab, Vector3 pos, int coeffDir)
    {
        Projectile proj = Instantiate(prefab, pos, Quaternion.identity, null);
        proj.coeffDir = coeffDir;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/boomRocket");
            Instantiate(BoomFX, transform.position + boomOffset, Quaternion.identity, null);
            PlayerManager.Instance.playerAttack.AddKillEnemy();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Collider"))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/boomRocket");
            Instantiate(BoomFX, transform.position + boomOffset, Quaternion.identity, null);
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Boss"))
        {
            BossLogic.Instance.nbHit++;
            FMODUnity.RuntimeManager.PlayOneShot("event:/boomRocket");
            Instantiate(BoomFX, transform.position + boomOffset, Quaternion.identity, null);
            Destroy(this.gameObject);
        }
    }
}
