using FairyGUI;
using UnityEngine;

namespace app{
public partial class HomeScene : MonoBehaviour{        
    private GComponent[] m_avatar;
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
    private GLabel m_mail_sender;
    private GLabel m_mail_content;
    private GGroup m_console; // 主面板
    private GGroup m_clue;
    private GGroup m_clue_detail;
    private GLabel m_clue_detail_content;
    private GGroup m_clue_simple;
    private GLabel m_clue_simple_content;
    private GGroup m_change_scene;
    private GComponent m_wallpaper;

    public void initUI(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        m_avatar = new GComponent[2];
        m_avatar[0] = view.GetChild("AvatarComp").asCom;
        m_avatar[1] = view.GetChild("AvatarTaoxi").asCom;
        m_avatar[1].visible = false;
        // 上面的对话框
        m_dialog = view.GetChild("Dialog").asLabel; 
        m_guild = view.GetChild("Guild").asGroup;
        m_guild_dialog = view.GetChild("GuildDialog").asLabel;
        m_guild_mask = view.GetChild("GuildMask").asCom;
        m_guild_mask.onClick.Add(guildMask_Click);
        m_dialog.text = "";
        GButton nextButton = view.GetChild("NextButton").asButton; // 点击按钮文字继续走的按钮
        nextButton.onClick.Add(nextButton_Click);

        // 获取邮箱，是一个通用控件
        m_mail = view.GetChild("Mail").asGroup;
        m_mail_sender = view.GetChild("MailSender").asLabel;
        m_mail_content= view.GetChild("MailContent").asLabel;
        GButton mailCloseButton = view.GetChild("MailCloseButton").asButton;
        mailCloseButton.onClick.Add(mailCloseButton_Click);
        GButton mailOKButton = view.GetChild("MailOKButton").asButton;
        mailOKButton.onClick.Add(mailCloseButton_Click);

        // 获取各个遮罩和其中的按钮
        m_mask_0 = view.GetChild("Mask_0").asGroup;
        GButton button_1 = view.GetChild("Button_1").asButton;
        button_1.onClick.Add(button_1_Click);
        GButton button_2 = view.GetChild("Button_2").asButton;
        button_2.onClick.Add(button_2_Click);

        m_mask_1 = view.GetChild("Mask_1").asGroup;
        GButton button_1_1 = view.GetChild("Button_1_1").asButton;
        button_1_1.onClick.Add(button_1_1_Click);
        GButton button_1_2 = view.GetChild("Button_1_2").asButton;
        button_1_2.onClick.Add(button_1_1_Click);

        m_mask_1_1 = view.GetChild("Mask_1_1").asGroup;
        GButton button_1_1_1 = view.GetChild("Button_1_1_1").asButton;
        button_1_1_1.onClick.Add(button_1_1_1_Click);
        GButton button_1_1_2 = view.GetChild("Button_1_1_2").asButton;
        button_1_1_2.onClick.Add(button_1_1_1_Click);
        GButton button_1_1_3 = view.GetChild("Button_1_1_3").asButton;
        button_1_1_3.onClick.Add(button_1_1_2_Click);

        m_mask_2 = view.GetChild("Mask_2").asGroup;
        GButton button_2_1 = view.GetChild("Button_2_1").asButton;
        button_2_1.onClick.Add(button_2_1_Click);
        GButton button_2_2 = view.GetChild("Button_2_2").asButton;
        button_2_2.onClick.Add(button_2_2_Click);

        m_mask_2_1 = view.GetChild("Mask_2_1").asGroup;
        GButton button_2_1_1 = view.GetChild("Button_2_1_1").asButton;
        button_2_1_1.onClick.Add(button_2_1_1_Click);

        m_mask_2_1_1 = view.GetChild("Mask_2_1_1").asGroup;
        GButton button_2_1_1_1 = view.GetChild("Button_2_1_1_1").asButton;
        button_2_1_1_1.onClick.Add(button_2_1_1_1_Click);

        m_mask_2_1_1_1 = view.GetChild("Mask_2_1_1_1").asGroup;
        GButton button_2_1_1_1_1 = view.GetChild("Button_2_1_1_1_1").asButton;
        button_2_1_1_1_1.onClick.Add(button_2_1_1_1_1_Click);

        m_console = view.GetChild("Console").asGroup;
        m_clue = view.GetChild("Clue").asGroup;
        GButton clueOKButton = view.GetChild("ClueOKButton").asButton;
        clueOKButton.onClick.Add(clueOKButton_Click);
        GButton clueCheckButton = view.GetChild("ClueCheckButton").asButton;
        clueCheckButton.onClick.Add(clueCheckButton_Click);
        m_clue_detail = view.GetChild("ClueDetail").asGroup;
        GButton clueDetailCloseButton = view.GetChild("ClueDetailCloseButton").asButton;
        clueDetailCloseButton.onClick.Add(clueDetailCloseButton_Click);
        m_clue_detail_content = view.GetChild("ClueDetailContent").asLabel;
        m_clue_simple = view.GetChild("ClueSimple").asGroup;
        m_clue_simple_content = view.GetChild("ClueSimpleContent").asLabel;
        GButton clueSimpleCloseButton = view.GetChild("ClueSimpleCloseButton").asButton;
        clueSimpleCloseButton.onClick.Add(clueSimpleCloseButton_Click);

        m_change_scene = view.GetChild("ChangeScene").asGroup;
        GButton graceButton = view.GetChild("GraceButton").asButton;
        graceButton.onClick.Add(graceButton_Click);
        GButton grandpaButton = view.GetChild("GrandpaButton").asButton;
        grandpaButton.onClick.Add(grandpaButton_Click);

        m_wallpaper = view.GetChild("WallPaper").asCom;
        GComponent shelf= m_wallpaper.GetChild("Shelf").asCom;
        shelf.onClick.Add(shelf_Click);
        GButton picture = m_wallpaper.GetChild("Picture").asButton;
        picture.onClick.Add(picture_Click);
    }
}
}

