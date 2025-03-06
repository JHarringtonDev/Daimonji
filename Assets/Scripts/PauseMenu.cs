using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] AudioSource audioManager;
    [SerializeField] AudioSource playerAudio;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider cameraSlider;
    [SerializeField] GameObject pauseMenu;

    CameraControl cameraControl;
    bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        cameraControl = FindObjectOfType<CameraControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isActive)
            {
                activePauseMenu();
            }
            else if(isActive)
            {
                deactivatePauseMenu();
            }
        }
    }

    void activePauseMenu()
    {
        isActive = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        playerAudio.Pause();

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void deactivatePauseMenu()
    {
        isActive = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        playerAudio.Play();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void adjustVolume()
    {
        audioManager.volume = volumeSlider.value;
        playerAudio.volume = volumeSlider.value;
    }

    public void adjustSensitivity()
    {
        cameraControl.changeSensitivity(cameraSlider.value);
    }

    public bool isPaused()
    {
        return isActive;
    }
}
