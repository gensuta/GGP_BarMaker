using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ImageColorTweener : MonoTweener
{
    public Color endColor;

    [SerializeField] Image img;


    public override Tweener LocalPlay()
    {
        return img.DOColor(endColor, duration).SetEase(animCurveEasing).SetLoops(loopNum);
    }
    // Start is called before the first frame update
    public override void Start()
    {
        if (img == null)
        {
            img = GetComponent<Image>();
        }
        base.Start();
    }

}
