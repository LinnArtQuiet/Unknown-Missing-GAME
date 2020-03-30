using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class HomeSceneTest : MonoBehaviour
{
    int m_i = 0;
    string[] strs = {"你好，欢迎进入工作室~",
    "我是你的私人助理Comp",
    "你可以左右拉动屏幕来获取工作室的全貌",
    "现播报昨日工作进度和当前未处理事项：",
    "昨天是休息日，没有工作进度",
    "当前有一封未读邮件，发件人为Lee",
    "Comp，Lee是谁，为何会给我发邮件？邮件内容是什么？",
    "收到疑问内容，正在进行搜寻……",
    "搜寻结束，Lee是您的大学同学，他的本科生导师和您CURE项目的导师是同一个人，Lee的所有资料已经精简成简历，请问是听读还是阅读？"};
    string[] strs1 = { "你好，欢迎进入工作室~",
    "我是你的私人助理Comp",
    "你可以左右拉动屏幕来获取工作室的全貌"
    };
    GLabel m_dialog;
    GGroup m_maskCom; // 遮罩组
    GButton m_whoisleeBt;
    float timer = 0.0f;
    bool isActive = false; // 是否处在打字过程中
    int currentPos = 0; // 打字的位置
    void Start()
    {
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui;
        m_dialog = view.GetChild("Dialog").asLabel;
        m_dialog.text = "";
        isActive = true; // 开始动画
        GButton nextButton = view.GetChild("NextButton").asButton;
        nextButton.onClick.Add(OnClick);
        m_maskCom = view.GetChild("MaskCombine").asGroup;
        m_maskCom.visible = false;
        StartGame();
    }
    void StartGame()
    {
        PlaySpeak(strs1);
        if (Choose(m_maskCom) == 1)
        {

        }
        else if (Choose(m_maskCom) == 2)
        {

        }
    }
    void PlaySpeak(string[] str)
    { // 逐行输出信息
        for (int i = 0; i < str.Length; i++){
            isActive = true; // 它必须一直等在这里，而上面的框架也要一直等在这里
            while(m_i != 4){
                
            }
        }
    }
    int Choose(GGroup mask)
    {
        return 0;
    }
    void OnClick()
    {
        if (m_i < 6)
        { // 前6个都是对话
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
        else if (m_i == 6) // 展开遮罩
        {
            m_maskCom.visible = true;
        }
        else
        { // 接着进行对话     
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
    }
    void Update() // 每隔一帧执行，如果中途有其他函数，它便不执行，反正不是同步的
    { // 而且必须是别的函数执行完毕后，它才会执行的是不是？
    // 这个update不会再调用吧？它只是一个回调函数而已。。
    // 它是可以使用的，但有一点是，系统也是每帧使用的
        if (isActive)
        {
            timer += Time.deltaTime;
            if (timer >= 0.05)
            {
                timer = 0;
                currentPos++;
                m_dialog.text = strs[m_i].Substring(0, currentPos);//刷新文本显示内容
                if (currentPos >= strs[m_i].Length)
                {
                    OnFinish();
                }
            }
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
