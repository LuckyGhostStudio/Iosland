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
        // TODO:������Ϸ����
    }

    public void GoBackMenu()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        TransitionManager.Instance.Transition(currentScene, "Menu");    //���͵�Menu����

        // TODO:�������
    }
}
