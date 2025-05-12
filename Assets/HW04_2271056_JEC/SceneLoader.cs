using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene02()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Scene02");
    }

    public void LoadScene01()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene("Scene01");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        var vb = VuforiaBehaviour.Instance;
        if (vb != null)
        {
            vb.enabled = false;
            vb.enabled = true;
        }
    }
}
