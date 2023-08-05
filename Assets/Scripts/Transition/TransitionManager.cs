using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;  //淡入淡出持续时间

    private bool isFade;        //场景正在淡入淡出

    /// <summary>
    /// 场景传送
    /// </summary>
    /// <param name="from">源场景</param>
    /// <param name="to">目的场景</param>
    public void Transition(string from, string to)
    {
        if(!isFade) StartCoroutine(TransitionToScene(from, to));    //从from场景传送到to场景
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);   //场景淡出

        yield return SceneManager.UnloadSceneAsync(from);                       //卸载源场景
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);   //加载目的场景 加载模式：叠加（叠加到President场景）

        //设置to场景为激活场景 to场景为新添加的场景 index = 场景数量 - 1
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));

        yield return Fade(0);   //场景淡入
    }

    /// <summary>
    /// 淡入淡出：Fade Canvas Alpha 0 -> 1 || 1 -> 0
    /// </summary>
    /// <param name="targetAlpha">目标alpha</param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;  //禁止检测鼠标点击

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;    //淡入淡出速度

        //当前fadeCanvas 的alpha和目标alpha不相似
        while(!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);  //当前alpha转变到目标alpha
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false; //开启检测鼠标点击
        isFade = false;
    }
}
