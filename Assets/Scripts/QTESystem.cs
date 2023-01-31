using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QTESystem : MonoBehaviour
{

    [Header("QTE Variables")]
    [SerializeField] int qteRNG = 0;
    [SerializeField] float qteTime = 2f;
    [SerializeField] float currentTime = 0f;

    [Space]
    [Header("References")]
    [SerializeField] private PlayerInput playinp;
    [SerializeField] private PlayerMovement playmov;
    [SerializeField] private PauseTemp pausegame;

    private void Awake()
    {
        playinp = GameObject.Find("Prototype Character").GetComponent<PlayerInput>();
        playmov = GameObject.Find("Prototype Character").GetComponent<PlayerMovement>();
        pausegame = GameObject.Find("PauseManager").GetComponent<PauseTemp>();
    }

    private void Start()
    {
        currentTime = qteTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        qteRNG = 0;
        qteRNG = Random.Range(1, 5);
        // 1 - QTE Up
        // 2 - QTE Down
        // 3 - QTE Left
        // 4 - QTE Right
        Debug.Log("QTE to press: " + qteRNG);

        qteTime = 2f;
        StartCoroutine(QteTimer(qteTime));
    }

    IEnumerator QteTimer(float timeRemaining)
    {
        Time.timeScale = 0.2f;
        playmov.qteUpPressed = false;
        playmov.qteDownPressed = false;
        playmov.qteLeftPressed = false;
        playmov.qteRightPressed = false;

        for (float i = timeRemaining; i > 0; i--)
        {
            if (pausegame.gamePaused)
            {
                yield return new WaitUntil(() => !pausegame.gamePaused);
            }
            Time.timeScale = 0.2f;
            yield return new WaitForSecondsRealtime(0.5f);
        }

        if (playmov.qteUpPressed && qteRNG == 1)
        {
            Debug.Log("QTE Up Success!");
            Time.timeScale = 1f;
        }
        else if (playmov.qteDownPressed && qteRNG == 2)
        {
            Debug.Log("QTE Down Success!");
            Time.timeScale = 1f;
        }
        else if (playmov.qteLeftPressed && qteRNG == 3)
        {
            Debug.Log("QTE Left Success!");
            Time.timeScale = 1f;
        }
        else if (playmov.qteRightPressed && qteRNG == 4)
        {
            Debug.Log("QTE Right Success!");
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("QTE Fail...");
            if (!pausegame.gamePaused)
            {
                Time.timeScale = 1f;
            }
        }

        qteRNG = 0;
    }
}