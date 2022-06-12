using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpSkill : MonoBehaviour
{
    CanvasGroup _canvas;
    private void Awake()
    {
        _canvas = GetComponent<CanvasGroup>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Select()
    {
        _canvas.alpha = 1;

    }
}
