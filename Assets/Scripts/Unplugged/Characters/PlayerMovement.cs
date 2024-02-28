using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    //movement lock flag
    public bool isMovementLocked = false;

    private Rigidbody2D rb;
    private PlayerRenderer playerRenderer;
    private Vector2Int moveDirection;
    private Vector2Int pointDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerRenderer = GetComponent<PlayerRenderer>();

        // Event listener
        EventMgr.Instance.AddEventListener<TextAsset>("DialogueStart", MovementLock);
        EventMgr.Instance.AddEventListener("DialogueEnd", MovementUnlock);

        MovementUnlock();
    }

    void Update()
    {
        if(isMovementLocked) return;
        if(Input.GetKey(KeyCode.W)) {
            moveDirection = Vector2Int.up;
            pointDirection = moveDirection;
            playerRenderer.PlayRunAnimation(moveDirection);
        } else if(Input.GetKey(KeyCode.S)) {
            moveDirection = Vector2Int.down;
            pointDirection = moveDirection;
            playerRenderer.PlayRunAnimation(moveDirection);
        } else if(Input.GetKey(KeyCode.A)) {
            moveDirection = Vector2Int.left;
            pointDirection = moveDirection;
            playerRenderer.PlayRunAnimation(moveDirection);
        } else if(Input.GetKey(KeyCode.D)) {
            moveDirection = Vector2Int.right;
            pointDirection = moveDirection;
            playerRenderer.PlayRunAnimation(moveDirection);
        } else {
            moveDirection = Vector2Int.zero;
            playerRenderer.PlayIdleAnimation(pointDirection);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMovementLocked) return;
        rb.position += Time.deltaTime * speed * ((Vector2)moveDirection).normalized;
    }

    void OnDestroy()
    {
        EventMgr.Instance.RemoveEventListener<TextAsset>("DialogueStart", MovementLock);
        EventMgr.Instance.RemoveEventListener("DialogueEnd", MovementUnlock);
    }


    private void MovementLock(TextAsset _)
    {
        isMovementLocked = true;
    }

    private void MovementUnlock()
    {
        isMovementLocked = false;
    }


}
