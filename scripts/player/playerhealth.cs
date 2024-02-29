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

    // ���°���ͼ���״̬
    void UpdateHeartIcons()
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            heartIcons[i].SetActive(i < currentHealth); // ���ݵ�ǰ����ֵ���ð���ͼ�����ʾ״̬
        }
    }

    // ��ײ���
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("monsteratk") && !isInvincible)
        {
            TakeDamage(1); // ������Ϊ"monsteratk"��ǩ�Ĺ��﹥��ʱ������1������ֵ
        }
    }

    // ��������ֵ
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
            // �����ܻ��޵м�ʱ��
            StartCoroutine(InvincibilityTimer());
        }
    }

    // �ܻ��޵м�ʱ��
    IEnumerator InvincibilityTimer()//��û�б�Ҫʹ��Э�̣�
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
