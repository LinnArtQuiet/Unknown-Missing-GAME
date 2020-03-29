using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
namespace app{
public partial class HomeScene : MonoBehaviour
{
    int m_i = 0; // 控制流程的标志，一般就是控制游戏进程的，非常重要
    float timer = 0.0f; // 蹦字用的计时器
    bool isActive = false; // 是否处在打字过程中
    int currentPos = 0; // 打字的位置
    void Start() // 主要用来完成初始化和控件获得
    {
        initUI();
        isActive = true; // 开始动画
        Debug.Log("start!");
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
                if(Guild.visible == true){ // 因为Guild也需要播放
                    m_guild_dialog.text = "";
                    m_guild_dialog.text = strs[m_i].Substring(0, currentPos);
                }
                else{
                    m_dialog.text = "";
                    m_dialog.text = strs[m_i].Substring(0, currentPos);//刷新文本显示内容
                }
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