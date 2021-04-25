using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SawLogic : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float durationLoop = 3;
    [SerializeField] private float delayBeforeLoop = 1;

    private bool inf = true;
    private Sequence seq;

    // Start is called before the first frame update
    void Start()
    {
        seq = DOTween.Sequence();
        seq.Append(transform.DOMove(startPoint.position, 0).SetEase(Ease.InQuad));
        seq.AppendInterval(delayBeforeLoop);
        seq.Append(transform.DOMove(endPoint.position, durationLoop).SetEase(Ease.InOutQuad));
        seq.AppendInterval(delayBeforeLoop);
        seq.Append(transform.DOMove(startPoint.position, durationLoop).SetEase(Ease.InOutQuad));
        seq.SetLoops(-1, LoopType.Restart);
        seq.Play();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("HIT");
            PlayerManager.Instance.playerController.OnDeath();
        }
    }
}
