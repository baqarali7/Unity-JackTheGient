using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveWithJoyStick : MonoBehaviour
{
    public float speed = 8.0f, maxVelocity = 4.0f;
    private Rigidbody2D mybody;
    private Animator anim;

    private bool MoveLeft, MoveRight;

    private void Awake()
    {
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(MoveLeft)
        {
            Moveleft();
        }

        if(MoveRight)
        {
            Moveright();
        }
    }

    public void setMoveLeft(bool moveLeft)
    {
        this.MoveLeft = moveLeft;
        this.MoveRight = !moveLeft;
    }

    public void StopMoving()
    {
        MoveLeft = MoveRight = false;
        anim.SetBool("WalkCycle", false);
    }

    void Moveleft()
    {
        float ForceX = 0f;
        float vel = Mathf.Abs(mybody.velocity.x);

        if (vel < maxVelocity)
        {
            ForceX = -speed;
            Vector3 temp = transform.localScale;
            temp.x = -0.15f;
            transform.localScale = temp;
            anim.SetBool("WalkCycle", true);

            mybody.AddForce(new Vector2(ForceX, 0));
        }


    }

    void Moveright()
    {
        float ForceX = 0f;
        float vel = Mathf.Abs(mybody.velocity.x);

        if (vel < maxVelocity)
        {
            ForceX = speed;
            Vector3 temp = transform.localScale;
            temp.x = 0.15f;
            transform.localScale = temp;
            anim.SetBool("WalkCycle", true);

            mybody.AddForce(new Vector2(ForceX, 0));
        }
    }
}
