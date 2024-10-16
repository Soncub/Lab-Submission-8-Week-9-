using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject sourcePrefab;
    public int defaultPoolSize = 5;
    public bool canGrow = false;
    private List<GameObject> pool;
    private int nextObject;

    private void Awake()
    {
        pool = new List<GameObject>(defaultPoolSize);
        for (int i = 0; i < defaultPoolSize; i++)
        {
            pool.Add(Instantiate(sourcePrefab));
            pool[i].SetActive(false);
        }
    }

    public GameObject Pump()
    {
        int firstTry = nextObject;
        if (!pool[nextObject].activeInHierarchy)
        {
            pool[nextObject].SetActive(true);
            return pool[nextObject];
        } 
        while (pool[nextObject].activeSelf)
        {
            nextObject++;
            if (nextObject >= pool.Count) nextObject = 0;
            if (nextObject == firstTry) break;
        }
        if (canGrow)
        {
            pool.Add(Instantiate(sourcePrefab));
            return pool[^1];
        }
        else return null;
    }



}
