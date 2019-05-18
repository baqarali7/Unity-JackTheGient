using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed = 1f;
    private float accelaration = 0.2f;
    private float maxSpeed = 3.2f;

    private float easySpeed = 3.4f;
    private float mediumSpeed = 3.8f;
    private float hardSpeed = 4.2f;
    [HideInInspector]
    public bool moveCamera;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPreferences.GetEasyDifficulty() == 1)
        {
            maxSpeed = easySpeed;
        }

        if (PlayerPreferences.GetMediumDifficulty() == 1)
        {
            maxSpeed = mediumSpeed;
        }
        if (PlayerPreferences.GetHardDifficulty() == 1)
        {
            maxSpeed = hardSpeed;
        }

        moveCamera = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (moveCamera==true)
        {
            MoveCamera();
        }
    }

    void MoveCamera()
    {
        Vector3 temp = transform.position;

        float oldY = temp.y;

        float newY = temp.y - (speed * Time.deltaTime);
        temp.y = Mathf.Clamp(temp.y, oldY, newY);

        transform.position = temp;

        speed += accelaration * Time.deltaTime;

        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

   

}
