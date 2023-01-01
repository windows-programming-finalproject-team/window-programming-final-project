using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] GameObject target;
    private void Update()
    {
    }
    public void DeathEvent()
    {
        target.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AudioListener.volume = 0; // mute player
    }

    private void OnCollisionEnter(Collision collision)
    {
        // player dies after touching red or lava
        if (collision.gameObject.CompareTag("death")||collision.gameObject.CompareTag("lava"))
        {
            DeathEvent();
        }
    }
}
