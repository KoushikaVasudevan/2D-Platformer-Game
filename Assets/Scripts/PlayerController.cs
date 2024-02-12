using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    public Animator animator;
    public int health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameOverController gameOverController;

    public float speed;

    public float jump;

    private Rigidbody2D rb2d;

    private void Awake()
    {
        Debug.Log("Player Controller Awake");
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key");
        scoreController.IncreaseScore(10);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        UpdateHealthUI(health);

        if (health <= 0)
        {
            KillPlayer();
        }
    }

    public void KillPlayer()
    {
        Debug.Log("Player Killed");

        animator.SetTrigger("PlayerDied");

        for(int i=0; i < hearts.Length; i++)
        {
            hearts[i].sprite = emptyHeart;
        }

        gameOverController.PlayerDied();
    }

    public void UpdateHealthUI(int currentHealth)
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");

        PlayerMovement(horizontal, vertical);
        PlayerAnimation(horizontal, vertical);
    }

    private void PlayerMovement(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        
        if(vertical > 0)
        {
            rb2d.AddForce(new Vector2(0, jump));
        }
    }

    private void PlayerAnimation(float horizontal, float vertical)
    {
        //Player idle/run
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Vector3 scale = transform.localScale;
        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //Player jump
        if(vertical > 0)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //Player crouch
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("Crouch");
        }
        else
        {
            animator.ResetTrigger("Crouch");
        }
    }
}
