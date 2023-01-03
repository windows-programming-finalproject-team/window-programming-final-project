using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] AudioSource deathSound; 
    public static bool isDeath;
    Rigidbody rb;

    private void Start()
    {
        isDeath = false;
        rb=GetComponent<Rigidbody>();
    }
    private void Update()
    {

    }
    public void DeathEvent()
    {
        isDeath = true;
        target.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        AudioListener.pause = true; // mute player

        rb.velocity = Vector3.zero; // reset velocity of player, to prevent bug of dying with velocity

        // prevent getting muted by death menu
        deathSound.ignoreListenerPause = true;
        deathSound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // player dies after touching red or lava
        if ((collision.gameObject.CompareTag("death")||collision.gameObject.CompareTag("lava"))
            && (!ChooseDifficulty.isEasyMode))
        // can't die in easy mode
        {
            DeathEvent();
        }
    }
}
