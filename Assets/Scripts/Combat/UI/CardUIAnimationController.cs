using System;
using UnityEngine;
public class CardUIAnimationController : MonoBehaviour
{
    private Animator _animator;
    private static readonly int CardUpPar = Animator.StringToHash("CardUp");

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    public void CardUp(bool isUp)
    {
        _animator.SetBool(CardUpPar, isUp);
    }
}
