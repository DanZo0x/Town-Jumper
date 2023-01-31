using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler instance;

    public List<GameObject> pooledObjects = new List<GameObject>();

    public List<GameObject> modulePrefab;

    GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < modulePrefab.Count; i++)
        {
            pooledObjects.Add(modulePrefab[i]);
        }

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }

        return null;
    }
}
