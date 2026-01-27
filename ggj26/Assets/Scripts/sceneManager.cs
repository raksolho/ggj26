using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void LoadScene(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();

        // So serve para debug
        // TODO: apagar na versao final
        Debug.Log("Game is exiting"); 
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
