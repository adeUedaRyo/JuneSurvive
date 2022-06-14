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
        skillButton[0].SetActive(true);
        skillButton[1].transform.position = center.position;
        skillButton[1].SetActive(true);
        skillButton[2].transform.position = right.position;
        skillButton[2].SetActive(true);
    }
    public void SelectEnd()
    {
        Time.timeScale = 1;
        _canvas.alpha = 0;
        for (int i =0;i < skillButton.Count;i++)
        {
            skillButton[i].SetActive(false);
        }

    }
}
