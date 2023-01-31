using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseTemp : MonoBehaviour
{
    [SerializeField] private InputAction pauseButton;
    [SerializeField] private Canvas pauseCanvas;

    [SerializeField] private bool isGamePaused = false;
    public bool gamePaused = false;

    private void OnEnable()
    {
        pauseButton.Enable();
    }

    private void OnDisable()
    {
        pauseButton.Disable();
    }

    private void Start()
    {
        pauseButton.performed += _ => Pause();
    }

    public void Pause()
    {
        isGamePaused = !isGamePaused;

        if (isGamePaused)
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
            gamePaused = true;
        }
        else
        {
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
            gamePaused = false;
        }
    }
}
