using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFaderScript : MonoBehaviour
{
    public static SceneFaderScript instance;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator FadeAnim;

    void Awake()
    {
        MakeSigaliton();
    }

    void MakeSigaliton()
    {
        if (MusicController.instance != null)
        {
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string level)
    {
        StartCoroutine(FadeInOut(level));
    }

    IEnumerator FadeInOut(string level)
    {
        fadePanel.SetActive(true);
        FadeAnim.Play("FadeInClip");
        yield return StartCoroutine(MyCorutain.WaitForRealSeconds(1f));
        SceneManager.LoadScene(level);
        FadeAnim.Play("FadeOutClip");
        yield return StartCoroutine(MyCorutain.WaitForRealSeconds(0.7f));
        fadePanel.SetActive(false);
    }
}
