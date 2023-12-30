using System;
using UnityEngine;
public class CardUIAnimationController : MonoBehaviour
{
    private Animator _animator;
    private static readonly int CardUpPar = Animator.StringToHash("CardUp");

    private static readonly int FlipSide1Par = Animator.StringToHash("FlipSide1");
    private static readonly int FlipSide2Par = Animator.StringToHash("FlipSide2");
    public GameObject cardSide1;
    public GameObject cardSide2;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void CardUp(bool isUp)
    {
        _animator.SetBool(CardUpPar, isUp);
    }

    public void StartFlipSide1()
    {
        _animator.SetTrigger(FlipSide1Par);
    }
    public void StartFlipSide2()
    {
        _animator.SetTrigger(FlipSide2Par);
    }

    /*
     * Flip to side 1
     */
    public void FlipSide1()
    {
        cardSide1.SetActive(true);
        cardSide2.SetActive(false);
    }
    
    /*
     * Flip to side 2
     */
    public void FlipSide2()
    {
        cardSide2.SetActive(true);
        cardSide1.SetActive(false);
    }
}
