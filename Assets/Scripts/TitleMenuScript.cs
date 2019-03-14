using UnityEngine;
using UnityEngine.SceneManagement;

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
