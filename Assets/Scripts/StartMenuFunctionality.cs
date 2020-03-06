using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuFunctionality : MonoBehaviour
{

    public void LevelOne()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene(3);
    }
    public void LevelThree()
    {
        SceneManager.LoadScene(4);
    }
    public void LevelFour()
    {
        SceneManager.LoadScene(5);
    }
    public void LevelFive()
    {
        SceneManager.LoadScene(6);
    }
    public void LevelSix()
    {
        SceneManager.LoadScene(7);
    }
    public void LevelSeven()
    {
        SceneManager.LoadScene(8);
    }
    public void LevelEight()
    {
        SceneManager.LoadScene(9);
    }
    public void LevelNine()
    {
        SceneManager.LoadScene(10);
    }
    public void LevelTen()
    {
        SceneManager.LoadScene(11);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
    }
  
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
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