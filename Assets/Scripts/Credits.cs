using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    FadeScript fadeScript;
    [SerializeField] float transitionTime;

    private void Awake()
    {
        fadeScript = FindObjectOfType<FadeScript>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        fadeScript.FadeOut();
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene("Title Screen");
    }
}
