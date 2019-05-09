using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This script loads different scenes inputed through the editor. It is also used to play
/// the game through events within animations.
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
