using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscareTrig : MonoBehaviour
{
    public GameObject playerObj, jumpscareCam, ambianceLayers;
    public Animator monsterAnim;
    public string sceneName;
    public float jumpscare;
    public monsterAI monsterScript;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerObj.SetActive(false);
            monsterScript.enabled = false;
            monsterAnim.speed = 1f;
            jumpscareCam.SetActive(true);
            ambianceLayers.SetActive(false);
            StartCoroutine(changeScene());
            monsterAnim.SetTrigger("jumpscare");
        }
    }

    private IEnumerator changeScene()
    {
        yield return new WaitForSeconds(jumpscare); 
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
