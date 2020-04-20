using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
namespace app{
public class OutsideScene : MonoBehaviour
{    
    private string[] strs = {
        "Grace说旅行可以增长人的见闻。",
        "爷爷不愿意配合我的治疗，所以我想看看是不是我的方式不对。",
        "但我学着Grace走遍13个城市，似乎并没有找到答案。"
    };
    int m_i = 0;
    float timer = 0.0f; 
    bool isActive = false;
    int currentPos = 0; 
    private GLabel m_dialog; // 显示字符串的面板
    private GButton m_nextButton;
    void Start()
    {
        m_i = PlayerPrefs.GetInt("m_i");
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        m_dialog = view.GetChild("Dialog").asLabel; 
        m_dialog.text = "";
        m_nextButton = view.GetChild("NextButton").asButton; 
        m_nextButton.onClick.Add(nextButton_Click);
        isActive = true;
    }
    void nextButton_Click(){
        if((m_i>=0) && (m_i<3)){
            ControlDialogue();
        }
        else if(m_i == 3){
            // 到最后了
            PlayerPrefs.SetInt("m_i", 6); // 第二章
            SceneManager.LoadScene("SubtitleScene");
        }
    }
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= 0.05) 
            {
                timer = 0; 
                currentPos++;
                m_dialog.text = "";
                m_dialog.text = strs[m_i].Substring(0, currentPos);
                if (currentPos >= strs[m_i].Length) 
                {
                    OnFinish();
                }
            }
        }
    }
    void ControlDialogue(){ 
        if (isActive) 
        {
            OnFinish();
        }
        else 
        {
            m_dialog.text = "";
            isActive = true;
        }
    }
    void OnFinish()
    {
        isActive = false; 
        timer = 0;
        currentPos = 0;
        m_dialog.text = strs[m_i];
        m_i++; 
    }
}
}

