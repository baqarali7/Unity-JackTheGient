using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
 
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector3 tempscale = transform.localScale;

        float width = sr.sprite.bounds.size.x;

        float worldHeight = Camera.main.orthographicSize * 2.0f;
        float worldWidth = worldHeight / Screen.height * Screen.width;

        tempscale.x = worldWidth / width;
        transform.localScale = tempscale;

    }

    


}
