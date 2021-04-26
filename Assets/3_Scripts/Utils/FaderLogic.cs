using Doozy.Engine.UI;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FaderLogic : MonoSingleton<FaderLogic>
{
    [SerializeField] private Image imageFade;
    [SerializeField] private Image wallpaperEnd;

    private void Start()
    {
        imageFade.color = Color.black;
        FadeOut();
    }

    public void FadeIn()
    {
        imageFade.CrossFadeAlpha(1, 1, true);
    }

    public void FadeOut()
    {
        imageFade.CrossFadeAlpha(0, 1, true);
    }

    [Button]
    public void EndGame()
    {
        StartCoroutine(ThisIsTheEnd());
    }

    private IEnumerator ThisIsTheEnd()
    {
        imageFade.color = new Color(1, 1, 1, 0);
        imageFade.enabled = false;
        imageFade.enabled = true;
        imageFade.DOColor(Color.white, 3);
        yield return new WaitForSeconds(3);
        imageFade.DOColor(Color.black, 3);
        yield return new WaitForSeconds(3);
        wallpaperEnd.DOColor(Color.white, 1);
    }
}
