using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace app{
public partial class DriveScene : MonoBehaviour{        
    private GLabel m_dialog; // 显示字符串的面板
    private GButton m_nextButton;
    private GButton m_destinButton;

    public void initUI(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        // 上面的对话框
        m_dialog = view.GetChild("Dialog").asLabel; 
        m_dialog.text = "";
        m_nextButton = view.GetChild("NextButton").asButton; 
        m_nextButton.onClick.Add(nextButton_Click);
        m_destinButton = view.GetChild("DestinButton").asButton;
        m_destinButton.onClick.Add(destinButton_Click);
        if(m_i == 0){ // 证明从HomeScene第一章跳转过来的
            m_nextButton.visible = false;
        }
        else if(m_i == 14){ // 证明从GrandpaScene第二章跳转过来的
            m_nextButton.visible = true;
            m_destinButton.visible=false;
            isActive = true;
        }
    }
    void nextButton_Click(){
        if((m_i>=0) && (m_i<6)){
            ControlDialogue();
        }
        else if(m_i == 6){
            PlayerPrefs.SetInt("m_i", 0); // 第二章
            SceneManager.LoadScene("GrandpaScene");
        }
        else if((m_i>=7) && (m_i<13)){
            ControlDialogue();
        }
        else if(m_i == 13){
            //TODO:剧情跳转第三章
        }
        else if((m_i>=14) && (m_i<16)){
            ControlDialogue();
        }
        else if(m_i == 16){
            PlayerPrefs.SetInt("m_i", 50); // 中转章
            SceneManager.LoadScene("HomeScene");
        }
    }
    void destinButton_Click(){
        m_destinButton.visible = false;
        m_nextButton.visible = true;
        m_i = 0;
        isActive = true;
    }
}
}