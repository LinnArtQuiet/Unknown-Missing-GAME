using FairyGUI;
using UnityEngine;

namespace app{
public partial class HomeScene : MonoBehaviour{        
    private GComponent[] m_avatar;
    private GLabel m_dialog; // 显示字符串的面板

    private GGroup m_guild; // 引导面板遮罩，完全透明
    private GLabel m_guild_dialog; // 引导面板
    private GComponent m_guild_mask;

    private GGroup m_mail; // 邮件
    private GLabel m_mail_sender;
    private GLabel m_mail_content;

    private GComponent m_personaldata;
    private GGroup m_console; // 主面板

    private GGroup m_clue;
    private GLabel m_clueContent;
    private GGroup m_clue_detail;
    private GLabel m_clue_detail_name;
    private GLabel m_clue_detail_content;
    private GGroup m_clue_simple;
    private GLabel m_clue_simple_name;
    private GLabel m_clue_simple_content;
    private GGroup m_change_scene; // grandpa还是grace
    private GGroup m_change_scene2; // grandpa还是grace
    private GComponent m_wallpaper;
    private GGroup m_wheretogo; // 东京华盛顿之类的

    private GGroup m_mask_0; // 遮罩组
    private GGroup m_mask_1; // 遮罩组
    private GGroup m_mask_1_1; // 遮罩组
    private GGroup m_mask_2; // 遮罩组
    private GGroup m_mask_2_1; // 遮罩组
    private GGroup m_mask_2_1_1; // 遮罩组
    private GGroup m_mask_2_1_1_1; // 遮罩组

    public void initUI(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        m_avatar = new GComponent[2];
        m_avatar[0] = view.GetChild("AvatarComp").asCom;
        m_avatar[1] = view.GetChild("AvatarTaoxi").asCom;
        m_avatar[1].visible = false;
        // 上面的对话框
        m_dialog = view.GetChild("Dialog").asLabel; 
        m_dialog.text = "";
        GButton nextButton = view.GetChild("NextButton").asButton; // 点击按钮文字继续走的按钮
        nextButton.onClick.Add(nextButton_Click);
        // 引导对话框
        m_guild = view.GetChild("Guild").asGroup;
        m_guild_dialog = view.GetChild("GuildDialog").asLabel;
        m_guild_mask = view.GetChild("GuildMask").asCom;
        m_guild_mask.onClick.Add(guildMask_Click);
        // 获取邮箱
        m_mail = view.GetChild("Mail").asGroup;
        m_mail_sender = view.GetChild("MailSender").asLabel;
        m_mail_content= view.GetChild("MailContent").asLabel;
        GButton mailCloseButton = view.GetChild("MailCloseButton").asButton;
        mailCloseButton.onClick.Add(mailCloseButton_Click);
        GButton mailOKButton = view.GetChild("MailOKButton").asButton;
        mailOKButton.onClick.Add(mailCloseButton_Click);
        // Lee资料面板
        m_personaldata = view.GetChild("PersonalData").asCom;
        m_personaldata.onClick.Add(personaldata_Click);
        // 主面板
        m_console = view.GetChild("Console").asGroup;
        GComponent consoleMask = view.GetChild("ConsoleMask").asCom;
        consoleMask.onClick.Add(consoleMask_Click);
        GButton collectionButton = view.GetChild("CollectionButton").asButton;
        collectionButton.onClick.Add(collectionButton_Click);
        GButton mailButton = view.GetChild("MailButton").asButton;
        mailButton.onClick.Add(mailButton_Click);
        GButton driveButton = view.GetChild("DriveButton").asButton;
        driveButton.onClick.Add(driveButton_Click);
        // 线索 
        m_clue = view.GetChild("Clue").asGroup;
        initClueList();

        m_clue_simple_name = view.GetChild("ClueSimpleName").asLabel;
        m_clue_simple_name.text = "";
        m_clue_detail_name= view.GetChild("ClueDetailName").asLabel;
        m_clue_detail_name.text = "";
        m_clueContent = view.GetChild("ClueContent").asLabel;
        GButton clueOKButton = view.GetChild("ClueOKButton").asButton;
        clueOKButton.onClick.Add(clueOKButton_Click);
        GButton clueCheckButton = view.GetChild("ClueCheckButton").asButton;
        clueCheckButton.onClick.Add(clueCheckButton_Click);
        m_clue_detail = view.GetChild("ClueDetail").asGroup;
        GButton clueDetailCloseButton = view.GetChild("ClueDetailCloseButton").asButton;
        clueDetailCloseButton.onClick.Add(clueDetailCloseButton_Click);
        GButton clueDetailBackButton = view.GetChild("ClueDetailBackButton").asButton;
        clueDetailBackButton.onClick.Add(clueDetailCloseButton_Click);
        m_clue_detail_content = view.GetChild("ClueDetailContent").asLabel;
        m_clue_detail_content = m_clue_detail_content.GetChild("Label").asLabel;
        // 详细线索系统，用于图像点击，与上面的不一样
        m_clue_simple = view.GetChild("ClueSimple").asGroup;
        m_clue_simple_content = view.GetChild("ClueSimpleContent").asLabel;
        m_clue_simple_content = m_clue_simple_content.GetChild("Label").asLabel;
        GButton clueSimpleCloseButton = view.GetChild("ClueSimpleCloseButton").asButton;
        clueSimpleCloseButton.onClick.Add(clueSimpleCloseButton_Click);
        GButton clueSimpleBackButton = view.GetChild("ClueSimpleBackButton").asButton;
        clueSimpleBackButton.onClick.Add(clueSimpleCloseButton_Click);
        // 墙纸
        m_wallpaper = view.GetChild("WallPaper").asCom;
        GComponent shelf= m_wallpaper.GetChild("Shelf").asCom;
        shelf.onClick.Add(shelf_Click);
        GButton piano = m_wallpaper.GetChild("Piano").asButton;
        piano.onClick.Add(piano_Click);
        GButton chineseZither = m_wallpaper.GetChild("ChineseZither").asButton;
        chineseZither.onClick.Add(chineseZither_Click);
        GButton picture = m_wallpaper.GetChild("Picture").asButton;
        picture.onClick.Add(picture_Click);
        GButton desk = m_wallpaper.GetChild("Desk").asButton;
        desk.onClick.Add(desk_Click);
        GComponent comp = m_wallpaper.GetChild("Comp").asCom;
        comp.onClick.Add(comp_Click);
        // 最后去哪里
        m_wheretogo = view.GetChild("WhereToGo").asGroup;
        GButton washingtonButton = view.GetChild("GotoWashington").asButton;
        washingtonButton.onClick.Add(washingtonButton_Click);
        // 切换场景遮罩，去grace那里还是grandpa那里
        m_change_scene = view.GetChild("ChangeScene").asGroup;
        GButton graceButton = view.GetChild("GraceButton").asButton;
        graceButton.onClick.Add(graceButton_Click);
        GButton grandpaButton = view.GetChild("GrandpaButton").asButton;
        grandpaButton.onClick.Add(grandpaButton_Click);

        m_change_scene2 = view.GetChild("ChangeScene2").asGroup;
        GButton graceButton2 = view.GetChild("GraceButton2").asButton;
        graceButton2.onClick.Add(graceButton_Click2);
        GButton grandpaButton2 = view.GetChild("GrandpaButton2").asButton;
        grandpaButton2.onClick.Add(grandpaButton_Click2);
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
        GButton button_2_1_1_1_2 = view.GetChild("Button_2_1_1_1_2").asButton;
        button_2_1_1_1_2.onClick.Add(button_2_1_1_1_2_Click);

    }

    void initClueList(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        GList clueList = view.GetChild("ClueList").asList;

        GLabel clueUse = clueList.GetChild("ClueUse").asLabel;
        GButton clueUseButton = clueUse.GetChild("Button").asButton;
        clueUseButton.onClick.Add(Use_Click);
        int isClueUse = PlayerPrefs.GetInt("isClueUse");
        if(isClueUse == 0) clueUse.visible = false;
        else clueUse.visible = true;
        
        GLabel clueGPS = clueList.GetChild("ClueGPS").asLabel;
        GButton clueGPSButton = clueGPS.GetChild("Button").asButton;
        clueGPSButton.onClick.Add(GPS_Click);
        int isClueGPS = PlayerPrefs.GetInt("isClueGPS");
        if(isClueGPS == 0) clueGPS.visible = false;
        else clueGPS.visible = true;
        
        GLabel clueShelf = clueList.GetChild("ClueShelf").asLabel;
        GButton clueShelfButton = clueShelf.GetChild("Button").asButton;
        clueShelfButton.onClick.Add(shelf_Click);
        int isClueShelf = PlayerPrefs.GetInt("isClueShelf");
        if(isClueShelf == 0) clueShelf.visible = false;
        else clueShelf.visible = true;
        
        GLabel cluePicture = clueList.GetChild("CluePicture").asLabel;
        GButton cluePictureButton = cluePicture.GetChild("Button").asButton;
        cluePictureButton.onClick.Add(picture_Click);
        int isCluePicture = PlayerPrefs.GetInt("isCluePicture");
        if(isCluePicture == 0) cluePicture.visible = false;
        else cluePicture.visible = true;
    }
}
}

