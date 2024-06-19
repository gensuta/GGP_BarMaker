using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RectTransformScaleTweener : MonoTweener
{
    public Vector3 scaleOffset;
    private Vector3 endScale;

    [SerializeField] RectTransform rectTransform;


    public override Tweener LocalPlay()
    {
        return rectTransform.DOScale(endScale, duration).SetEase(animCurveEasing).SetLoops(loopNum,LoopType.Yoyo);
    }

    // Start is called before the first frame update
    public void Awake()
    {
        if(rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }
        endScale = transform.localScale + scaleOffset;
        base.Start();
    }
}
