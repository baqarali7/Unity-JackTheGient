using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("DestoryCollectable", 6f);
    }

    void DestoryCollectable()
    {
        gameObject.SetActive(false);
    }
}
