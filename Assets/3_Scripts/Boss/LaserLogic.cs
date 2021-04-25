using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    [SerializeField] private Collider2D colliderLaser;
    [SerializeField] private float laserPopWaitDuration = 0.5f;
    [SerializeField] private float laserDuration = 2f;
    [SerializeField] private LineRenderer lineRenderer = null;
    [SerializeField] private GameObject LaserBaseFXleft = null;
    [SerializeField] private GameObject LaserBaseFXright = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.Instance.playerController.OnDeath();
        }
    }

    private void OnEnable()
    {
        StartCoroutine(LaserPop());
    }

    private IEnumerator LaserPop()
    {
        yield return new WaitForSeconds(laserPopWaitDuration);
        colliderLaser.enabled = true;
        lineRenderer.enabled = true;
        LaserBaseFXleft.SetActive(true);
        LaserBaseFXright.SetActive(true);
        yield return new WaitForSeconds(laserDuration);
        lineRenderer.enabled = false;
        colliderLaser.enabled = false;
        LaserBaseFXleft.SetActive(false);
        LaserBaseFXright.SetActive(false);
        this.gameObject.SetActive(false);
    }
}
