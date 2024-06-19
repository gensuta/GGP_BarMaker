using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MultiTweener : MonoBehaviour
{
    [SerializeField] private MonoTweener[] tweeners;
    public bool playOnAwake;

    private void Awake()
    {
        if (tweeners == null || tweeners.Length == 0)
        {
            tweeners = transform.GetComponentsInChildren<MonoTweener>();
        }


        if(playOnAwake)
        {
            Play();
        }
    }


    public void Play()
    {
        foreach (var tweener in tweeners)
        { tweener.Play(); }
    }
}
