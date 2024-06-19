using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RectTransformMoveTweener : MonoTweener
{
    public Vector3 positionOffset;
    private Vector3 endPosition;

    [SerializeField] RectTransform rectTransform;


    public override Tweener LocalPlay()
    {
        return rectTransform.DOMove(endPosition, duration).SetEase(animCurveEasing).SetLoops(loopNum);
    }

    // Start is called before the first frame update
    public void Awake()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
        }
        endPosition = rectTransform.position + positionOffset;
    }
}
