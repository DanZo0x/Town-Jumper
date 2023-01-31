using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleObject : MonoBehaviour
{
    PoolingGenerator generator;
    GameObject player;

    void Start()
    {
        generator = GameObject.FindGameObjectWithTag("ModuleGenerator").GetComponent<PoolingGenerator>(); ;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distFromPlayer = (player.transform.position.x - gameObject.transform.position.x);
        if (distFromPlayer > 195)
        {
            generator.canSpawn = true;
            gameObject.SetActive(false);
        }
    }
}