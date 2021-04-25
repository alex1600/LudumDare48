using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprRenderer;
    [SerializeField] private SortingGroup sortingGroup;
    [SerializeField] private Transform bloodFx;
    public void SetWalkStatus(bool isWalking)
    {
        animator.SetBool("Walk", isWalking);
    }

    public void SetDirection(bool isLeft)
    {
        sprRenderer.flipX = isLeft;
    }

    public void OnAnimationAscenseurDown()
    {
        sortingGroup.sortingLayerID = 0;
    }

    public void OnDeath()
    {
        playerMovement.canMove = false;
        sprRenderer.enabled = false;
        bloodFx.transform.parent = null;
        bloodFx.gameObject.SetActive(true);
        StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
