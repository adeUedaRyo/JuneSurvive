using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelUpSkill : MonoBehaviour
{
    CanvasGroup _canvas;
    [SerializeField] List<GameObject> skillButton;
    [SerializeField] Transform left, center, right;
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
        skillButton = skillButton.OrderBy(a =>Guid.NewGuid()).ToList();
        skillButton[0].transform.position = left.position;
        skillButton[1].transform.position = center.position;
        skillButton[2].transform.position = right.position;
    }
}
