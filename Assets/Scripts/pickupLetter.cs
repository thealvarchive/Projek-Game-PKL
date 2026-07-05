using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupLetter : MonoBehaviour
{
    public GameObject collectTextObj, intText;
    public AudioSource pickupSound, ambianceLayer1, ambianceLayer2, ambianceLayer3, ambianceLayer4, ambianceLayer5, ambianceLayer6, ambianceLayer7, ambianceLayer8;
    public bool interactable;
    public static int pagesCollected;
    public Text collectText;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
            interactable = false;
        }
    }
    void Update()
    {
        if(interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pagesCollected = pagesCollected + 1;
                collectText.text = pagesCollected + "/8 pages";
                collectTextObj.SetActive(true);

                PlayAudio(pickupSound);
                if(pagesCollected == 1)
                {
                    PlayAudio(ambianceLayer1);
                }
                if (pagesCollected == 2)
                {
                    PlayAudio(ambianceLayer2);
                }
                if (pagesCollected == 3)
                {
                    PlayAudio(ambianceLayer3);
                }
                if (pagesCollected == 4)
                {
                    PlayAudio(ambianceLayer4);
                }
                if (pagesCollected == 5)
                {
                    PlayAudio(ambianceLayer5);
                }
                if (pagesCollected == 6)
                {
                    PlayAudio(ambianceLayer6);
                }
                if (pagesCollected == 7)
                {
                    PlayAudio(ambianceLayer7);
                }
                if (pagesCollected == 8)
                {
                    PlayAudio(ambianceLayer8);
                }

                intText.SetActive(false);
                DisablePickupObject();
                interactable = false;
            }
        }
    }

    private void PlayAudio(AudioSource audioSource)
    {
        if (audioSource == null || audioSource.clip == null)
        {
            return;
        }

        AudioSource.PlayClipAtPoint(audioSource.clip, transform.position, Mathf.Clamp01(audioSource.volume));
    }

    private void DisablePickupObject()
    {
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.enabled = false;
        }

        Renderer rend = GetComponent<Renderer>();
        if (rend != null)
        {
            rend.enabled = false;
        }

        enabled = false;
    }
}
