using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonoTweener : MonoBehaviour
{
    public AnimationCurve animCurveEasing;

    public float duration = 1;


    public bool willLoop = false;
    [HideInInspector] public int loopNum;

    public bool playAtAwake = false;

    private Tweener tweener;

    public virtual void Start()
    {
        loopNum = (willLoop) ? -1 : 0;

        if (playAtAwake)
        {
            Play();
        }
    }

    public virtual void Play()
    {
        tweener = LocalPlay();
    }

    public virtual Tweener LocalPlay()
    {
        return null;
    }

    public virtual void Kill()
    {
        tweener.Kill();
    }
}
