using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : Interactive
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider2d;

    public Sprite openedSprite;     //�򿪵�����ͼƬ

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (!isDone)    //����δ���
        {
            transform.GetChild(0).gameObject.SetActive(false);  //����ʾ��Ʊ
        }
        else
        {
            spriteRenderer.sprite = openedSprite;   //����ͼƬΪ�򿪵�ͼƬ
            collider2d.enabled = false;
        }
    }

    protected override void OnClickedAction()
    {
        spriteRenderer.sprite = openedSprite;               //����ͼƬΪ�򿪵�ͼƬ
        transform.GetChild(0).gameObject.SetActive(true);   //��ʾ��Ʊ
    }
}
