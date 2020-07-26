using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuFunctionality : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("WeapSelect");
    }
    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
  
    public void LoreScene()
    {
        SceneManager.LoadScene("LoreScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Test Credits");
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        
#else
      Application.Quit();
#endif
    }
}