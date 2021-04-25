using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngrenageWallLogic : MonoSingleton<EngrenageWallLogic>
{
    [SerializeField] private SpriteRenderer sprRenderTouchInterract;
    [SerializeField] private SpriteRenderer sprRenderEngrenageCompleted;
    [SerializeField] private SpriteRenderer sprRendererAmpoule;
    [SerializeField] private SpriteRenderer sprRendererAmpouleLight;

    public int currNbEngrenage = 0;

    private bool isInRange = false;
    private bool isCompleted = false;

    public void OnAddEngrenage()
    {
        if (!isInRange || currNbEngrenage < 3) return;
        Debug.Log("COMPLETE!");
        sprRenderEngrenageCompleted.enabled = true;
        sprRendererAmpoule.enabled = false;
        sprRendererAmpouleLight.enabled = true;
        sprRenderTouchInterract.DOColor(Color.clear, 0.3f);
        isCompleted = true;
        DoorLogic.Instance.CanOpen(true);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !isCompleted)
        {
            isInRange = true;
            sprRenderTouchInterract.DOColor(Color.white, 0.3f);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !isCompleted)
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isInRange = false;
            sprRenderTouchInterract.DOColor(Color.clear, 0.3f);
        }
    }
}
