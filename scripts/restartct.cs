using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartct : MonoBehaviour
{
    void Update()
    {
        // �����Ұ��¿ո��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ���¼��ص�ǰ�����������¿�ʼ��Ϸ��
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
