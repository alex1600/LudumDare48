using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngrenageLogic : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprRendererTouchInterract;
    private bool isInRange = false;
    private bool isLoot = false;


    public void OnLoot()
    {
        if (isInRange && !isLoot)
        {
            isLoot = true;
            Debug.Log("Looot!");
            EngrenageWallLogic.Instance.currNbEngrenage++;
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
