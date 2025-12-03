using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextOnTrigger : MonoBehaviour
{
    // Tag the player as "Player"
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            // Get the index of the current scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Load the next scene in the Build Settings
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}
