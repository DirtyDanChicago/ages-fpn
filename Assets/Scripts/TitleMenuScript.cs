using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script loads different scenes inputed through the editor.
/// </summary>
public class TitleMenuScript : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;

    public void SceneLoader()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
