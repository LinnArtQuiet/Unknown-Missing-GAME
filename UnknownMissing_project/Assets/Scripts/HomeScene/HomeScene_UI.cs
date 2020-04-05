using FairyGUI;
using UnityEngine;

namespace app{
public partial class HomeScene : MonoBehaviour{        
    private GLabel m_dialog; // 显示字符串的面板
    private GGroup m_guild; // 引导面板遮罩，完全透明
    private GLabel m_guild_dialog; // 引导面板
    private GComponent m_guild_mask;
    private GGroup m_mask_0; // 遮罩组
    private GGroup m_mask_1; // 遮罩组
    private GGroup m_mask_1_1; // 遮罩组
    private GGroup m_mask_2; // 遮罩组
    private GGroup m_mask_2_1; // 遮罩组
    private GGroup m_mask_2_1_1; // 遮罩组
    private GGroup m_mask_2_1_1_1; // 遮罩组
    private GGroup m_mail; // 邮件
    private GGroup m_console; // 主面板
    private GComponent m_console_mask;
    private GGroup m_clue;

    public void initUI(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        // 上面的对话框
        m_dialog = view.GetChild("Dialog").asLabel; 
        m_guild = view.GetChild("Guild").asGroup;
        m_guild.visible = false;
        m_guild_dialog = view.GetChild("GuildDialog").asLabel;
        m_guild_mask = view.GetChild("GuildMask").asCom;
        m_guild_mask.onClick.Add(guildMask_Click);
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

        m_console = view.GetChild("Console").asGroup;
        m_console.visible = false;

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
        button_1_2.onClick.Add(button_1_1_Click);

        m_mask_1_1 = view.GetChild("Mask_1_1").asGroup;
        m_mask_1_1.visible = false;
        GButton button_1_1_1 = view.GetChild("Button_1_1_1").asButton;
        button_1_1_1.onClick.Add(button_1_1_1_Click);
        GButton button_1_1_2 = view.GetChild("Button_1_1_2").asButton;
        button_1_1_2.onClick.Add(button_1_1_1_Click);
        GButton button_1_1_3 = view.GetChild("Button_1_1_3").asButton;
        button_1_1_3.onClick.Add(button_1_1_2_Click);

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
        // GButton button_2_1_1_1_2 = view.GetChild("Button_2_1_1_1_2").asButton;
        // button_2_1_1_1_2.onClick.Add(button_2_1_1_1_2_Click);

        // m_console_mask = view.GetChild("ConsoleMask").asComponent;
        // m_console_mask.onClick.Add(consoleMask_Click);
        // m_console = view.GetChild("Console").asGroup;
        m_clue = view.GetChild("Clue").asGroup;
        m_clue.visible = false;
        GButton clueOKButton = view.GetChild("ClueOKButton").asButton;
        clueOKButton.onClick.Add(clueOKButton_Click);
    }
}
}