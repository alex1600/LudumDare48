using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSimonLogic : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sprRenderTouchInterract;
    [SerializeField] private GameObject note;
    [SerializeField] private GameObject spriteOn;
    [SerializeField] private SpriteRenderer spriteOff;
    [SerializeField] private string strNote = "";

    private bool noteLaunched = false;
    private bool isInRange = false;
    public void OnStartSimonSequence()
    {
        if (!SimonLogic.Instance.SequenceLaunched && isInRange && !noteLaunched)
        {
            noteLaunched = true;
            sprRenderTouchInterract.DOColor(Color.clear, 0.3f);
            spriteOn.SetActive(true);
            spriteOff.enabled = false;
            SimonLogic.Instance.OnHitNote(strNote);
            StartCoroutine(LaunchNote(note));
        }
    }

    private IEnumerator LaunchNote(GameObject note)
    {
        note.SetActive(true);
        yield return new WaitForSeconds(1f);
        note.SetActive(false);
        spriteOn.SetActive(false);
        spriteOff.enabled = true;
        noteLaunched = false;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !noteLaunched)
        {
            isInRange = true;
            sprRenderTouchInterract.DOColor(Color.white, 0.3f);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !noteLaunched)
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
