using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonLogic : MonoSingleton<SimonLogic>
{
    [SerializeField] private SpriteRenderer buttonOff;
    [SerializeField] private SpriteRenderer sprRenderTouchInterract;
    [SerializeField] private GameObject SimonDO;
    [SerializeField] private GameObject SimonRE;
    [SerializeField] private GameObject SimonFA;
    [SerializeField] private GameObject SimonSI;

    public bool SequenceLaunched = false;
    private bool isInRange = false;

    private string correctSequence = "DFRFDSRD";

    private string currSequence = "";

    public void OnHitNote(string note)
    {
        if (SequenceLaunched == true) return;

        currSequence += note;
        if (correctSequence.StartsWith(currSequence))
        { // gg
            if (currSequence.Length == correctSequence.Length)
            { // win
                DoorLogic.Instance.CanOpen(true);
                FMODUnity.RuntimeManager.PlayOneShot("event:/success");
            }
        }
        else
        { // nop
            currSequence = "";
            FMODUnity.RuntimeManager.PlayOneShot("event:/failure");
        }
    }

    public void OnStartSimonSequence()
    {
        if (!SequenceLaunched && isInRange)
        {
            SequenceLaunched = true;
            sprRenderTouchInterract.DOColor(Color.clear, 0.3f);
            StartCoroutine(SequenceSimon());
        }
    }

    IEnumerator SequenceSimon()
    {
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(LaunchNote(SimonDO));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(LaunchNote(SimonFA));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(LaunchNote(SimonRE));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(LaunchNote(SimonFA));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(LaunchNote(SimonDO));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(LaunchNote(SimonSI));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(LaunchNote(SimonRE));
        yield return new WaitForSeconds(1);
        yield return StartCoroutine(LaunchNote(SimonDO));
        yield return new WaitForSeconds(1);


        SequenceLaunched = false;
    }

    private IEnumerator LaunchNote(GameObject note)
    {
        note.SetActive(true);
        yield return new WaitForSeconds(1f);
        note.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !SequenceLaunched)
        {
            isInRange = true;
            sprRenderTouchInterract.DOColor(Color.white, 0.3f);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !SequenceLaunched)
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
