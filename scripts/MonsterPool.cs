using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Pool;

public class MonsterPool : MonoBehaviour
{
    public GameObject MonsterPrefab; // 需要池化的对象预制体
    public float spawnInterval;
    public float spawnTimel;
    private ObjectPool<GameObject> pool;
    [SerializeField] private int maxsize = 10;
    private int count = 0;

    private void Start()
    {
        pool = new ObjectPool<GameObject>(createFunc, actionOnGet, actionOnRelease, actionOnDestroy, true, 10, 100);
    }

    private void actionOnDestroy(GameObject sth)//用不到
    {
        Destroy(sth);
    }

    private void actionOnRelease(GameObject sth)
    {
        sth.gameObject.SetActive(false);
        count--;
    }

    private void actionOnGet(GameObject sth)
    {
        sth.gameObject.SetActive(true);
        count++;
    }

    GameObject  createFunc()
    {
        var sth = Instantiate(MonsterPrefab, transform);
        sth.GetComponent<monsterhealth>().pool = pool;
        return sth;
    }
    private void Update()
    {
        spawnTimel += Time.deltaTime;
        if (spawnTimel > spawnInterval)
        {
            spawnTimel -= spawnInterval;
            if(count < maxsize)
            {
                Spawn();
            }

        }
    }

    private void Spawn()
    {
        GameObject temp = pool.Get();
    }
}
