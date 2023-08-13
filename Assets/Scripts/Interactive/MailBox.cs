using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : Interactive
{
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D collider2d;

    public Sprite openedSprite;     //打开的信箱图片

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
        if (!isDone)    //互动未完成
        {
            transform.GetChild(0).gameObject.SetActive(false);  //不显示船票
        }
        else
        {
            spriteRenderer.sprite = openedSprite;   //设置图片为打开的图片
            collider2d.enabled = false;
        }
    }

    protected override void OnClickedAction()
    {
        spriteRenderer.sprite = openedSprite;               //设置图片为打开的图片
        transform.GetChild(0).gameObject.SetActive(true);   //显示船票
    }
}
