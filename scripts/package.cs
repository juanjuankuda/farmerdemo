using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class package : MonoBehaviour
{
    public GameObject ba;
    bool open = false;
    private void Start()
    {
        ba.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!open)
            {
                ba.SetActive(true);
                open = true;
            }
            else
            {
                ba.SetActive(false);
                open = false;
            }
        }
    }
}
