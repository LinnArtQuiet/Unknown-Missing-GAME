using FairyGUI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace app{
public partial class HomeScene : MonoBehaviour{
    
    void nextButton_Click()
    {
        if (m_i < 6) // 0_1~0_6 的前6句对话
        {
            ControlDialogue(); // 这个函数用来依次执行语句
        }
        else if (m_i == 6) // [玩家操作选择] 选择1 ： Lee是谁？；选择2 ：邮件内容是什么？
        {
            m_mask_0.visible = true;
        }
        else if ((m_i>=7) && (m_i<10)){ 
            ControlDialogue();
        }
        else if(m_i == 10){ // [玩家操作选择] 选择1.1 ：（更喜欢纸质阅读）；选择1.1 ：阅读
            m_mask_1.visible = true;
        }
        else if(m_i == 11){
            //m_personalData.visible = true;
        }
        else if((m_i>=12) && (m_i<13))
        {
            ControlDialogue();
        }
        else if(m_i == 13){ // [玩家操作选择] 选择1.1.1 ：看看吧 ; 选择1.1.2 ：无事不登三宝殿 ； 选择1.1.3：不看
            m_mask_1_1.visible = true;
            m_i++; // 看来注定这个按钮不能处理所有的m_i
        }
        else if((m_i >= 15) && (m_i < 18)){
            ControlDialogue();
        }
        else if(m_i == 18){
            m_mask_2.visible = true;
        }
        else if((m_i>=19) && (m_i<22)){
            ControlDialogue();
        }
        else if(m_i == 22){
            m_mask_2_1.visible = true;
        }
        else if((m_i>=23) && (m_i<24)){
            ControlDialogue();
        }
        else if(m_i == 24){
            m_mask_2_1_1.visible = true;
        }
        else if((m_i>=26) && (m_i<27)){
            ControlDialogue();
        }
        else if(m_i == 27){
            m_mask_2_1_1_1.visible = true;
        }
        else if((m_i>=28) && (m_i<30)){
            ControlDialogue();
        }
        else if(m_i == 30){
            m_dialog.text = "";
            m_guild.visible = true;
            m_i = 31;
            isActive = true;
        }
        else if((m_i>=36) && (m_i<38)){
            ControlDialogue();
        }
        else if(m_i == 38){
            PlayerPrefs.SetInt("m_i", 0);
            SceneManager.LoadScene("DriveScene");
        }
        else if((m_i>=39) && (m_i<41)){
            ControlDialogue();
        }
        else if(m_i == 41){ // [开始播放相关系统的新手引导]
            m_guild.visible = true;
            m_i = 42;
            isActive = true;
        }
        else if((m_i>=47) && (m_i<48)){
            ControlDialogue();
        }
        else if(m_i == 49){
            PlayerPrefs.SetInt("m_i", 7);
            SceneManager.LoadScene("DriveScene");
            
        }
    }
    void guildMask_Click()
    {
        if((m_i>=31) && (m_i<35)){
            ControlDialogue();
        }
        else if(m_i == 35){
            m_guild.visible = false;
            m_clue.visible = true;
        }
        else if((m_i>=42) && (m_i<46)){
            ControlDialogue();
        }
        else if(m_i == 46){ // 显示线索2：CURE的GPS数据
            m_guild.visible = false;
            m_clue.visible = true;
        }
    }
    void mailCloseButton_Click() // 关闭邮箱之后也会触发剧情
    { 
        m_mail.visible = false;
        if(m_i == 14){ // 1.1.1选择，后接选择2的剧情。
            m_i = 15; // 剧情2
            isActive = true; // 开启字幕
        }
        else if(m_i == 25){
            m_i = 26;
            isActive = true;
        }
    }
    void button_1_Click() // 选择1 ： Lee是谁？
    {
        m_mask_0.visible = false;
        m_i = 7; // "Comp，Lee是谁，为何会给我发邮件？邮件内容是什么？"
        isActive = true;
    }
    void button_1_1_Click()
    {
        m_mask_1.visible = false;
        m_i = 12;
        isActive = true;
    }
    void button_1_1_1_Click(){
        m_dialog.text = "";
        m_mask_1_1.visible = false;
        m_mail.visible = true;
    }
    void button_1_1_2_Click()
    {
        m_mail.visible = true;
        m_i = 15; // 后面接2的剧情
        isActive = true;
    }
    void button_2_Click() // 选择2 ：邮件内容是什么？
    {
        m_mask_0.visible = false;
        m_mail.visible = true;
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
        m_mail.visible = true;
        m_i = 25;
    }
    void button_2_1_1_1_1_Click(){ // CURE的使用记录
        m_mask_2_1_1_1.visible = false;
        m_i = 28;
        isActive = true;
        // SceneManager.LoadScene("GrandpaScene"); // 跳转到第二章
    }
    void button_2_1_1_1_2_Click(){ // CURE的GPS数据
        m_mask_2_1_1_1.visible = false;
        m_i = 39;
        isActive = true;
    }
    void button_2_2_Click()
    {
        //TODO:触发隐藏剧情
    }
    void consoleMask_Click(){
        if ((m_i>=31) && (m_i<35)){ 
            ControlDialogue();
        }
        else if(m_i == 35){
            m_console_mask.visible = false;
            m_i = 36;
            isActive = true;
        }
    }
    void clueOKButton_Click(){
        m_clue.visible = false;
        if(m_i == 35){
            m_i = 36;
            isActive = true;
        }
        else if(m_i == 46){
            m_i = 47;
            isActive = true;
        }
    }
}
}