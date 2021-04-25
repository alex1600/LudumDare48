using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRocketLoot : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprRendererTouchInterract;
    private bool isInRange = false;
    private bool isLoot = false;
    public void OnLoot()
    {
        if (isInRange && !isLoot)
        {
            isLoot = true;
            PlayerManager.Instance.playerController.SetRocketStatus(true);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isInRange = true;
            sprRendererTouchInterract.DOColor(Color.white, 0.3f);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isInRange = false;
            sprRendererTouchInterract.DOColor(Color.clear, 0.3f);
        }
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
