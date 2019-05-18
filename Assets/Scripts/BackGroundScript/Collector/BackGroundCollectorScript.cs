using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundCollectorScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BackGround")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
