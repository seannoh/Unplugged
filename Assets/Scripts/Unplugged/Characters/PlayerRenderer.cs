using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    private Animator animator;
    private E_AllKeysActs currentDirection;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayIdleAnimation(Vector2Int pointDirection)
    {
        switch(pointDirection.ToString())
        {
            case "(0, 1)":
                animator.Play("adam_idle_up");
                break;
            case "(0, -1)":
                animator.Play("adam_idle_down");
                break;
            case "(-1, 0)":
                animator.Play("adam_idle_left");
                break;
            case "(1, 0)":
                animator.Play("adam_idle_right");
                break;
            default:
                animator.Play("adam_idle_down");
                break;
        }
    }

    public void PlayRunAnimation(Vector2Int moveDirection)
    {
        switch(moveDirection.ToString())
        {
            case "(0, 1)":
                animator.Play("adam_run_up");
                break;
            case "(0, -1)":
                animator.Play("adam_run_down");
                break;
            case "(-1, 0)":
                animator.Play("adam_run_left");
                break;
            case "(1, 0)":
                animator.Play("adam_run_right");
                break;
            default:
                animator.Play("adam_run_down");
                break;
        }
    }
}
