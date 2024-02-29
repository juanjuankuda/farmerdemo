using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartct : MonoBehaviour
{
    void Update()
    {
        // 检测玩家按下空格键
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 重新加载当前场景（即重新开始游戏）
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
        }
    }
}
