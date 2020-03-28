﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class HomeScene : MonoBehaviour
{
    int m_i = 0; // 控制流程的标志，一般就是控制游戏进程的，非常重要
    string[] strs = {"你好，欢迎进入工作室~", // str[0]
        "我是你的私人助理Comp",
        "你可以左右拉动屏幕来获取工作室的全貌",
        "现播报昨日工作进度和当前未处理事项：",
        "昨天是休息日，没有工作进度",
        "当前有一封未读邮件，发件人为Lee",
        "[玩家操作选择] 选择1 ： Lee是谁？；选择2 ：邮件内容是什么？", // strs[6]
        "Comp，Lee是谁，为何会给我发邮件？邮件内容是什么？", // strs[7]
        "收到疑问内容，正在进行搜寻……",
        "搜寻结束，Lee是您的大学同学，他的本科生导师和您CURE项目的导师是同一个人，Lee的所有资料已经精简成简历，请问是听读还是阅读？",
        "[玩家操作选择] 选择1.1 ：（更喜欢纸质阅读）；选择1.1 ：阅读", // strs[10]
        "显示档案资料系统中Lee的个人资料页，玩家点击关闭资料页窗口后。", // strs[11]
        "您已阅读完毕，请问是否需要阅读邮件内容？", // strs[12]
        "[玩家操作选择] 选择1.1.1 ：看看吧 ; 选择1.1.1 ：无事不登三宝殿 ； 选择1.1.2：不看", // strs[13]
        "直接打开邮件系统，显示邮件内容，玩家点击关闭邮件系统后。", // strs[14]
        "CURE项目竟然被做出来了，导师没有失踪，这几年她自己一个人完成了所有研究吗？", // strs[15]
        "CURE还是以前构想的样子吗？",
        "一大堆疑问在脑中浮现。",
        "[玩家操作选择] 选择2.1 ：回信 ; 选择2.2 ：不回", // strs[18]
        "回个信吧，告诉李之一，烦请提供详细资料，以便开展调查。", // strs[19]
        "收到，正在通过语音内容生成邮件……",
        "邮件内容已生成并发送",
        "", // strs[22] TODO:
    };
    GLabel m_dialog; // 显示字符串的面板
    GGroup m_mask_0; // 遮罩组
    GGroup m_mask_1; // 遮罩组
    GGroup m_personalData;
    GGroup m_mail; // 遮罩组

    float timer = 0.0f; // 蹦字用的计时器
    bool isActive = false; // 是否处在打字过程中
    int currentPos = 0; // 打字的位置
    void Start() // 主要用来完成初始化和控件获得
    {
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        // 上面的对话框
        m_dialog = view.GetChild("Dialog").asLabel; 
        m_dialog.text = "";
        GButton nextButton = view.GetChild("NextButton").asButton; // 点击按钮文字继续走的按钮
        nextButton.onClick.Add(nextButton_Click);

        // 获取邮箱，是一个通用控件
        m_mail = view.GetChild("Mail").asGroup;
        m_mail.visible = false;
        GButton mailCloseButton = view.GetChild("MailCloseButton").asButton;
        mailCloseButton.onClick.Add(mailCloseButton_Click);
        GButton mailOKButton = view.GetChild("MailOKButton").asButton;
        mailOKButton.onClick.Add(mailCloseButton_Click);

        // 获取个人资料页
        m_personalData = view.GetChild("PersonalData").asGroup;
        m_personalData.visible = false;
        GButton personalDataOKButton = view.GetChild("PersonalDataOKButton").asButton;
        personalDataOKButton.onClick.Add(personalDataOKButton_Click);

        // 获取各个遮罩和其中的按钮
        m_mask_0 = view.GetChild("Mask_0").asGroup;
        m_mask_0.visible = false;
        GButton button_1 = view.GetChild("Button_1").asButton;
        button_1.onClick.Add(button_1_Click);
        GButton button_2 = view.GetChild("Button_2").asButton;
        button_2.onClick.Add(button_2_Click);

        m_mask_1 = view.GetChild("Mask_1").asGroup;
        m_mask_1.visible = false;
        GButton button_1_1 = view.GetChild("Button_1_1").asButton;
        button_1_1.onClick.Add(button_1_1_Click);
        GButton button_1_2 = view.GetChild("Button_1_2").asButton;
        button_1_2.onClick.Add(button_1_2_Click);

        m_mask_1_1 = view.GetChild("Mask_1_1").asGroup;
        m_mask_1_1.visible = false;
        GButton button_1_1_1 = view.GetChild("Button_1_1_1").asButton;
        button_1_1_1.onClick.Add(button_1_1_1_Click);
        GButton button_1_1_2 = view.GetChild("Button_1_1_2").asButton;
        button_1_1_2.onClick.Add(button_1_1_2_Click);
        GButton button_1_1_3 = view.GetChild("Button_1_1_3").asButton;
        button_1_1_3.onClick.Add(button_1_1_3_Click);

        m_mask_2 = view.GetChild("Mask_2").asGroup;
        m_mask_2.visible = false;
        GButton button_2_1 = view.GetChild("Button_2_1").asButton;
        button_2_1.onClick.Add(button_2_1_Click);
        GButton button_2_2 = view.GetChild("Button_2_2").asButton;
        button_2_2.onClick.Add(button_2_2_Click);

        isActive = true; // 开始动画
    }
    void nextButton_Click()
    {
        if (m_i < 6) // 0_1~0_6 的前6句对话
        {
            ControlDialogue(); // 这个函数用来依次执行语句
        }
        else if (m_i == 6) // [玩家操作选择] 选择1 ： Lee是谁？；选择2 ：邮件内容是什么？
        {
            m_mask_0.visible = true;
        }
        else if ((m_i>=7) && (m_i<10)){ 
            ControlDialogue();
        }
        else if(m_i == 10){ // [玩家操作选择] 选择1.1 ：（更喜欢纸质阅读）；选择1.1 ：阅读
            m_mask_1.visible = true;
        }
        else if(m_i == 11){
            m_personalData.visible = true;
        }
        else if((m_i >= 12) && (m_i < 13))
        {
            ControlDialogue();
        }
        else if(m_i == 13){ // [玩家操作选择] 选择1.1.1 ：看看吧 ; 选择1.1.1 ：无事不登三宝殿 ； 选择1.1.2：不看
            m_mask_1_1.visible = true;
        }
        else if(m_i == 14){ // 打开邮件系统
            m_mail.visible = true;
        }
        else if((m_i >= 15) && (m_i < 17)){
            ControlDialogue();
        }
        else if(m_i == 17){
            openMail();
        }
    }
    void mailCloseButtonClick() // 关闭邮箱之后也会触发剧情
    { 
        m_mail.visible = false;
        if(m_i == 14){
            m_i = 15;
            isActive = true; // 开启字幕
        }
    }
    void personalDataOKButton_Click()
    {
        m_personalData.visible = false;
        m_i = 12;
        isActive = true;
    }
    void button_1_Click() // 选择1 ： Lee是谁？
    {
        m_mask_0.visible = false; // 隐藏遮罩
        m_i = 7; // 从strs[7]开始读了
        isActive = true; // 直接开启字幕，就是从strs[6]开始了
    }
    void button_2_Click() // 选择2 ：邮件内容是什么？
    {
        m_mask_0.visible = false;
        openMail();
    }
    void button_1_1_Click()
    {

    }
    void button_1_2_Click()
    {

    }
    void button_1_1_1_Click(){
        m_mail.visible = true; // TODO:后面接2的剧情
    }
    void button_1_1_2_Click()
    {
        m_mail.visible = true; // TODO:后面接2的剧情
    }
    void button_1_1_3_Click()
    {
        // TODO:触发隐藏剧情——第四章。
    }
    void button_2_1_Click(){
        m_mask_2.visible = false;
        m_i = 19;
        isActive = true;
    }
    void button_2_2_Click()
    {

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
                m_dialog.text = strs[m_i].Substring(0, currentPos);//刷新文本显示内容
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
