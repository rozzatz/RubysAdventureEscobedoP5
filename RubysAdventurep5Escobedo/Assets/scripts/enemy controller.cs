using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    public float speed = 3.0f;
    public bool vertical;
    public float ChangeTime = 3.0f;
    public ParticleSystem smokeEffect;

    Rigidbody2D rigidbody2d;

    bool Broken = true ;

    float timer;
    int direction = 1;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        timer = ChangeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() 
    {
        if(!Broken)
        {
            return;
        }
       
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = ChangeTime;
        }
    }

   void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        if (vertical)
        {
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
            position.y = position.y + Time.deltaTime * speed * direction; 
        }
        else
        {
            animator.SetFloat("Move Y", 0);
            animator.SetFloat("Move X", direction);


            position.x = position.x + Time.deltaTime * speed * direction;
        }
        

        rigidbody2d.MovePosition(position);
    }

     void OnCollisionEnter2D(Collision2D other)
    {
        rubycontroller player = other.gameObject.GetComponent<rubycontroller>();
        if (player != null) 
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        Broken = false;
        rigidbody2d.simulated = false;
        animator.SetTrigger("fixed");
        smokeEffect.Stop();
    }

}
