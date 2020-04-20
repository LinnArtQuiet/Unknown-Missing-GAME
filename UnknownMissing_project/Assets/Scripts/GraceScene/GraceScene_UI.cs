using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace app{
public partial class GraceScene : MonoBehaviour{
    private GComponent[] m_avatar;    
    private GLabel m_dialog; // 显示字符串的面板
    private GButton m_nextButton;
    private GGroup m_clue;
    private GGroup m_clue1; // 完完全全就是补丁了
    private GLabel m_clueName;
    private GLabel m_clueContent;
    private GLabel m_cluePoint;
    private GGroup m_console;
    private GGroup m_entrance;

    public void initUI(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        m_avatar = new GComponent[3];
        m_avatar[0] = view.GetChild("AvatarGuard").asCom;
        m_avatar[1] = view.GetChild("AvatarTaoxi").asCom;
        m_avatar[2] = view.GetChild("AvatarComp").asCom;
        // 上面的对话框
        m_dialog = view.GetChild("Dialog").asLabel;
        m_dialog.text = "";
        m_nextButton = view.GetChild("NextButton").asButton;
        m_nextButton.onClick.Add(nextButton_Click);

        m_clue = view.GetChild("Clue").asGroup;
        m_clue1 = view.GetChild("Clue1").asGroup;
        initClueList();
        GButton clueOKButton = view.GetChild("ClueOKButton").asButton;
        clueOKButton.onClick.Add(clueOKButton_Click);
        m_clueName = view.GetChild("ClueName").asLabel;
        m_clueContent = view.GetChild("ClueContent").asLabel;
        m_cluePoint = view.GetChild("CluePoint").asLabel;
        m_clueContent = m_clueContent.GetChild("Label").asLabel;
        m_clueContent.text = "";
        GComponent clueCloseButton = view.GetChild("ClueCloseButton").asCom;
        clueCloseButton.onClick.Add(clueCloseButton_Click);

        m_entrance=view.GetChild("Entrance").asGroup;

        m_console= view.GetChild("Console").asGroup;
        GButton collectionButton = view.GetChild("CollectButton").asButton;
        collectionButton.onClick.Add(collectionButton_Click);
        GButton driveButton = view.GetChild("DriveButton").asButton;
        driveButton.onClick.Add(driveButton_Click);

        GComponent wallpaper = view.GetChild("Wallpaper").asCom;
        GComponent map = wallpaper.GetChild("Map").asCom;
        map.onClick.Add(map_Click);
        GComponent brain = wallpaper.GetChild("Brain").asCom;
        brain.onClick.Add(brain_Click);
        GComponent ball = wallpaper.GetChild("Ball").asCom;
        ball.onClick.Add(ball_Click);
        GComponent desk = wallpaper.GetChild("Desk").asCom;
        desk.onClick.Add(desk_Click);
        GComponent comp = wallpaper.GetChild("Comp").asCom;
        comp.onClick.Add(comp_Click);
    } 
    void nextButton_Click(){
        ChangeAvatar(m_i % 2);
        if(m_i >= 5) ChangeAvatar(2);
        if((m_i>=0) && (m_i<6)){
            if(m_i == 4) m_entrance.visible = false;
            ControlDialogue();
        }
    }
    void clueCloseButton_Click(){
        m_clue.visible = false;
    }
    void clueOKButton_Click(){
        m_clue1.visible = false;
    }
    void comp_Click(){
        if(m_i == 6){
            m_console.visible = true;
        }
    }
    void map_Click(){
        PlayerPrefs.SetInt("isClueMap", 1); 
        initClueList();
        m_clueName.text = "线索：Grace的旅行计划";
        m_clueContent.text = clue_strs[0];
        m_cluePoint.text = "线索指向：Grace";
        m_clue.visible = true;
    }
    void brain_Click(){
        PlayerPrefs.SetInt("isClueBrain", 1); 
        initClueList();
        m_clueName.text = "线索：开发工作记录2";
        m_clueContent.text = clue_strs[1];
        m_cluePoint.text = "线索指向：未知";
        m_clue.visible = true;
    }
    void ball_Click(){
        PlayerPrefs.SetInt("isClueBall", 1); 
        initClueList();
        m_clueName.text = "线索：大国崛起影碟简介";
        m_clueContent.text = clue_strs[2];
        m_cluePoint.text = "线索指向：未知";
        m_clue.visible = true;
    }
    void desk_Click(){
        PlayerPrefs.SetInt("isClueDesk", 1); 
        m_clueName.text = "线索：全球通史目录残页";
        m_clueContent.text = clue_strs[3];
        m_cluePoint.text = "线索指向：未知";
        m_clue.visible = true;
    }

    void collectionButton_Click(){
        m_console.visible = false;
        m_clue1.visible = true;
    }
    void driveButton_Click(){
        if(fristTurnTo == 3){ // 跳到中转章
            PlayerPrefs.SetInt("m_i", 14);
            PlayerPrefs.SetInt("fristTurnTo", 3);
            SceneManager.LoadScene("DriveScene");
        }
        else if(fristTurnTo == 2){ // 跳到最后
            PlayerPrefs.SetInt("m_i", 17);
            PlayerPrefs.SetInt("fristTurnTo", 2);
            SceneManager.LoadScene("DriveScene");
        }
    }

        void initClueList(){
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合
        GList clueList = view.GetChild("ClueList").asList;

        GLabel clueMap = clueList.GetChild("ClueMap").asLabel;
        GButton clueMapButton = clueMap.GetChild("Button").asButton;
        clueMapButton.onClick.Add(map_Click);
        int isClueMap = PlayerPrefs.GetInt("isClueMap");
        if(isClueMap == 0) clueMap.visible = false;
        else clueMap.visible = true;
        
        GLabel clueBrain = clueList.GetChild("ClueBrain").asLabel;
        GButton clueBrainButton = clueBrain.GetChild("Button").asButton;
        clueBrainButton.onClick.Add(brain_Click);
        int isClueBrain = PlayerPrefs.GetInt("isClueBrain");
        if(isClueBrain == 0) clueBrain.visible = false;
        else clueBrain.visible = true;
        
        GLabel clueBall = clueList.GetChild("ClueBall").asLabel;
        GButton clueBallButton = clueBall.GetChild("Button").asButton;
        clueBallButton.onClick.Add(ball_Click);
        int isClueBall = PlayerPrefs.GetInt("isClueBall");
        if(isClueBall == 0) clueBall.visible = false;
        else clueBall.visible = true;
        
        GLabel clueDesk = clueList.GetChild("ClueDesk").asLabel;
        GButton clueDeskButton = clueDesk.GetChild("Button").asButton;
        clueDeskButton.onClick.Add(desk_Click);
        int isClueDesk = PlayerPrefs.GetInt("isClueDesk");
        if(isClueDesk == 0) clueDesk.visible = false;
        else clueDesk.visible = true;
    }
    
}
}