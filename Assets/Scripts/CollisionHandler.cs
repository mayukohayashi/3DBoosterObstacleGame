using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float timeOfDelay = 1f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip exploded;

    AudioSource audioSource;

    void Start()
    {
        audioSource =GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Bumped OKAY");
                break;
            case "Finish":
                // Debug.Log("Finish!");
                StartNextSceneSequence();
                break;
            case "Fuel":
                Debug.Log("Get Fuel!");
                break;
            default:
                // Debug.Log("Bumped bad");
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        audioSource.PlayOneShot(exploded);

        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", timeOfDelay);
    }

    void StartNextSceneSequence()
    {
        audioSource.PlayOneShot(success);

        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", timeOfDelay);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);

    }
}