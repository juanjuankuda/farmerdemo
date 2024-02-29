using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerhealth : MonoBehaviour
{
    public int maxHealth = 3; 
    private int currentHealth; 
    public float invincibilityTime = 2.0f; 
    private bool isInvincible = false; 
    public GameObject[] heartIcons; 
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
        UpdateHeartIcons(); 
    }

    // 更新爱心图标的状态
    void UpdateHeartIcons()
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].SetActive(i < currentHealth); // 根据当前生命值设置爱心图标的显示状态
        }
    }

    // 碰撞检测
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("monsteratk") && !isInvincible)
        {
            TakeDamage(1); // 碰到名为"monsteratk"标签的怪物攻击时，减少1点生命值
        }
    }

    // 减少生命值
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHeartIcons();

        if (currentHealth <= 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            //GetComponent<Animator>().SetTrigger("Die");
            //StartCoroutine(DestroyAfterAnimation());
        }
        else
        {
            // 启动受击无敌计时器
            StartCoroutine(InvincibilityTimer());
        }
    }

    // 受击无敌计时器
    IEnumerator InvincibilityTimer()//有没有必要使用协程？
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }

    /*IEnumerator DestroyAfterAnimation()
    {
        Animator anim = GetComponent<Animator>();
        if (anim != null)
        {
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
            Destroy(gameObject);
        }
    }*/
}
