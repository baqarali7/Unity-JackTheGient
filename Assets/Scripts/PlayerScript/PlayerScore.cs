using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private AudioClip coinClip, lifeClip;

    public CameraMovement cameraMovement;

    private Vector3 previousPosition;
    private bool countScore;

    public static int scoreCount ;
    public static int lifeCount ;
    public static int coinCount;

    // Start is called before the first frame update
    void Start()
    {
       // cameraMovement = GameObject.Find("MainCamera").GetComponent<CameraMovement>();
        previousPosition = transform.position;
        countScore = true;
    }

    // Update is called once per frame
    void Update()
    {
        CountScore();
    }

    void CountScore()
    {
        if (countScore)
        {
            if (transform.position.y < previousPosition.y)
            {
                scoreCount++;
            }

            previousPosition = transform.position;
            GamePlayController.instance.setScore(scoreCount);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Coin")
        {
            coinCount++;
            scoreCount += 200;

            GamePlayController.instance.setScore(scoreCount);
            GamePlayController.instance.setCoinScore(coinCount);

            AudioSource.PlayClipAtPoint(coinClip, transform.position);
            collision.gameObject.SetActive(false);
        }
        if (collision.tag == "Life")
        {
            lifeCount++;
            scoreCount += 300;

            GamePlayController.instance.setScore(scoreCount);
            GamePlayController.instance.setLifeScore(lifeCount);

            AudioSource.PlayClipAtPoint(lifeClip, transform.position);
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Bounds" || collision.tag == "Deadly")
        {
            cameraMovement.moveCamera = false;
            countScore = false;
            transform.position = new Vector3(500, 500, 0);
            lifeCount--;

            GameManagerController.instance.CheckGameStatus(scoreCount, coinCount, lifeCount);

        }
        


    }

   
}
