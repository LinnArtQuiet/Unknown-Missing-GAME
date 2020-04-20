using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
namespace app{
public partial class SubtitleScene : MonoBehaviour
{
    public AudioSource music;
    public AudioClip bgm_wav;

    int m_i = 0;

    GLabel m_label;
   
   bool isActive = false; // 是否正在打字
    float charsPerSecond = 0.1f;//打字时间间隔
    float timer;//计时器
    int currentPos = 0;//当前打字位置

    void Start()
    {
        music = gameObject.AddComponent<AudioSource>();
        bgm_wav = Resources.Load<AudioClip>("music/Narrator");
        music.clip = bgm_wav;
        music.loop = true;
        music.Play();

        m_i = PlayerPrefs.GetInt("m_i");

        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui;
        m_label = view.GetChild("Label").asLabel;
        m_label.text = "";
        GButton background = view.GetChild("Background").asButton;
        m_label.onClick.Add(OnClick);
        background.onClick.Add(OnClick); // 之所以添加两个是因为没有点击穿透效果
        isActive = true;
    }
    void OnClick()
    {
        if((m_i>=0) && (m_i<2)){ // 普通过程切换
            ControlDialogue();
        }
        else if(m_i == 2){
            PlayerPrefs.SetInt("m_i", 0);
            SceneManager.LoadScene("HomeScene"); // 更换场景
        }
        else if((m_i>=3) && (m_i<5)){ // 最终场景切换
            ControlDialogue();
        }
        else if(m_i == 5){
            PlayerPrefs.SetInt("m_i", 0);
            SceneManager.LoadScene("OutsideScene"); // 更换场景，最终
        }
        else if((m_i>=6) && (m_i<7)){ // DLC场景切换
            ControlDialogue();
        }
        else if(m_i == 7){ // 切换DLC
            PlayerPrefs.SetInt("m_i", 0);
            SceneManager.LoadScene("DLCScene"); // 更换场景
        }
        else if((m_i>=8) && (m_i<9)){ // 支线的情况
            ControlDialogue();
        }
        else if(m_i == 9){
            PlayerPrefs.SetInt("m_i", 67);
            SceneManager.LoadScene("HomeScene"); // 更换场景
        }
    }
    void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= charsPerSecond)
            {//判断计时器时间是否到达
                timer = 0;
                currentPos++;
                m_label.text = strs[m_i].Substring(0, currentPos);//刷新文本显示内容
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
            m_label.text = "";
            isActive = true;
        }
    }
    void OnFinish()
    {
        isActive = false; 
        timer = 0;
        currentPos = 0;
        m_label.text = strs[m_i];
        m_i++; 
    }
}
}