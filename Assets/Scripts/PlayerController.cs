using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public PlayerState playerState;
    public float WalkSpeed;
    public float RunSpeed;

    private Animator animatorController;
    private Rigidbody2D playerBody;
    private Vector3 playerScale;
    private int direction;
    private bool canJump = true;
    private bool canAtack = true;
    private bool canMove;
    PlayerState previousState;


    void Awake()
    {
        animatorController = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
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
        if(canMove)
            MoveCharactor();
    }


    void MoveCharactor()
    {
        Vector3 position = transform.position;
        switch (playerState)
        {
            case PlayerState.WALK:
                position.x += direction * WalkSpeed * Time.deltaTime;
                break;
            case PlayerState.RUN:
                position.x += direction * RunSpeed * Time.deltaTime;
                break;
        }
        transform.position = position;
    }


    void ChangePlayerState(PlayerState newState, bool _canMove, int dir = 0)
    {
        playerState = newState;
        direction = dir;
        canMove = _canMove;
        //print("Player state "+ playerState);
        //print("direction value " + direction);
        //print("canMove " + canMove);
    }


    void HandlePlayerAnimation()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && playerState != PlayerState.RUN)
        {
            ClearBasicAnimations();
            SetPlayerProperties(AnimationName.WALK,1);
            ChangePlayerState(PlayerState.WALK,true,1);
            previousState = PlayerState.WALK;
        }
        else if (Input.GetKeyDown(KeyCode.D) && playerState != PlayerState.WALK)
        {
            ClearBasicAnimations();
            SetPlayerProperties(AnimationName.RUN,1);
            ChangePlayerState(PlayerState.RUN,true,1);
            previousState = PlayerState.RUN;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && playerState != PlayerState.RUN)
        {
            ClearBasicAnimations();
            SetPlayerProperties(AnimationName.WALK,-1);
            ChangePlayerState(PlayerState.WALK,true,-1);
            previousState = PlayerState.WALK;
        }  
        else if (Input.GetKeyDown(KeyCode.A) && playerState != PlayerState.WALK)
        {
            ClearBasicAnimations(); 
            SetPlayerProperties(AnimationName.RUN,-1);
            ChangePlayerState(PlayerState.RUN,true,-1);
            previousState = PlayerState.RUN;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && playerState != PlayerState.RUN || 
            Input.GetKeyUp(KeyCode.LeftArrow) && playerState != PlayerState.RUN ||
            Input.GetKeyUp(KeyCode.A) && playerState != PlayerState.WALK || 
            Input.GetKeyUp(KeyCode.D) && playerState != PlayerState.WALK)
        {
            ClearBasicAnimations();
            animatorController.SetBool(AnimationName.IDLE, true);
            ChangePlayerState(PlayerState.IDLE,false);
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
        previousState = playerState;
        ChangePlayerState(PlayerState.JUMP, canMove, direction);
        animatorController.SetBool(AnimationName.JUMP, true);
        playerBody.AddForce(new Vector2(200 * direction, 600), ForceMode2D.Force);
        yield return new WaitForSeconds(animatorController.GetCurrentAnimatorStateInfo(0).length - 0.1f);
        animatorController.SetBool(AnimationName.JUMP, false);
        ChangePlayerState(previousState, canMove, direction);
        canJump = true;
    }
    
    IEnumerator Attack()
    {
        canAtack = false;
        previousState = playerState;
        ChangePlayerState(PlayerState.ATTACK, canMove, direction);
        animatorController.SetBool(AnimationName.ATTACK, true);
        yield return new WaitForSeconds(animatorController.GetCurrentAnimatorStateInfo(0).length - .1f);
        animatorController.SetBool(AnimationName.ATTACK, false);
        ChangePlayerState(previousState, canMove, direction);
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


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            LevelOverController.Instance.GoToThisLevel(2);
        }
        else if(collision.CompareTag("Finish"))
        {
            LevelOverController.Instance.GoToThisLevel(0);
        }
        else if (collision.CompareTag("Coin"))
        {
            LevelHandler.Instance.ProcessCoin(collision.gameObject);
        }
    }

}
