using DG.Tweening;
using Doozy.Engine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField] private List<LaserLogic> lasersLogic = new List<LaserLogic>();

    private Coroutine patternSequence;
    private void Start()
    {
        transform.DOMove(new Vector3(transform.position.x, transform.position.y + ampF, 0), speedF).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);

        patternSequence = StartCoroutine(PatternSequence());
    }

    private void Update()
    {
        if (nbHit >= phase2)
        {
            StopCoroutine(patternSequence);
            StopAllCoroutines();
            sprBoss.enabled = false;
            BloodFX.SetActive(true);
            nbHit = 0;
            StartCoroutine(Exit());
        }
    }

    private IEnumerator Exit()
    {
        CameraShake.Shake(4, 3);
        yield return new WaitForSeconds(2f);
        FaderLogic.Instance.FadeIn();
        yield return new WaitForSeconds(3f);
            FaderLogic.Instance.FadeIn();
        SceneManager.LoadSceneAsync(6);
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
        yield return new WaitForSeconds(2);
        yield return StartCoroutine(Pattern6());
        yield return new WaitForSeconds(1.75f);
        yield return StartCoroutine(Pattern7());
        yield return new WaitForSeconds(1.75f);
        yield return StartCoroutine(Pattern8());
        yield return new WaitForSeconds(1.75f);

        while (nbHit < phase2)
        {

        if (nbHit >= phase2) break;
            yield return StartCoroutine(Pattern9());
        if (nbHit >= phase2) break;
            yield return new WaitForSeconds(2.5f);
        if (nbHit >= phase2) break;
            yield return StartCoroutine(Pattern10());
        if (nbHit >= phase2) break;
            yield return new WaitForSeconds(2.5f);
        if (nbHit >= phase2) break;
            yield return StartCoroutine(Pattern11());
        if (nbHit >= phase2) break;
            yield return new WaitForSeconds(2.5f);
        }

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
            ProjectileEnemy.CreateProj(BugProjectile, spawnsPoint[i].position, Vector2.right, 5);
            if (i % 2 == 0)
                ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[i].position, Vector2.right, 4);
        }
    }
    private IEnumerator Pattern8()
    {
        yield return null;
        for (int i = spawnsPoint.Count - 1; i >= 0; i--)
        {
            yield return new WaitForFixedUpdate();
            ProjectileEnemy.CreateProj(BugProjectile, spawnsPoint[i].position, Vector2.right, 6);
            if (i % 2 != 0)
                ProjectileEnemy.CreateProj(PicProjectile, spawnsPoint[i].position, Vector2.right, 4);
        }
    }

    private IEnumerator Pattern9() // laser
    {
        yield return null;
        for (int i = 0; i < 6; i++)
        {
            yield return new WaitForSeconds(0.4f);
            lasersLogic[i].gameObject.SetActive(true);
        }
        for (int i = 11; i >= 6; i--)
        {
            yield return new WaitForSeconds(0.4f);
            lasersLogic[i].gameObject.SetActive(true);
        }
    }

    private IEnumerator Pattern10() // laser
    {
        yield return null;
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForFixedUpdate();
            lasersLogic[i].gameObject.SetActive(true);
        }
        for (int i = 7; i < lasersLogic.Count; i++)
        {
            yield return new WaitForFixedUpdate();
            lasersLogic[i].gameObject.SetActive(true);
        }
    }
    private IEnumerator Pattern11() // laser
    {
        yield return null;
        for (int i = 4; i < 8; i++)
        {
            yield return new WaitForFixedUpdate();
            lasersLogic[i].gameObject.SetActive(true);
        }
    }
}
