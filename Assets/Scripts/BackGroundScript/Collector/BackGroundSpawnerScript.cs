using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundSpawnerScript : MonoBehaviour
{
    private GameObject[] Background;

    private float LastY;
    
    void Start()
    {
        GetBackgroundAndSetLastY();
    }

   void GetBackgroundAndSetLastY()
    {
        Background = GameObject.FindGameObjectsWithTag("BackGround");
        LastY = Background[0].transform.position.y;
        for(int i =1; i < Background.Length; i++)
        {
            if(LastY > Background[i].transform.position.y)
            {
                LastY = Background[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "BackGround")
        {
            if(collision.transform.position.y == LastY)
            {
                Vector3 temp = collision.transform.position;
                float height = 10.0f;

                for(int i = 0; i < Background.Length; i++)
                {
                    if(!Background[i].activeInHierarchy)
                    {
                        temp.y -= height;

                        LastY = temp.y;

                        Background[i].transform.position = temp;

                        Background[i].SetActive(true);

                    }
                }
            }
        }
    }
}
