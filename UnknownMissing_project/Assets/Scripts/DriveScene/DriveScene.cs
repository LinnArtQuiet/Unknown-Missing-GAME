using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
namespace app{
public partial class DriveScene : MonoBehaviour
{
    int m_i = 0;
    float timer = 0.0f; 
    bool isActive = false;
    int currentPos = 0; 
    void Start()
    {
        m_i = PlayerPrefs.GetInt("m_i");
        initUI();
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
