using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8.0f, maxVelocity = 4.0f;
    private Rigidbody2D mybody;
    private Animator anim;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float ForceX = 0f;
        float vel = Mathf.Abs(mybody.velocity.x);

        float h = Input.GetAxisRaw ("Horizontal");

        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                ForceX = speed;
                Vector3 temp = transform.localScale;
                temp.x = 0.15f;
                transform.localScale = temp;

                anim.SetBool("WalkCycle", true);
            }
        }
        else if (h < 0)
        {
            if (vel < maxVelocity)
            {
                ForceX = -speed;
                Vector3 temp = transform.localScale;
                temp.x = -0.15f;
                transform.localScale = temp;
                anim.SetBool("WalkCycle", true);
            }
        }
        else 
        {

            anim.SetBool("WalkCycle", false);
        }

        mybody.AddForce(new Vector2(ForceX, 0));

    }
}
