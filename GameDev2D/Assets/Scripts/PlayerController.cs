using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D player1, player2;
    private SpriteRenderer sr1, sr2;
    private Animator animator;

    public float playerSpeed = 5f;
    public float playerJump = 10f;

    private enum Movement { idle, moving, jumping, falling };

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player1").GetComponent<Rigidbody2D>();
        player2 = GameObject.Find("Player2").GetComponent<Rigidbody2D>();

        sr1 = GameObject.Find("Player1").GetComponent<SpriteRenderer>();
        sr2 = GameObject.Find("Player2").GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX1 = Input.GetAxisRaw("Horizontal");
        float dirX2 = Input.GetAxisRaw("Horizontal2");

        player1.velocity = new Vector2(dirX1 * playerSpeed, player1.velocity.y);
        player2.velocity = new Vector2(dirX2 * playerSpeed, player2.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            player1.velocity = new Vector2(player1.velocity.x, playerJump);
        }

        if (Input.GetKeyDown("w"))
        {
            player2.velocity = new Vector2(player2.velocity.x, playerJump);
        }

        Movement movement1, movement2;

        if (dirX1 != 0)
        {
            movement1 = Movement.moving;
            if (dirX1 < 0)
                sr1.flipX = true;
            else
                sr1.flipX = false;
        }
        else
        {
            movement1 = Movement.idle;
        }

        if (player1.velocity.y > .1f)
        {
            movement1 = Movement.jumping;
        }
        else if (player1.velocity.y < -.1f)
        {
            movement1 = Movement.falling;
        }


        if (dirX2 != 0)
        {
            movement2 = Movement.moving;
            if (dirX2 < 0)
                sr2.flipX = true;
            else
                sr2.flipX = false;
        }
        else
        {
            movement2 = Movement.idle;
        }

        if (player2.velocity.y > .1f)
        {
            movement2 = Movement.jumping;
        }
        else if (player2.velocity.y < -.1f)
        {
            movement2 = Movement.falling;
        }


        animator.SetInteger("movement1", (int)movement1);
        animator.SetInteger("movement2", (int)movement2);

    }
}
