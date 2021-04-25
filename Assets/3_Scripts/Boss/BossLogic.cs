using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public int hp = 100;

    public float speedF = 1;
    public float ampF = 1;

    [SerializeField] private ProjectileEnemy BugProjectile;
    [SerializeField] private ProjectileEnemy PicProjectile;
    [SerializeField] private ProjectileEnemy SawProjectile;

    [SerializeField] private List<Transform> spawnsPoint = new List<Transform>();

    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + ampF, 0), speedF).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);

        StartCoroutine(Pattern1());
    }

    private void Update()
    {
        //transform.position += transform.up * Mathf.Sin(Time.deltaTime * speedF) * ampF;    
    }


    private IEnumerator Pattern1()
    {
        yield return null;
        for (int i = 0; i < spawnsPoint.Count - 1; i++)
        {
            yield return new WaitForSeconds(0.5f);
            ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[i].position, Vector2.right);
        }
    }
}
