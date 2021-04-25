using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoSingleton<DoorLogic>
{
    [SerializeField] private bool canOpen;
    [SerializeField] private SpriteRenderer sprRenderTouchInterract;

    [SerializeField] private Transform tpPoint;

    private bool isInRange = false;
    private Coroutine tpPlayerCoroutine = null;

    public void CanOpen(bool status)
    {
        canOpen = status;
    }

    public void OnTPPlayer()
    {
        if (isInRange && canOpen && tpPlayerCoroutine == null)
        {
            tpPlayerCoroutine = StartCoroutine(TPPlayer());
        }
    }

    private IEnumerator TPPlayer()
    {
        PlayerManager.Instance.playerMovement.canMove = false;
        FaderLogic.Instance.FadeIn();
        yield return new WaitForSeconds(1.25f);
        Camera.main.transform.position = tpPoint.position;
        PlayerManager.Instance.transform.position = tpPoint.position;
        PlayerManager.Instance.playerMovement.canMove = true;
        FaderLogic.Instance.FadeOut();
        Debug.Log("FadeOut");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && canOpen)
        {
            isInRange = true;
            sprRenderTouchInterract.DOColor(Color.white, 0.3f);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && canOpen)
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
