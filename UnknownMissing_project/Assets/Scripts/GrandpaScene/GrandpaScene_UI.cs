using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace app{
public partial class GrandpaScene : MonoBehaviour{ 
    private GComponent[] m_avatar;      
    private GLabel m_dialog; // 显示字符串的面板
    private GGroup m_mask_1;
    private GGroup m_mask_2;

    public void initUI(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        m_avatar = new GComponent[2];
        m_avatar[0] = view.GetChild("AvatarGrandpa").asCom;
        m_avatar[1] = view.GetChild("AvatarTaoxi").asCom;
        // 上面的对话框
        m_dialog = view.GetChild("Dialog").asLabel; 
        m_dialog.text = "";
        GButton nextButton = view.GetChild("NextButton").asButton; 
        nextButton.onClick.Add(nextButton_Click);

        m_mask_1 = view.GetChild("Mask_1").asGroup;
        m_mask_1.visible = false;
        GButton button_1_a = view.GetChild("Button_1_A").asButton;
        button_1_a.onClick.Add(button_1_a_Click);
        GButton button_1_b = view.GetChild("Button_1_B").asButton;
        button_1_b.onClick.Add(button_1_b_Click);
        GButton button_1_c = view.GetChild("Button_1_C").asButton;
        button_1_c.onClick.Add(button_1_c_Click);

        m_mask_2 = view.GetChild("Mask_2").asGroup;
        m_mask_2.visible = false;
        GButton button_2_a = view.GetChild("Button_2_A").asButton;
        button_2_a.onClick.Add(button_2_a_Click);
        GButton button_2_b = view.GetChild("Button_2_B").asButton;
        button_2_b.onClick.Add(button_2_b_Click);
        GButton button_2_c = view.GetChild("Button_2_C").asButton;
        button_2_c.onClick.Add(button_2_c_Click);
    }
    void nextButton_Click(){
        if((m_i>=0) && (m_i<1)){
            ControlDialogue();
        }
        else if(m_i == 1){
            m_mask_1.visible = true;
        }
        else if((m_i>=2) && (m_i<5)){
            m_dialog.text = strs[m_i];
            m_mask_2.visible = true;
        }
        else if((m_i>=5) && (m_i<8)){
            m_i = 8;
            isActive = true;
        }
        else if((m_i>=8) && (m_i<27)){
            if(m_i%2 == 0) ChangeAvatar(1);
            else ChangeAvatar(0);
            ControlDialogue();
        }
        else if(m_i == 27){
            PlayerPrefs.SetInt("m_i", 14);
            SceneManager.LoadScene("DriveScene");
        }
    }
    void button_1_a_Click(){
        m_mask_1.visible = false;
        m_i = 2;
        isActive = true;
        Debug.Log(strs[m_i]);
    }
    void button_1_b_Click(){
        m_mask_1.visible = false;
        m_i = 3;
        isActive = true;
    }
    void button_1_c_Click(){
        m_mask_1.visible = false;
        m_i = 4;
        isActive = true;
    }
    void button_2_a_Click(){
        m_mask_2.visible = false;
        m_i = 5;
        isActive = true;
    }
    void button_2_b_Click(){
        m_mask_2.visible = false;
        m_i = 6;
        isActive = true;
    }
    void button_2_c_Click(){
        m_mask_2.visible = false;
        m_i = 7;
        isActive = true;
    }
}
}