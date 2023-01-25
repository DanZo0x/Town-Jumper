using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class QTESystem : MonoBehaviour
{

    [Header("QTE Variables")]
    [SerializeField] int qteRNG;
    [SerializeField] float qteTime = 2f;
    [SerializeField] float currentTime = 0f;
    [SerializeField] bool hasPressedRightQTE = false;

    [Space]
    [Header("References")]
    [SerializeField] private PlayerInput playinp;

    private void Awake()
    {
        playinp = GetComponent<PlayerInput>();
    }

    private void Start()
    {
        currentTime = qteTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
        Debug.Log("Timer started");

        for (float i = timeRemaining; i > 0; i--)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(1);
        }
        Debug.Log("Timer finished");
    }
}