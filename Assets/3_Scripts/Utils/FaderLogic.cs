using Doozy.Engine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaderLogic : MonoSingleton<FaderLogic>
{
    [SerializeField] private Image imageFade;

    private void Start()
    {
        imageFade.color = Color.black;
        FadeOut();
    }

    public void FadeIn()
    {
        imageFade.CrossFadeAlpha(1, 1, false);
    }

    public void FadeOut()
    {
        imageFade.CrossFadeAlpha(0, 1, false);
    }
}
