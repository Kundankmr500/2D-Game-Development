using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Animator animatorController;
    public PlayerState playerState;

    private Vector3 playerScale;
    private bool canJump = true;
    private bool canAtack = true;
    
    void Awake()
    {
        animatorController = GetComponent<Animator>();
        playerScale = transform.localScale;
        InitPlayerState(PlayerState.IDLE);
    }


    void InitPlayerState(PlayerState initialState)
    {
        playerState = initialState;
        
        switch (playerState)
        {
            case PlayerState.IDLE:
                animatorController.SetBool(AnimationName.IDLE, true);
                break;
            case PlayerState.WALK:
                animatorController.SetBool(AnimationName.WALK, true);
                break;
            case PlayerState.RUN:
                animatorController.SetBool(AnimationName.RUN, true);
                break;
            case PlayerState.JUMP:
                animatorController.SetBool(AnimationName.JUMP, true);
                break;
            case PlayerState.ATTACK:
                animatorController.SetBool(AnimationName.ATTACK, true);
                break;
        }
    }


    void Update()
    {
        HandlePlayerAnimation();
    }


    void HandlePlayerAnimation()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ClearBasicAnimations();
            SetPlayerProperties(AnimationName.WALK,1);
            playerState = PlayerState.WALK;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ClearBasicAnimations();
            SetPlayerProperties(AnimationName.RUN,1);
            playerState = PlayerState.RUN;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ClearBasicAnimations();
            SetPlayerProperties(AnimationName.WALK,-1);
            playerState = PlayerState.WALK;
        }  
        else if (Input.GetKeyDown(KeyCode.A))
        {
            ClearBasicAnimations();
            SetPlayerProperties(AnimationName.RUN,-1);
            playerState = PlayerState.RUN;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) ||
            Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            ClearBasicAnimations();
            animatorController.SetBool(AnimationName.IDLE, true);
            playerState = PlayerState.IDLE;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            StartCoroutine(Jump());
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift) && canAtack)
        {
            StartCoroutine(Attack());
        }

        transform.localScale = playerScale;
    }


    IEnumerator Jump()
    {
        canJump = false;
        animatorController.SetBool(AnimationName.JUMP, true);
        playerState = PlayerState.JUMP;
        yield return new WaitForSeconds(animatorController.GetCurrentAnimatorStateInfo(0).length - 0.1f);
        animatorController.SetBool(AnimationName.JUMP, false);
        canJump = true;
    }
    
    IEnumerator Attack()
    {
        canAtack = false;
        animatorController.SetBool(AnimationName.ATTACK, true);
        playerState = PlayerState.ATTACK;
        yield return new WaitForSeconds(animatorController.GetCurrentAnimatorStateInfo(0).length - .1f);
        animatorController.SetBool(AnimationName.ATTACK, false);
        canAtack = true;
    }

    void SetPlayerProperties(string animationName, int direction)
    {
        playerScale.x = direction * Math.Abs(playerScale.x);
        animatorController.SetBool(animationName, true);
    }

    void ClearBasicAnimations()
    {
        animatorController.SetBool(AnimationName.WALK, false);
        animatorController.SetBool(AnimationName.RUN, false);
        animatorController.SetBool(AnimationName.IDLE, false);
    }
    
}
