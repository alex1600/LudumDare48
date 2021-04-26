using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AscenseurControllerLogic : MonoSingleton<AscenseurControllerLogic>
{
    [SerializeField] private Animator animator;
    [SerializeField] private Transform tfBlockAscenseur;
    [SerializeField] private int sceneIndex;
    [SerializeField] private bool endGame = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SetStatusDoor(false);
            if (endGame)
            {
                StartCoroutine(GoUp());

            }
            else
            {
                StartCoroutine(GoDown());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SetStatusDoor(false);
        }
    }

    public void SetStatusDoor(bool status)
    {
        animator.SetBool("isOpen", status);
    }

    private IEnumerator GoDown()
    {
        PlayerManager.Instance.playerController.OnAnimationAscenseurDown();
        yield return new WaitForSeconds(1f);
        tfBlockAscenseur.DOMove(tfBlockAscenseur.position + Vector3.down * 2, 3);
        PlayerManager.Instance.transform.DOMove(tfBlockAscenseur.position + Vector3.down * 2, 3);
        FaderLogic.Instance.FadeIn();
        StartCoroutine(LoadNextScene());
    }
    private IEnumerator GoUp()
    {
        FaderLogic.Instance.EndGame();
        PlayerManager.Instance.playerController.OnAnimationAscenseurDown();
        yield return new WaitForSeconds(1f);
        tfBlockAscenseur.DOMove(tfBlockAscenseur.position + Vector3.up * 2, 3);
        PlayerManager.Instance.transform.DOMove(tfBlockAscenseur.position + Vector3.up * 2, 3);
    }

    private IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
    }
}
