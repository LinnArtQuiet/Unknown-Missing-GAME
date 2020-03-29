using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;

public class SubtitleScene : MonoBehaviour
{
    string secondStr = "人工智能与人类生活的结合日趋紧密，无人驾驶系统早已步入成熟期，可穿戴模式渗透生活琐事，人类的衣食住行，医教文娱早已迈入机械化、智能化阶段。医疗的人工智能助理盛极一时，越来越多的人，将个人健康交由AI管理。";
    bool isFirstStr = true; // 一共就两个字符串
    bool isActive = true; // 是否正在打字
    float charsPerSecond = 0.2f;//打字时间间隔
    float timer;//计时器
    int currentPos = 0;//当前打字位置
    string nowStr; // 表示现在打字特效的字符串
    GLabel m_label;
    void Start()
    {
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui;
        m_label = view.GetChild("Label").asLabel;
        nowStr = "欢迎来到2050年，请置换佩戴隐形式智能穿戴设施，获得你的私人助理Comp"; // 初始化第一个字符串
        m_label.text = "";
        GButton background = view.GetChild("Background").asButton;
        m_label.onClick.Add(OnClick);
        background.onClick.Add(OnClick); // 之所以添加两个是因为没有点击穿透效果
    }
    void OnClick()
    {
        if (isActive){
            return; // 如果正在打字，则没有点击事件
        } 
        if (isFirstStr)
        {
            isFirstStr = false;
            nowStr = secondStr;
            isActive = true; // 激活打字效果
        }
        else
        {
            SceneManager.LoadScene("HomeScene");// 更换场景
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
                m_label.text = nowStr.Substring(0, currentPos);//刷新文本显示内容
                if (currentPos >= nowStr.Length)
                {
                    isActive = false;
                    timer = 0;
                    currentPos = 0;
                    m_label.text = nowStr;
                }
            }

        }
    }

}
