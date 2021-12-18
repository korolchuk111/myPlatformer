using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
        
        ChangeScore(0);
    }

    public void ChangeScore(float score)
    {
        _text.text = $"Score: {score}";
    }
}
