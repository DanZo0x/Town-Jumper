using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PoolingGenerator : MonoBehaviour
{
    [SerializeField] Transform loadingPosition;
    [SerializeField] private List<GameObject> moduleList = new List<GameObject>();
    [SerializeField] private List<GameObject> usedModule = new List<GameObject>();
    GameObject actualModule;
    public bool canSpawn;
    bool moduleNotUsed;

    void Start()
    {
        for (int i = 0; i < moduleList.Count; i++)
        {
            moduleNotUsed = false;
            while (!moduleNotUsed)
            {
                actualModule = moduleList[Random.Range(0, moduleList.Count)];
                if (!usedModule.Contains(actualModule))
                {
                    moduleNotUsed = true;
                }
            }

            usedModule.Add(actualModule);
            GameObject moduleCharged = Instantiate(actualModule);
            ObjectPooler.instance.pooledObjects.Add(moduleCharged);
            moduleCharged.transform.position = loadingPosition.position;
            loadingPosition.transform.position = loadingPosition.transform.position + new Vector3(180f, 0, 0);
            ObjectPooler.instance.modulePrefab.Add(moduleCharged);
            moduleCharged.AddComponent<ModuleObject>();

        }
    }

    void Update()
    {
        if (canSpawn)
        {
            GameObject module = ObjectPooler.instance.GetPooledObject();

            if (module != null)
            {
                module.transform.position = loadingPosition.transform.position;
                loadingPosition.transform.position = loadingPosition.transform.position + new Vector3(180f, 0, 0);
                module.SetActive(true);
                canSpawn = false;
            }
        }
    }
}
