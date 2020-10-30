using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private ParticleSystem fire1;
    [SerializeField] private ParticleSystem fire2;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Attack1()
    {
        animator.SetInteger("state", (int)AnimState.Attack1);
    }
    public void Attack2()
    {
        animator.SetInteger("state", (int)AnimState.Attack2);
    }
    public void Dance()
    {
        animator.SetInteger("state", (int)AnimState.Dance);
    }
    public void EffectPlayer1()
    {
        if (animator.GetInteger("state") == (int)AnimState.Attack1) fire1.Play(); 
    }
    public void EffectPlayer2()
    {
        fire2.Play();
    }
    public void ResetIdle()
    {
        if (GetComponent<MoveController>().isMoving == true) return;
        animator.SetInteger("state", (int)AnimState.Idle);
    }
    public void Imprison()
    {
        GetComponent<MoveController>().statelocked = true;
    }
    public void UnLockState()
    {
        GetComponent<MoveController>().statelocked = false;
    }
}
