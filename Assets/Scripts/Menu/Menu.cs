using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        // TODO:加载游戏进度
    }

    public void GoBackMenu()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        TransitionManager.Instance.Transition(currentScene, "Menu");    //传送到Menu场景

        // TODO:保存进度
    }
}
