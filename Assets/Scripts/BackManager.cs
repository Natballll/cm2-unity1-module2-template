
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackManager : MonoBehaviour
{
    public string SceneOnEsc;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneOnEsc);
        }
    }
}
