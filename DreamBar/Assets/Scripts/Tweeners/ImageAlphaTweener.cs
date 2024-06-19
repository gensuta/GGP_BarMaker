using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageAlphaTweener : MonoTweener
{
    public float alpha;

    [SerializeField] Image img;


    public override Tweener LocalPlay()
    {
        return img.DOFade(alpha, duration).SetEase(animCurveEasing).SetLoops(loopNum);
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
