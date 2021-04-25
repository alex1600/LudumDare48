using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoSingleton<BossLogic>
{
    public int phase1 = 10;
    public int phase2 = 20;
    public int nbHit = 0;
    public float speedF = 1;
    public float ampF = 1;

    [SerializeField] private GameObject BloodFX;
    [SerializeField] private SpriteRenderer sprBoss;

    [SerializeField] private ProjectileEnemy BugProjectile;
    [SerializeField] private ProjectileEnemy PicProjectile;
    [SerializeField] private ProjectileEnemy SawProjectile;

    [SerializeField] private List<Transform> spawnsPoint = new List<Transform>();

    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + ampF, 0), speedF).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);

        StartCoroutine(PatternSequence());
    }

    private IEnumerator PatternSequence()
    {
        while (nbHit < phase1)
        {
            yield return StartCoroutine(Pattern1());
            if (nbHit >= phase1) break;
            yield return new WaitForSeconds(0.85f);
            if (nbHit >= phase1) break;
            yield return StartCoroutine(Pattern2());
            if (nbHit >= phase1) break;
            yield return new WaitForSeconds(1.35f);
            if (nbHit >= phase1) break;
            yield return StartCoroutine(Pattern3());
            if (nbHit >= phase1) break;
            yield return new WaitForSeconds(0.85f);
            if (nbHit >= phase1) break;
            yield return StartCoroutine(Pattern4());
            if (nbHit >= phase1) break;
            yield return new WaitForSeconds(0.5f);
            if (nbHit >= phase1) break;
            yield return StartCoroutine(Pattern5());
        }
        while (nbHit < phase2)
        {
            yield return new WaitForSeconds(2);
            yield return StartCoroutine(Pattern6());
            yield return new WaitForSeconds(1.75f);
            yield return StartCoroutine(Pattern7());
            yield return new WaitForSeconds(1.75f);
            yield return StartCoroutine(Pattern8());
        }
        sprBoss.enabled = false;
        BloodFX.SetActive(true);
    }

    private IEnumerator Pattern1()
    {
        yield return null;
        for (int i = 0; i < spawnsPoint.Count; i++)
        {
            yield return new WaitForSeconds(0.6f);
            ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[i].position, Vector2.right, 6);
        }
    }

    private IEnumerator Pattern2()
    {
        yield return null;
        for (int i = spawnsPoint.Count - 4; i >= 0; i--)
        {
            yield return new WaitForSeconds(0.075f);
            ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[i].position, Vector2.right, 5);
        }
    }
    private IEnumerator Pattern3()
    {
        yield return null;
        for (int i = 3; i < spawnsPoint.Count; i++)
        {
            yield return new WaitForSeconds(0.075f);
            ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[i].position, Vector2.right, 5);
        }
    }
    private IEnumerator Pattern4()
    {
        yield return null;
        for (int i = 0; i < spawnsPoint.Count; i++)
        {
            yield return new WaitForSeconds(0.6f);
            ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[spawnsPoint.Count - i - 1].position, Vector2.right, 6);
        }
    }
    private IEnumerator Pattern5()
    {
        yield return null;
        for (int i = 0; i < spawnsPoint.Count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                yield return new WaitForSeconds(0.15f);
                ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[i].position, Vector2.right, 6);
            }
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = spawnsPoint.Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < 3; j++)
            {
                yield return new WaitForSeconds(0.15f);
                ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[i].position, Vector2.right, 6);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    private IEnumerator Pattern6()
    {
        yield return null;
        for (int i = 0; i < spawnsPoint.Count; i++)
        {
            yield return new WaitForFixedUpdate();
            ProjectileEnemy.CreateProj(BugProjectile, spawnsPoint[spawnsPoint.Count - i - 1].position, Vector2.right, 5);
        }
    }

    private IEnumerator Pattern7()
    {
        yield return null;
        for (int i = 0; i < spawnsPoint.Count; i++)
        {
            yield return new WaitForFixedUpdate();
            ProjectileEnemy.CreateProj(BugProjectile, spawnsPoint[spawnsPoint.Count - i - 1].position, Vector2.right, 5);
            if (i % 2 == 0)
                ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[spawnsPoint.Count - i - 1].position, Vector2.right, 4);
        }
    }
    private IEnumerator Pattern8()
    {
        yield return null;
        for (int i = spawnsPoint.Count - 1; i >= 0; i--)
        {
            yield return new WaitForFixedUpdate();
            ProjectileEnemy.CreateProj(BugProjectile, spawnsPoint[spawnsPoint.Count - i - 1].position, Vector2.right, 6);
            if (i % 2 != 0)
                ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[spawnsPoint.Count - i - 1].position, Vector2.right, 4);
        }
    }
}
