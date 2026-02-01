using UnityEngine;

public class SceneManagerRef : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        sceneManager.instance.LoadScene(buildIndex);
    }

    public void QuitGame()
    {
        sceneManager.instance.QuitGame();
    }
}
