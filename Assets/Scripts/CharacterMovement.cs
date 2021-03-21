using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float movementSpeed = 4f;

    Vector2 movementDirection;
    Vector2 lastMovementDirection;
    Vector2 interactPosition;
    Vector2 interactSize = new Vector2(0.2f, 0.2f);

    Rigidbody2D playerRigidbody;

    Animator playerAnimation;

    Sprite playerSprite;

    void Awake()
    {
        playerAnimation = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<Sprite>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) /*|| Input.GetButtonDown("Fire1")*/)
        {
            Collider2D tmpInteract = Physics2D.OverlapBox(interactPosition, interactSize, 0f);
            if (tmpInteract != null && tmpInteract.GetComponent<IInteractable>() != null)
            {
                tmpInteract.GetComponent<IInteractable>().Interact();

            }
        }
    }


    void FixedUpdate()
    {
        movementDirection = (Vector2.up * Input.GetAxisRaw("Vertical") +
                            Vector2.right * Input.GetAxisRaw("Horizontal"))
                            .normalized;

        interactPosition = playerRigidbody.position + (lastMovementDirection / 3);

        //transform.position += movementDirection * movementSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(playerRigidbody.position + movementDirection * movementSpeed * Time.fixedDeltaTime);


        if (movementDirection.sqrMagnitude > 0)
        {
            lastMovementDirection = movementDirection;
            playerAnimation.SetFloat("Horizontal", movementDirection.x);
            playerAnimation.SetFloat("Vertical", movementDirection.y);
            playerAnimation.SetBool("PlayerMoves", true);
        }
        else
        {
            playerAnimation.SetBool("PlayerMoves", false);
        }
    }

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(playerRigidbody.position, interactPosition);

            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(interactPosition, new Vector2(0.2f, 0.2f));
        }
    }

}
