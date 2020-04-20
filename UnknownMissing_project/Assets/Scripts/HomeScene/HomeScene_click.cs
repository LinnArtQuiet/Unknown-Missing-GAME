using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace app{
public partial class HomeScene : MonoBehaviour{
    
    void nextButton_Click()
    {
        if (m_i < 6) 
        {
            ControlDialogue();
        }
        else if (m_i == 6) // [玩家操作选择] 选择1 ： Lee是谁？；选择2 ：邮件内容是什么？
        {
            m_mask_0.visible = true;
        }
        else if ((m_i>=7) && (m_i<10)){
            if(m_i == 8) ChangeAvatar(0); 
            ControlDialogue();
        }
        else if(m_i == 10){ // [玩家操作选择] 选择1.1 ：（更喜欢纸质阅读）；选择1.1 ：阅读
            m_mask_1.visible = true;
        }
        else if((m_i>=12) && (m_i<13))
        {
            ControlDialogue();
        }
        else if(m_i == 13){ // [玩家操作选择] 选择1.1.1 ：看看吧 ; 选择1.1.2 ：无事不登三宝殿 ； 选择1.1.3：不看
            UIPanel panel = gameObject.GetComponent<UIPanel>();
            GComponent view = panel.ui; // 整个UI的集合
            int isBackMail = PlayerPrefs.GetInt("isBackMail");
            GButton button_1_1_3 = view.GetChild("Button_1_1_3").asButton;
            if(isBackMail == 1)
                button_1_1_3.visible = true; // 1代表显示，0代表消失 
            else button_1_1_3.visible = false;

            m_mask_1_1.visible = true;
            m_i++; 
        }
        else if((m_i >= 15) && (m_i < 18)){
            ControlDialogue();
        }
        else if(m_i == 18){ // [玩家操作选择] 选择2.1 ：回信 ; 选择2.2 ：不回
            UIPanel panel = gameObject.GetComponent<UIPanel>();
            GComponent view = panel.ui; // 整个UI的集合
            int isBackMail = PlayerPrefs.GetInt("isBackMail");
            GButton button_2_2 = view.GetChild("Button_2_2").asButton;
            if(isBackMail == 1)
                button_2_2.visible = true; // 1代表显示，0代表消失 
            else button_2_2.visible = false;

            m_mask_2.visible = true;
        }
        else if((m_i>=19) && (m_i<22)){
            if(m_i == 20) ChangeAvatar(0);
            ControlDialogue();
        }
        else if(m_i == 22){ // [玩家操作选择] 选择2.1.1 ：一分钟后
            m_mask_2_1.visible = true;
        }
        else if((m_i>=23) && (m_i<24)){
            ControlDialogue();
        }
        else if(m_i == 24){ // [玩家操作选择] 选择2.1.1.1 ：阅读邮件
            m_mask_2_1_1.visible = true;
        }
        else if((m_i>=26) && (m_i<27)){
            ControlDialogue();
        }
        else if(m_i == 27){ // [玩家操作选择] 选择2.1.1.1.1 ：CURE的使用记录；选择2.1.1.1.2 ：CURE的GPS数据
            m_mask_2_1_1_1.visible = true;
        }
        else if((m_i>=28) && (m_i<30)){ // [开始播放相关系统的新手引导]选择2.1.1.1.1 ：CURE的使用记录
            ControlDialogue();
        }
        else if(m_i == 30){ // 需要用户自己点击
            m_dialog.text = "";
        }
        else if((m_i>=36) && (m_i<38)){
            if(m_i == 37) ChangeAvatar(0);
            ControlDialogue();
        }
        else if((m_i>=39) && (m_i<41)){ // [开始播放相关系统的新手引导]选择2.1.1.1.2 ：CURE的GPS数据
            ControlDialogue();
        }
        else if(m_i == 41){
            m_dialog.text = "";
        }
        else if((m_i>=47) && (m_i<49)){
            if(m_i == 48) ChangeAvatar(0);
            ControlDialogue();
        }
        else if((m_i>=50) && (m_i<56)){ // 中转章
            if(m_i == 51) ChangeAvatar(1);
            if(m_i == 52) ChangeAvatar(0);
            int fristTurnTo = PlayerPrefs.GetInt("fristTurnTo");
            if(fristTurnTo == 2){ // 说明跳到了第二章
                strs[54] = "根据10283451条互联网数据，结合与Grandpa的聊天内容，建议与Grace取得联系。";
                strs[55] = "是时候去找一下Grace了。";
            }
            else if(fristTurnTo == 3){ // 说明跳到了第三章
                strs[54] = "根据10283451条互联网数据，结合与Grace的聊天内容，建议与Grandpa取得联系。";
                strs[55] = "是时候去找一下Grandpa了。";
            }
            ControlDialogue();
        }
        else if(m_i == 56){ // 这里就是跳转章节的
            int fristTurnTo = PlayerPrefs.GetInt("fristTurnTo");
            if(fristTurnTo == 2){ // 说明跳到了第二章
                m_change_scene.visible = true;
            }
            else if(fristTurnTo == 3){ // 说明跳到了第三章
                m_change_scene2.visible = true;
            }
            m_change_scene.visible = true;
        }
        else if((m_i>=57) && (m_i<58)){ // 终章结束了快
            ControlDialogue();
        }
        else if(m_i == 58){
            m_guild.visible = true;
            m_i = 59;
            isActive = true;
        }
        else if((m_i>=67) && (m_i<68)){ // 隐藏剧情的语句控制
            PlayerPrefs.SetInt("isBackMail", 0); // 就是到隐藏剧情了
            ControlDialogue();
        }
        else if(m_i == 68){
            m_i = 69;
            isActive = true;
        }
        else if((m_i>=69) && (m_i<77)){
            if(m_i == 69) ChangeAvatar(1);
            if(m_i == 70) ChangeAvatar(0);
            if(m_i == 74) ChangeAvatar(1);
            if(m_i == 75) ChangeAvatar(0);
            if(m_i == 76) ChangeAvatar(1);
            ControlDialogue();
        }
        else if(m_i == 77){
            m_mail_sender.text = mail_strs[0];
            m_mail_content.text= mail_strs[1];
            m_mail.visible = true;
        }
        Debug.Log(m_i);
    }
    void guildMask_Click()
    {
        if((m_i>=31) && (m_i<35)){ // 显示线索1：CURE的使用数据
            ControlDialogue();
        }
        else if(m_i == 35){
            m_guild.visible = false;
            PlayerPrefs.SetInt("isClueUse", 1);
            initClueList();
            m_clueContent.text = "CURE的使用记录";
            m_clue_detail_name.text = "CURE的使用记录";
            m_clue_detail_content.text = clue_strs[0];
            m_clue.visible = true;
        }
        else if((m_i>=42) && (m_i<46)){ // 显示线索2：CURE的GPS数据
            ControlDialogue();
        }
        else if(m_i == 46){
            m_guild.visible = false;
            PlayerPrefs.SetInt("isClueGPS", 1);
            initClueList();
            m_clueContent.text = "CURE的GPS数据";
            m_clue_detail_name.text = "CURE的GPS数据";
            m_clue_detail_content.text = clue_strs[3];
            m_clue.visible = true;
        }
        else if((m_i>=59) && (m_i<61)){ // 最后的东西了
            ControlDialogue();
        }
        else if(m_i == 61){
            m_guild.visible = false;
        }
    }
    void mailCloseButton_Click() // 关闭邮箱之后也会触发剧情
    { 
        m_mail.visible = false;
        if(m_i == 14){ // 1.1.1选择，后接选择2的剧情。
            m_i = 15; // 剧情2
            ChangeAvatar(1);
            isActive = true; // 开启字幕
        }
        else if(m_i == 25){
            m_i = 26;
            isActive = true;
        }
        else if(m_i == 77){
            m_i = 15; // CURE项目竟然被做出来了，导师没有失...
            isActive = true;
        }
    }

    void personaldata_Click(){
        m_personaldata.visible = false;
        m_i = 12;
        isActive = true;
    }

    void consoleMask_Click(){
        m_console.visible = false;
    }
    void collectionButton_Click(){
        m_console.visible = false;
        m_clue.visible = true;
    }
    void mailButton_Click(){
        m_console.visible = false;
        m_mail.visible = true;
    }
    void driveButton_Click(){
        m_console.visible = false;
        if(m_i == 38){ // 去Grandpa那里
            PlayerPrefs.SetInt("m_i", 0);
            PlayerPrefs.SetInt("fristTurnTo", 2); 
            SceneManager.LoadScene("DriveScene");
        }
        else if(m_i == 49){ // 去Grace那里
            PlayerPrefs.SetInt("m_i", 7);
            PlayerPrefs.SetInt("fristTurnTo", 3);
            SceneManager.LoadScene("DriveScene");
        }
    }
    // 线索部分
    void clueCheckButton_Click(){
        m_clue_detail.visible = true;
    }    
    void clueOKButton_Click(){
        m_clue.visible = false;
        if(m_i == 35){
            m_i = 36;
            ChangeAvatar(1);
            m_console.visible = false;
            isActive = true;
        }
        else if(m_i == 46){
            m_i = 47;
            ChangeAvatar(1);
            m_console.visible = false;
            isActive = true;
        }
    }
    void clueDetailCloseButton_Click(){
        m_clue_detail.visible = false;
    }
    void clueSimpleCloseButton_Click(){ // 将clue进行区分真不是好事
        m_clue_simple.visible = false;
        if(m_i == 68){
            m_i = 69;
            isActive = true;
        }
        else if(m_i == 90){
            m_i = 91;
            isActive = true;
        }
    }
    // 转换场景的
    void graceButton_Click(){ // 它有用
        PlayerPrefs.SetInt("m_i", 7);
        SceneManager.LoadScene("DriveScene");
    }
    void grandpaButton_Click(){}
    void grandpaButton_Click2(){ // 它有用
        PlayerPrefs.SetInt("m_i", 0);
        SceneManager.LoadScene("DriveScene");
    }
    void graceButton_Click2(){}

    void shelf_Click(){
        PlayerPrefs.SetInt("isClueShelf", 1);
        initClueList();
        m_clue_simple_name.text = "线索：开发工作记录1";
        m_clue_simple_content.text = clue_strs[1];
        m_clue_simple.visible = true;
    }
    void piano_Click(){
        sound.Stop();
        sound.PlayOneShot(piano_wav);
    }
    void chineseZither_Click(){
        sound.Stop();
        sound.PlayOneShot(ChineseZither_wav);
    }

    void picture_Click(){
        PlayerPrefs.SetInt("isCluePicture", 1);
        initClueList();
        m_clue_simple_name.text = "线索：国际健康管理人工智能开发准则";
        m_clue_simple_content.text = clue_strs[2];
        m_clue_simple.visible = true;
    }
    void desk_Click(){
        m_console.visible = true;
    }
    void Use_Click(){
        m_clueContent.text = "CURE的使用记录";
        m_clue_detail_name.text = "CURE的使用记录";
        m_clue_detail_content.text = clue_strs[0];
        m_clue_detail.visible = true;
    }
    void GPS_Click(){
        m_clueContent.text = "CURE的GPS数据";
        m_clue_detail_name.text = "CURE的GPS数据";
        m_clue_detail_content.text = clue_strs[3];
        m_clue_detail.visible = true;
    }
    void comp_Click(){
        if(m_i == 30){
            m_guild.visible = true;
            m_console.visible = true;
            m_i = 31;
            isActive = true;
        }
        else if(m_i == 38){ // 直接切换到grandpa了
            m_console.visible = true;
        }
        else if(m_i == 41){
            m_guild.visible = true;
            m_console.visible = true;
            m_i = 42;
            isActive = true;
        }
        else if(m_i == 49){ // 直接切换到grace那里了
            m_console.visible = true;
        }
        else if(m_i == 61){
            m_wheretogo.visible = true;
        }
            
    }
    void washingtonButton_Click(){
        PlayerPrefs.SetInt("m_i", 3);
        SceneManager.LoadScene("SubtitleScene");
    }
    void button_1_Click() // 选择1 ： Lee是谁？
    {
        m_mask_0.visible = false;
        ChangeAvatar(1);
        m_i = 7; // "Comp，Lee是谁，为何会给我发邮件？邮件内容是什么？"
        isActive = true;
    }
    void button_1_1_Click()
    {
        m_mask_1.visible = false;
        m_personaldata.visible = true;
    }
    void button_1_1_1_Click(){ // 看看吧
        m_dialog.text = "";
        m_mask_1_1.visible = false;
        m_mail_sender.text = mail_strs[0];
        m_mail_content.text= mail_strs[1];
        m_mail.visible = true;
    }
    void button_1_1_2_Click() // 触发第四章，最终章
    {
        PlayerPrefs.SetInt("m_i", 8); // 触发隐藏剧情
        SceneManager.LoadScene("SubtitleScene");
    }
    void button_2_Click() // 选择2 ：邮件内容是什么？
    {
        m_mask_0.visible = false;
        m_mail_sender.text = mail_strs[0];
        m_mail_content.text = mail_strs[1];
        m_mail.visible = true;
        m_i = 14;
    }
    void button_2_1_Click()
    {
        m_mask_2.visible = false;
        m_i = 19;
        isActive = true;
    }
    void button_2_1_1_Click()
    {
        m_mask_2_1.visible = false;
        m_i = 23;
        isActive = true;
    }
    void button_2_1_1_1_Click() // 阅读邮件
    {
        m_mask_2_1_1.visible = false;
        m_dialog.text = "";
        m_mail_content.text = mail_strs[2];
        m_mail.visible = true;
        m_i = 25;
    }
    void button_2_1_1_1_1_Click(){ // CURE的使用记录
        m_mask_2_1_1_1.visible = false;
        m_i = 28;
        isActive = true;
    }
    void button_2_1_1_1_2_Click(){ // CURE的GPS数据
        m_mask_2_1_1_1.visible = false;
        m_i = 39;
        isActive = true;
    }
    void button_2_2_Click() // 选择2.2 ：不回
    {
        PlayerPrefs.SetInt("m_i", 8); // 触发隐藏剧情
        SceneManager.LoadScene("SubtitleScene");
    }

}
}