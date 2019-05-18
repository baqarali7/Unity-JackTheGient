using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColudSpowner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] Clouds;

    private float DistanceBetwwnClouds = 3f;
    private float minX, maxX;
    private float lastCloudPositionY;
    private float controlX;

    [SerializeField]
    private GameObject[] collectable;

    private GameObject player;

    private void Awake()
    {
        controlX = 0f;
        SetMinAndMax();
        CreateClouds();
        player = GameObject.Find("Jack");

        for(int i = 0; i < collectable.Length; i++)
        {
            collectable[i].SetActive(false);
        }
    }

    private void Start()
    {
        PositionThePlayer();
    }

    void SetMinAndMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        maxX = bounds.x - 0.5f;
        minX = -bounds.x + 0.5f;


    }
    void ShuffelGameobject (GameObject[] Shuffel)
    {
        for (int i = 0; i<Shuffel.Length; i++)
        {
            GameObject temp = Shuffel[i];
            int range = Random.Range(i, Shuffel.Length);
            Shuffel[i] = Shuffel[range];
            Shuffel[range] = temp;

        }
    }

    void CreateClouds()
    {
        ShuffelGameobject(Clouds);

        float PositionY = 0f;
        for(int i =0; i< Clouds.Length; i++)
        {
            Vector3 temp = Clouds[i].transform.position;
            temp.y = PositionY;
            if(controlX == 0)
            {
                temp.x = Random.Range(0.0f, maxX);
                controlX = 1f;

            }
            else if (controlX == 1)
            {
                temp.x = Random.Range(0.0f, minX);
                controlX = 2f;

            }
            else if (controlX == 2)
            {
                temp.x = Random.Range(1.0f, maxX);
                controlX = 3f;

            }
            else if (controlX == 3)
            {
                temp.x = Random.Range(-1.0f, minX);
                controlX = 0f;

            }

            lastCloudPositionY = PositionY;
            Clouds[i].transform.position = temp;
            PositionY -= DistanceBetwwnClouds;
        }
        

    }
    void PositionThePlayer()
    {
        GameObject[] DrakCloud = GameObject.FindGameObjectsWithTag("Deadly");
        GameObject[] CloudInGame = GameObject.FindGameObjectsWithTag("Cloud");

        for (int i = 0; i < DrakCloud.Length; i++)
        {
            if (DrakCloud[i].transform.position.y == 0)
            {
                Vector3 t = DrakCloud[i].transform.position;
                DrakCloud[i].transform.position = new Vector3(CloudInGame[0].transform.position.x, CloudInGame[0].transform.position.y, CloudInGame[0].transform.position.z);
                CloudInGame[0].transform.position = t;
            }
        }

        Vector3 temp = CloudInGame[0].transform.position;
        for (int i = 1; i < CloudInGame.Length; i++)
        {
            if (temp.y < CloudInGame[i].transform.position.y)
            {
                temp = CloudInGame[i].transform.position;
            }
        }

        temp.y += 0.8f;
        player.transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag ==  "Cloud" || target.tag == "Deadly")
        {
            if(target.transform.position.y == lastCloudPositionY)
            {
                ShuffelGameobject(Clouds);
                ShuffelGameobject(collectable);

                Vector3 temp = target.transform.position;

                for(int i = 0; i < Clouds.Length; i++)
                {
                    if (!Clouds[i].activeInHierarchy)
                    {
                        if (controlX == 0)
                        {
                            temp.x = Random.Range(0.0f, maxX);
                            controlX = 1f;

                        }
                        else if (controlX == 1)
                        {
                            temp.x = Random.Range(0.0f, minX);
                            controlX = 2f;

                        }
                        else if (controlX == 2)
                        {
                            temp.x = Random.Range(1.0f, maxX);
                            controlX = 3f;

                        }
                        else if (controlX == 3)
                        {
                            temp.x = Random.Range(-1.0f, minX);
                            controlX = 0f;

                        }

                        temp.y -= DistanceBetwwnClouds;

                        lastCloudPositionY = temp.y;

                        Clouds[i].transform.position = temp;
                        Clouds[i].SetActive(true);

                        int random = Random.Range(0, collectable.Length);

                        if(Clouds[i].tag != "Deadly")
                        {
                            if (!collectable[random].activeInHierarchy)
                            {
                                Vector3 temp2 = Clouds[i].transform.position;
                                temp2.y += 0.7f;

                                if (collectable[random].tag == "Life")
                                {
                                    if(PlayerScore.lifeCount < 2)
                                    {
                                        collectable[random].transform.position = temp2;
                                        collectable[random].SetActive(true);
                                    }

                                }
                                else
                                {
                                    collectable[random].transform.position = temp2;
                                    collectable[random].SetActive(true);
                                }
                            }

                            
                        }
                    }
                }
            }
        }
    }


}
