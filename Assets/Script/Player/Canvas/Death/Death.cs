using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    [SerializeField] GameObject target;
    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            DeathEvent();
        }
    }
    public void DeathEvent()
    {
        target.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}
