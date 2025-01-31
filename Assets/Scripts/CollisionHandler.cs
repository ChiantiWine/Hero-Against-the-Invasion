using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem CrashVFX;
void OnTriggerEnter(Collider other) 
    {
        StartCrashSequence();
    }

    void StartCrashSequence()
    {
        CrashVFX.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<Collider>().enabled = false;
        GetComponent<PlayerControls>().enabled = false;
        Invoke("ReloadLevel", loadDelay);
    }

    void ReloadLevel()
    {
        Debug.Log("Reloading Level...");    
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
