using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    FadeScript fadeScript;
    [SerializeField] float transitionTime;

    private void Awake()
    {
        fadeScript = FindObjectOfType<FadeScript>();
    }
    public void StartGame()
    {
        fadeScript.FadeOut();
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Level 1");
    }
}
