using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : InteractiveObject
{
    private Animator animator;

    private bool isOpen = false;
    
    public Door()
    {
        displayText = nameof(Door);
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            base.InteractWith();
            animator.SetBool("shouldOpen", true);
            isOpen = true;

            displayText = ("Close Door");
        }
        else
        {
            base.InteractWith();
            animator.SetBool("shouldOpen", false);
            isOpen = false;

            displayText = ("Open Door");
        }
    }
            
 }
