using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FairyGUI;
// 最开始的初始界面
public class MainScene : MonoBehaviour
{
    void Start()
    {
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui;
        GButton button = view.GetChild("StartButton").asButton;
        button.onClick.Add(OnClick);
    }

    void OnClick(){
        SceneManager.LoadScene("SubtitleScene");
    }
 
}
