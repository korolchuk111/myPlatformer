using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ChangePlayerView : MonoBehaviour
{
    private const string PlayerviewKey = "PlayerView";
    
    [SerializeField] private Sprite _view1;
    [SerializeField] private Sprite _view2;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    public void Start()
    {
        int currentView = PlayerPrefs.GetInt(PlayerviewKey);

        if (currentView == 0)
            currentView = 1;

        SetView(currentView);
    }

    public void ChangeCurrentView()
    {
        int currentView = PlayerPrefs.GetInt(PlayerviewKey);
        
        if (currentView == 1)
        {
            currentView = 2;
        }
        else if (currentView == 2)
        {
            currentView = 1;
        }
        
        SetView(currentView);
        PlayerPrefs.SetInt(PlayerviewKey, currentView);
    }
    
    private void SetView(int currentView)
    {
        if (currentView == 1)
        {
            _spriteRenderer.sprite = _view1;
        }
        else if (currentView == 2)
        {
            _spriteRenderer.sprite = _view2;
        }
    }
}