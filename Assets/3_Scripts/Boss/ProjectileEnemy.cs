using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEnemy : MonoBehaviour
{
    public float speed;
    private Vector3 dir = Vector3.right;

    public void Update()
    {
        transform.position += dir * Time.deltaTime *  speed;
    }

    public static void CreateProj(ProjectileEnemy prefab, Vector3 pos, Vector2 dir)
    {
        ProjectileEnemy proj = Instantiate(prefab, pos, Quaternion.identity, null);
        proj.dir = dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.Instance.playerController.OnDeath();
        }
    }
}
