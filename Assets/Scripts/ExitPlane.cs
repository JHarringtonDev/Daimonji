using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPlane : MonoBehaviour
{
    [SerializeField] string nextLevel;
    [SerializeField] float nextLevelTime;
    FadeScript fadeScript;

    private void Start()
    {
        fadeScript = FindObjectOfType<FadeScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MovementController>() != null)
        {
            collision.gameObject.GetComponent<MovementController>().winningDash();
            StartCoroutine(BeginNextLevel());
        }
    }

    IEnumerator BeginNextLevel()
    {
        fadeScript.FadeOut();
        yield return new WaitForSeconds(nextLevelTime);
        SceneManager.LoadScene(nextLevel);
    }
}
