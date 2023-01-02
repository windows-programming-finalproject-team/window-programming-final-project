using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] AudioSource deathSound;
    private void Update()
    {
    }
    public void DeathEvent()
    {
        target.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AudioListener.pause = true; // mute player

        // prevent getting muted by death menu
        deathSound.ignoreListenerPause = true;
        deathSound.Play();
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
