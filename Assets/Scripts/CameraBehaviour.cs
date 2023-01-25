using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [Space]
    [Header("Forward Movement")]
    [SerializeField] private float speedMultiplier = 1;
    [SerializeField] private float progressiveSpeedMultiplier = 1;
    [SerializeField] private float slowDownFactor = 1;

    void Update()
    {
        speedMultiplier += Time.deltaTime / 15;
        speedMultiplier = Mathf.Clamp(speedMultiplier, 3, 5);

        transform.position += new Vector3(1, 0, 0) * Time.deltaTime * 4 * speedMultiplier / slowDownFactor * progressiveSpeedMultiplier;
    }
}
