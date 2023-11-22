using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rubycontroller : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth = 5;
    public float timeIvincible = 2.0f;
    public int health { get { return currentHealth; } }
    int currentHealth;

    bool isInvincible;
    float invinvibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    // Start is called before the first frame update

    Animator animator;
    Vector2 lookdirection = new Vector2(1, 0);
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2 (horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) ;
        {
            lookdirection.Set(move.x, move.y);
            lookdirection.Normalize();
        }
        animator.SetFloat("Look X", lookdirection.x);
        animator.SetFloat("Look Y", lookdirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (isInvincible)
        {
            invinvibleTimer -= Time.deltaTime;
            if (invinvibleTimer < 0)
            {
                isInvincible = false;
            }
             
        }

    }
    void FixedUpdate()
    {

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
   public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            animator.SetTrigger("Hit");
            if (isInvincible) 
            {
                return;
            }
            isInvincible = true;
            invinvibleTimer = timeIvincible;
        } 
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
        
    }
}