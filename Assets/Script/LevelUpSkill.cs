using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelUpSkill : MonoBehaviour
{
    CanvasGroup _canvas;
    [SerializeField] List<GameObject> skillButton;
    [SerializeField] Transform left, center, right;
    [SerializeField] GameObject chickenButton;
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
        if(skillButton.Count <=0)
        {
            chickenButton.transform.position = center.position;
            chickenButton.SetActive(true);
            return;
        }
        skillButton = skillButton.OrderBy(a =>Guid.NewGuid()).ToList();
        skillButton[0].transform.position = left.position;
        skillButton[0].SetActive(true);
        if (skillButton.Count <=1) return;
        skillButton[1].transform.position = center.position;
        skillButton[1].SetActive(true);
        if (skillButton.Count <= 2) return;
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
        chickenButton.SetActive(false);
    }
    public void LevelMax(string name)
    {
       foreach(GameObject a in skillButton)
       {
            if(a.name == name)
            {
                a.SetActive(false);
                skillButton.Remove(a);
                break;
            }
       }
    }
}
