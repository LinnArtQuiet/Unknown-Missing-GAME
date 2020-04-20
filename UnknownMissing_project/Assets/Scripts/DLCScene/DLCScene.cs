using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using UnityEngine.SceneManagement;
namespace app{
public class DLCScene : MonoBehaviour
{    
    GGroup m_story;
    GGroup m_personList;
    GGroup m_clue;

    GGroup PersonList;
    GGroup GrandpaView;
    GGroup LeeView;
    GGroup CUREView;
    GGroup TaoxiView;
    GGroup GraceView;

    GLabel m_clueCaption;
    GLabel m_clueContent;

    void Start()
    {
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui; // 整个UI的集合

        GButton StoryButton = view.GetChild("StoryButton").asButton;
        StoryButton.onClick.Add(StoryButton_Click);
        m_story = view.GetChild("Story").asGroup;
        GComponent storyMask = view.GetChild("StoryMask").asCom;
        storyMask.onClick.Add(storyMask_Click);
        GLabel chapter1 = view.GetChild("Chapter1").asLabel;
        chapter1.onClick.Add(Chapter_Click1);
        GLabel chapter2 = view.GetChild("Chapter2").asLabel;
        chapter2.onClick.Add(Chapter_Click2);
        GLabel chapter3 = view.GetChild("Chapter3").asLabel;
        chapter3.onClick.Add(Chapter_Click3);
        GLabel chapter4 = view.GetChild("Chapter4").asLabel;
        chapter4.onClick.Add(Chapter_Click4);
        GLabel chapter5 = view.GetChild("Chapter5").asLabel;
        chapter5.onClick.Add(Chapter_Click5);

        GButton HistoryButton = view.GetChild("HistoryButton").asButton;
        HistoryButton.onClick.Add(HistoryButton_Click);
        GComponent ListMask = view.GetChild("ListMask").asCom;
        ListMask.onClick.Add(ListMask_Click);

        m_personList = view.GetChild("PersonList").asGroup;
        GList list = view.GetChild("List").asList;
        GComponent Taoxi= list.GetChild("Taoxi").asCom;
        Taoxi.onClick.Add(Taoxi_Click);
        GComponent Lee= list.GetChild("Lee").asCom;
        Lee.onClick.Add(Lee_Click);
        GComponent Grandpa= list.GetChild("Grandpa").asCom;
        Grandpa.onClick.Add(Grandpa_Click);
        GComponent Grace= list.GetChild("Grace").asCom;
        Grace.onClick.Add(Grace_Click);
        GComponent CURE= list.GetChild("CURE").asCom;
        CURE.onClick.Add(CURE_Click);

        TaoxiView = view.GetChild("Taoxi").asGroup;
        TaoxiView.onClick.Add(Taoxi_Click);
        LeeView = view.GetChild("Lee").asGroup;
        LeeView.onClick.Add(Lee_Click);
        GrandpaView = view.GetChild("Grandpa").asGroup;
        GrandpaView.onClick.Add(Grandpa_Click);
        GraceView = view.GetChild("Grace").asGroup;
        GraceView.onClick.Add(Grace_Click);
        CUREView = view.GetChild("CURE").asGroup;
        CUREView.onClick.Add(CURE_Click);

        GButton ClueButton = view.GetChild("ClueButton").asButton;
        ClueButton.onClick.Add(ClueButton_Click);
        m_clue = view.GetChild("Clue").asGroup;
        m_clueCaption=view.GetChild("ClueCaption").asLabel;
        m_clueContent=view.GetChild("ClueContent").asLabel;
        GButton rightButton = view.GetChild("RightButton").asButton;
        rightButton.onClick.Add(rightButton_Click);
        GButton leftButton = view.GetChild("LeftButton").asButton;
        leftButton.onClick.Add(leftButton_Click);
        GComponent clueMask = view.GetChild("ClueMask").asCom;
        clueMask.onClick.Add(clueMask_Click);
    }
    void StoryButton_Click(){
        m_story.visible = true;
    }
    void storyMask_Click(){
        m_story.visible = false;
    }
    void Chapter_Click1(){
        PlayerPrefs.SetInt("m_i", 0);
        SceneManager.LoadScene("HomeScene");
    }
    void Chapter_Click2(){
        PlayerPrefs.SetInt("m_i", 0);
        SceneManager.LoadScene("GrandpaScene");
    }
    void Chapter_Click3(){
        PlayerPrefs.SetInt("m_i", 50);
        SceneManager.LoadScene("HomeScene");
    }
    void Chapter_Click4(){
        PlayerPrefs.SetInt("m_i", 0);
        SceneManager.LoadScene("GraceScene");
    }
    void Chapter_Click5(){
        PlayerPrefs.SetInt("m_i", 3);
        SceneManager.LoadScene("SubtitleScene");
    }

    void HistoryButton_Click(){
        m_personList.visible = true;
    }
    void ListMask_Click(){
        m_personList.visible = false;
    }
    void Taoxi_Click(){
        TaoxiView.visible = !TaoxiView.visible;
    }
    void Lee_Click(){
        LeeView.visible = !LeeView.visible;
    }
    void Grandpa_Click(){
        GrandpaView.visible = !GrandpaView.visible;
    }
    void Grace_Click(){
        GraceView.visible = !GraceView.visible;
    }
    void CURE_Click(){
        CUREView.visible = !CUREView.visible;
    }

    void ClueButton_Click(){
        m_clue.visible = true;
    }
    void rightButton_Click(){
        m_i = m_i+1;
        if(m_i == 5) m_i=0;
        m_clueCaption.text = str_caption[m_i];
        m_clueContent.text = str_content[m_i];
    }
    void leftButton_Click(){
        m_i = m_i+1;
        if(m_i == -1) m_i = 4;
        m_clueCaption.text = str_caption[m_i];
        m_clueContent.text = str_content[m_i];
    }
    void clueMask_Click(){
        m_clue.visible = false;
    }
    int m_i = 0;
    private string[] str_caption = {
        "Diary 1: 转弯的车",
        "Diary 2: 白色的钟",
        "Diary 3: 双胞胎的故事",
        "Diary 4: 不想变成透明人",
        "Diary 5：虚假的爱人"
    };
    private string[] str_content = {
        @"雅典的大街上，一起交通事故现场正在处理。
一名老汉当场死亡。
根据无人驾驶AI的行车记录。向左转会撞到5个孩子，向右转会撞到一名老汉，全力制动有70%的可能导致车辆引擎过热，车辆侧翻后发生爆炸。
周围的人议论纷纷。
路人甲：那老汉就站在人行道也能被撞？这车是不是有问题呀？
路人乙：你没看见那有五个孩子啊，数量级和年龄摆在那里的。
路人丙：可是因为他们那些小孩闯红灯才导致车子失控的呀？老爷爷安安分分没了性命太不公平了！",
        @"走在西安的大街上，cure看见一个持续响着的人工智能闹钟被从窗户丢出。
根据周围邻居的说法，自从楼上买了这个人工智能闹钟以后，每天早上8点都能听到摔东西的声音。
那个住户丢出人工智能闹钟以后还在骂骂咧咧，老子就想多睡10分钟，一个机器人还就不让我睡个懒觉了。
我捡起路上的小猫头鹰，他似乎十分耐摔，现在也只是外壳碎裂，内部系统依旧在运行，我问他，“为什么不让用户多睡十分钟呢？”他说，“可是用户每天晚上睡觉前都说，明天一定要准时起床，并且我的出厂设置就是不睡懒觉闹钟” 
Cure捡起人工智能闹钟：你叫什么名字？
闹钟：我叫小白
Cure：他们都不喜欢我们，你要跟我一起走吗？
小白：走去哪里呀?
Cure :我也不知道，就自己生活吧，我不喜欢人类了
小白：反正我也无家可归，我也不喜欢反复无常的人类了，是他们叫着我帮他改掉坏习惯，可你看看我得到的只有浑身上下的伤，我们一起去流浪吧
Cure：好，我带着你一起流浪",
        @"伦敦的广场上有一个全息投影的屏幕，上面播着一则新闻。
某家的双胞胎两人
一人游戏成瘾，痴迷于竞技游戏，他的AI助理根据愉悦值和用户喜好逐渐增加此人日常生活中游戏时间，目前，此人除了必须的吃饭睡觉时间以外，所有时间都被安排为打游戏。如果失去了政府的膳食补助，此人将无法继续活下去，彻底成为一个游戏人。
另一人利用AI助理统计调度，合理安排每天的日程规划，一旦出现与大多数人不符合的日程安排，AI就会立即提示并采取各种方式要求他回归大众日程，他的时间安排较为合理，人生发展前景潜力大，但个人兴趣被强制压制。
这则新闻则在讨论AI在人的自我发展中到底是否需要参考个人意见，还是应当趋同态势统一协调",
        @"AI购物助理，大行其道。
巴黎的一家商店里，顾客正在和门店AI争吵
客：我之前预定的衣服为什么卖给了别人？
AI：我们通过您的购物助理了解到，您近期的购物意愿较低，且预付的心理价位也不如另一位买家，综合评估下，我们选择了另一位买家。
客：可她并没有预定！
AI：是的，但是您也并没有交预付款项，且在您的购物信息里我们发现您有着与我们产品相类似的替代品出现，您多次的预定衣服却只在优惠期间购买的行为被助理判定为价格用户，我们评估您的商品付款概率仅有10%，另一位顾客是90%，在只剩一件的情况下，为了我们三方的最大资金利用率，我们做出了这种选择请您谅解。
客气急而去，当场将自己的AI购物助理信息清空。
消费者一方面想要让购物APP把握自己的喜好，推荐自己喜欢的商品。一方面又不希望自己的购物信息被商人们分析，从而进行大数据杀熟的行为。",
        @"AI婚配大行其道，我看到路边有一个正在哭泣的妇人，便上前安慰。
妇人说道：在AI的婚配选择下，我选择了现在的爱人，但在结婚一年后渐渐发现，
AI婚配的所谓合适之人，只在属性值显示为合适，但实际表现与现实的属性差异很大。
在多次质问之下，他才终于坦白自己在婚配属性数据上造假以便匹配更好的对象的行为。
我现在每天以泪洗面，想当初花了那么多钱，只为了能寻找到一个与我相合的人白头偕老互相扶持，
现在被AI全毁了，还不如自己老老实实相亲恋爱，也比这个强。"
    };
}
}

