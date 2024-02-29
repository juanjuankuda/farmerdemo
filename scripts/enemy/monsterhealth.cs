using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class monsterhealth : MonoBehaviour
{
    public GameObject destructionEffect;
    public ObjectPool<GameObject> pool;
    public GameObject deathEffect;//µÙ¬‰ŒÔ
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            DestroyMonster();
        }
    }

    private void DestroyMonster()
    {
        if (destructionEffect != null)
        {
            Instantiate(destructionEffect, transform.position, Quaternion.identity);
        }

        pool.Release(gameObject);

        GameObject newCoin = Instantiate(deathEffect,transform.position, Quaternion.identity);
    }
}

