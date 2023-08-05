using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : Singleton<TransitionManager>
{
    public CanvasGroup fadeCanvasGroup;
    public float fadeDuration;  //���뵭������ʱ��

    private bool isFade;        //�������ڵ��뵭��

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="from">Դ����</param>
    /// <param name="to">Ŀ�ĳ���</param>
    public void Transition(string from, string to)
    {
        if(!isFade) StartCoroutine(TransitionToScene(from, to));    //��from�������͵�to����
    }

    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return Fade(1);   //��������

        yield return SceneManager.UnloadSceneAsync(from);                       //ж��Դ����
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);   //����Ŀ�ĳ��� ����ģʽ�����ӣ����ӵ�President������

        //����to����Ϊ����� to����Ϊ����ӵĳ��� index = �������� - 1
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(SceneManager.sceneCount - 1));

        yield return Fade(0);   //��������
    }

    /// <summary>
    /// ���뵭����Fade Canvas Alpha 0 -> 1 || 1 -> 0
    /// </summary>
    /// <param name="targetAlpha">Ŀ��alpha</param>
    /// <returns></returns>
    private IEnumerator Fade(float targetAlpha)
    {
        isFade = true;
        fadeCanvasGroup.blocksRaycasts = true;  //��ֹ��������

        float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;    //���뵭���ٶ�

        //��ǰfadeCanvas ��alpha��Ŀ��alpha������
        while(!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
        {
            fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);  //��ǰalphaת�䵽Ŀ��alpha
            yield return null;
        }

        fadeCanvasGroup.blocksRaycasts = false; //������������
        isFade = false;
    }
}
