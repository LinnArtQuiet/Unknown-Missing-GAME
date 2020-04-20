using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace app{
public partial class HomeScene : MonoBehaviour
{
    private AudioSource sound;
    private AudioClip click_wav;
    private AudioSource music;
    private AudioClip bgm_wav;
    private AudioClip piano_wav;
    private AudioClip ChineseZither_wav;

    int m_i = 50; // 控制流程的标志，一般就是控制游戏进程的，非常重要

    float timer = 0.0f; // 蹦字用的计时器
    bool isActive = false; // 是否处在打字过程中
    int currentPos = 0; // 打字的位置

    void Start() // 主要用来完成初始化和控件获得
    {
        sound = gameObject.AddComponent<AudioSource>();
        click_wav = Resources.Load<AudioClip>("music/Click");
        piano_wav = Resources.Load<AudioClip>("music/Piano");
        ChineseZither_wav = Resources.Load<AudioClip>("music/ChineseZither");
        music = gameObject.AddComponent<AudioSource>();
        bgm_wav = Resources.Load<AudioClip>("music/HomeScene");
        music.clip = bgm_wav;
        music.loop = true;
        music.Play();
        
        m_i = PlayerPrefs.GetInt("m_i");

        initUI(); // 在HomeScene_UI.cs文件中
        isActive = true; // 开始动画
        Debug.Log("start! 第一章开始！");
    }
    void Update()
    {
        if (isActive) // 如果是激活状态，就是蹦字
        {
            timer += Time.deltaTime;
            if (timer >= 0.05) // 时延到了
            {
                timer = 0; // 重置时间
                currentPos++; // 字符指针前进
                m_dialog.text = "";
                m_guild_dialog.text = "";
                if(m_guild.visible == true){
                    m_guild_dialog.text = strs[m_i].Substring(0, currentPos);
                }
                else
                {
                    m_dialog.text = strs[m_i].Substring(0, currentPos);
                }
                if (currentPos >= strs[m_i].Length) // 字符串指针到头自动停止
                {
                    OnFinish();
                }
            }
        }
    }
    void ControlDialogue(){ // 用来控制台词的步进
        if (isActive) // 如果是激活状态就停止，适用于中途停止
        {
            OnFinish();
        }
        else // 如果是停止的就激活
        {
            m_dialog.text = "";
            m_guild_dialog.text = "";
            isActive = true;
        }
    }
    void OnFinish()
    {
        isActive = false; // 停止并初始化
        timer = 0;
        currentPos = 0;
        if(m_guild.visible == true){
            m_guild_dialog.text = strs[m_i];
        }
        else
        {
            m_dialog.text = strs[m_i];
        }
        m_i++; // 自动下一条语句的设置
    }
    void ChangeAvatar(int i){
        m_avatar[0].visible = false;
        m_avatar[1].visible = false;
        m_avatar[i].visible = true;
    }
}
}