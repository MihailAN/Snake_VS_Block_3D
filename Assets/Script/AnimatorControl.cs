using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    Animator animator;

    [SerializeField]
    private bool moveTail;

    private bool move;
    private bool lost;

    private void Awake()
    {
        animator = GetComponent<Animator>();        
    }
    public void StartMoving()
    {
        move = true;
    }
    public void lostPlaer()
    {
        move = false;
        lost = true;
    }
    public void TailMoving()
    {
        moveTail = true;
    }
    private void LateUpdate()
    {
        animator.SetBool("Move", move);
        animator.SetBool("Lost", lost);
        animator.SetBool("MoveTail", moveTail);
    }

}
