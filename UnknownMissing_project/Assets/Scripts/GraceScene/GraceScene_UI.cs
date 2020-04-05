using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace app{
public partial class GraceScene : MonoBehaviour{        
    private GLabel m_dialog; // 显示字符串的面板
    private GButton m_nextButton;

    public void initUI(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        // 上面的对话框
        m_dialog = view.GetChild("Dialog").asLabel; 
        m_dialog.text = "";
        m_nextButton = view.GetChild("NextButton").asButton; 
        m_nextButton.onClick.Add(nextButton_Click);
    }
    void nextButton_Click(){
        if((m_i>=0) && (m_i<7)){
            ControlDialogue();
        }
        else if(m_i == 7){
        }
    }
}
}