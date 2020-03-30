using FairyGUI;
using UnityEngine;

namespace app{
public partial class HomeScene : MonoBehaviour{        
    public GLabel m_dialog; // 显示字符串的面板
    public GGroup m_mask_0; // 遮罩组
    public GGroup m_mask_1; // 遮罩组
    public GGroup m_mask_1_1; // 遮罩组
    public GGroup m_mask_2; // 遮罩组
    public GGroup m_mask_2_1; // 遮罩组
    public GGroup m_mask_2_1_1; // 遮罩组
    public GGroup m_mask_2_1_1_1; // 遮罩组
    public GGroup m_personalData; // 个人信息
    public GGroup m_mail; // 邮件

    public void initUI(){
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
        mailOKButton.onClick.Add(mailOKButton_Click);

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

        m_mask_2_1 = view.GetChild("Mask_2_1").asGroup;
        m_mask_2_1.visible = false;
        GButton button_2_1_1 = view.GetChild("Button_2_1_1").asButton;
        button_2_1_1.onClick.Add(button_2_1_1_Click);

        m_mask_2_1_1 = view.GetChild("Mask_2_1_1").asGroup;
        m_mask_2_1_1.visible = false;
        GButton button_2_1_1_1 = view.GetChild("Button_2_1_1_1").asButton;
        button_2_1_1_1.onClick.Add(button_2_1_1_1_Click);

        m_mask_2_1_1_1 = view.GetChild("Mask_2_1_1_1").asGroup;
        m_mask_2_1_1_1.visible = false;
        GButton button_2_1_1_1_1 = view.GetChild("Button_2_1_1_1_1").asButton;
        button_2_1_1_1_1.onClick.Add(button_2_1_1_1_1_Click);
        GButton button_2_1_1_1_2 = view.GetChild("Button_2_1_1_1_2").asButton;
        button_2_1_1_1_2.onClick.Add(button_2_1_1_1_2_Click);
    }
}
}