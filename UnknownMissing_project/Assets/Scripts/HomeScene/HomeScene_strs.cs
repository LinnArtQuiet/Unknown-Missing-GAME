using FairyGUI;
using UnityEngine;

namespace app{
public partial class HomeScene : MonoBehaviour{
        private string[] strs = {"你好，欢迎进入工作室~", // str[0]
            "我是你的私人助理Comp",
            "你可以左右拉动屏幕来获取工作室的全貌",
            "现播报昨日工作进度和当前未处理事项：",
            "昨天是休息日，没有工作进度",
            "当前有一封未读邮件，发件人为Lee",
            "[玩家操作选择] 选择1 ： Lee是谁？；选择2 ：邮件内容是什么？", // strs[6]
            "Comp，Lee是谁，为何会给我发邮件？", // strs[7]
            "收到疑问内容，正在进行搜寻……",
            "搜寻结束，Lee是您的大学同学，他的本科生导师和您CURE项目的导师是同一个人，\nLee的所有资料已经精简成简历，请问是听读还是阅读？",
            "[玩家操作选择] 选择1.1 ：（更喜欢纸质阅读）；选择1.1 ：阅读", // strs[10]
            "显示档案资料系统中Lee的个人资料页，玩家点击关闭资料页窗口后。", // strs[11]
            "您已阅读完毕，请问是否需要阅读邮件内容？", // strs[12]
            "[玩家操作选择] 选择1.1.1 ：看看吧 ; 选择1.1.1 ：无事不登三宝殿 ； 选择1.1.2：不看", // strs[13]
            "直接打开邮件系统，显示邮件内容，玩家点击关闭邮件系统后。", // strs[14]
            "CURE项目竟然被做出来了，导师没有失踪，\n这几年她自己一个人完成了所有研究吗？", // strs[15] 选择2
            "CURE还是以前构想的样子吗？",
            "一大堆疑问在脑中浮现。",
            "[玩家操作选择] 选择2.1 ：回信 ; 选择2.2 ：不回", // strs[18]
            "回个信吧，告诉李之一，烦请提供详细资料，以便开展调查。", // strs[19]
            "收到，正在通过语音内容生成邮件……",
            "邮件内容已生成并发送", // strs[21]
            "[玩家操作选择] 选择2.1.1 ：一分钟后", // strs[22]
            "收到一封邮件，发件人为Lee", // strs[23]
            "[玩家操作选择] 选择2.1.1.1 ：阅读邮件", // strs[24]
            "显示回复的邮件。", // strs[25]
            "请选择一个线索进行深入探查", // strs[26]
            "[玩家操作选择] 选择2.1.1.1.1 ：CURE的使用记录；选择2.1.1.1.2 ：CURE的GPS数据", // strs[27]
            "CURE的使用记录已进入线索收集栏", // strs[28] 选择2.1.1.1.1 ：CURE的使用记录；
            "请点击我获取相关智能数据服务",
            "", // strs[30]
            "点击邮件阅读服务\n可以查看当前\n已经收到的邮件", // strs[31][开始播放相关系统的新手引导]
            "点击无人驾驶服务\n可以前往地图上的\n其他地点",
            "点击目前线索整理\n可以查看当前已经\n收集到的线索",
            "现在来看看最新的\n一条线索吧",
            "显示线索1：CURE的使用记录", // strs[35]
            "看来CURE依旧保留了原有的红外探测扫描人体的功能，\n导师还新增了排斥方案和调整模式，但是机子最后还是崩溃了。\n或许需要去拜访一下李之一的爷爷。", // strs[36]
            "点击我启动无人驾驶预约服务", // strs[37]
            "[切换到Drive场景]",         // strs[38] 去Grandpa那里
            "CURE的GPS数据已进入线索收集栏", // strs[39] 选择2.1.1.1.2 ：CURE的GPS数据
            "请点击我获取相关智能数据服务",
            "", // strs[41]
            "点击邮件阅读服务\n可以查看当前\n已经收到的邮件", // strs[42][开始播放相关系统的新手引导]
            "点击无人驾驶服务\n可以前往地图上的\n其他地点",
            "点击目前线索整理\n可以查看当前已经\n收集到的线索",
            "现在来看看最新的\n一条线索吧",
            "显示线索2：CURE的GPS数据", // strs[46]
            "看来CURE还是有GPS功能的\n但是为何信号又消失了\n或许需要去拜访一下Grace导师。", // strs[47]
            "点击我启动无人驾驶预约服务",
            "[切换到Drive场景]",  // strs[49] 去Grace那里
            "欢迎回家，外出工作期间并无新的工作邮件。", // strs[50]
            "爬取一下网络上有关CURE的信息。\n我找一下我这边有没有什么有效信息。\n哦，对了，还有Lee邮件的另一个附件也需要查看。",
            "收到工作指令，正在启动执行程序。",
            "您可以左右拖动场景，并点击场景中的道具收集线索。\n点击我可以查看已经收集到的线索",
            "根据10283451条互联网数据，结合与A的聊天内容，建议与B取得联系。", // strs[54]
            "是时候去找一下B了。", // strs[55]
            "[切换场景]终章", // strs[56] 这里就是最后了
            "欢迎回家。\n您可以左右拖动场景，并点击场景中的道具收集线索。\n点击我可以查看已经收集到的线索。", // strs[57]
            "[玩家最终的线索推导]：图见PPT，台词放在 新手引导对话框.png 内", // strs[58]
            "如果您已根据线索推导\n出CURE的所在地，\n请在这个页面点击我",
            "CURE的GPS追踪已失效，\n我们应该去哪里找回TA呢？",
            "[WHereToGo]选择界面", // strs[61]
            "我在华盛顿的街头找到了CURE，\n TA正站在街边，默默地看着车水马龙。",
            "对于我的到来，\n TA似乎并不意外。",
            "Grace说旅行可以增长人的见闻。",
            "爷爷不愿意配合我的治疗，所以我想看看是不是我的方式不对。",
            "但我学着Grace走遍13个城市，似乎并没有找到答案。",

            "您可以左右拖动场景，并点击场景中的道具收集线索。\n点击我可以查看已经收集到的线索。", // strs[67] 隐藏剧情
            "（玩家点击道具：场景1_全息投影，收集线索4后触发以下对话）", // strs[68]
            "播报最近的热点新闻。", // strs[69]
            "现在为您播报今日社会头条。",
            "1、X公司第二代社区管理AI畅销推出，推出三天购买量超过5千万",
            "2、Y大学发布AI面20年来社会群像纪录片，引起广泛复古回忆杀",
            "3、著名中医传承人李毅于今晨02:45病重入院，\n曾因高超的中医技艺和强烈贬低人工智能医疗技术引起社会热议，\n据悉，老人的病重是由于医疗AI报警失误,导致送医时间延误。\n",
            "等等，这个老人好眼熟啊，请查阅李毅与我的相关性。",
            "查阅中，请稍后......李毅与您的相关性是，\n李毅是您大学同学李之一的外公，前段时间刚和您提起过李之一。",
            "请调出相关邮件。", // strs[76]
            ""
        };
        private string[] clue_strs = { @"
2050.2.28 18:00:21 开机—————————顺利
2050.2.28 18:01:00 即将进行第一次扫描——顺利
2050.2.28 18:02:00 User离开可扫描范围——第一次扫描失败
2050.2.28 18:02:10 启动初次使用排斥方案
2050.2.28 22:06:34 User进入浅层睡眠
2050.2.28 23:50:07 User进入深度睡眠
2050.2.28 23:50:10 即将进行夜间扫描
2050.2.28 23:52:28 夜间扫描完毕
扫描结果报告：预期寿命81.2岁，当前年龄80.25岁
            细胞分裂异常
            癌细胞比重异常
            血糖含量低
            其余指标皆位于临界值或接近临界值
            早年病史繁杂，疑似受过重伤未及时治疗
2050.3.1 09:18:27 向患者播送健康警报信息
2050.3.1 09:20:18 失去电力来源——即将关机
2050.3.6 18:03:00 开机——————外部命令来源
2050.3.6 18:04:01 再次播送健康警报信息
2050.3.6 18:05:17 患者情绪失控1级——原因未知
2050.3.6 18:20:18 失去电力来源——即将关机
2050.3.6 18:23:00 开机——————外部命令来源
2050.3.6 18:25:17 患者情绪失控2级——原因未知
2050.3.6 18:28:18 失去电力来源——即将关机
2050.3.7 19:18:27 开机——外部命令来源
2050.3.7 19:19:37 向患者播送治疗方案
2050.3.7 19:25:17 患者情绪失控5级——原因未知
2050.3.7 19:25:18 即将开启缓和模式——开启失败
2050.3.7 19:26:08 即将开启调整模式——开启失败
2050.3.7 19:26:08 即将开启调整模式——开启失败
2050.3.7 19:29:08 运算错误，系统故障
2050.3.9 05:17:49 关闭GPS定位功能", // clue_strs[0]
            @"随手一记：
弱人工智能的时代真的过去了，
在这个技术奇点，把旅行和医疗结合真是可爱的创新。
2044.9.10", // clue_strs[1]
            @"准则1：所有系统操作以使用者的生命健康优先。
准则2：启用任何医学检测操作时需获取患者的同意。
准则3：任何健康管理人工智能需配备定位系统。
准则4：最大程度维护患者的心理健康。
准则5：开发者需同时具备国际高级医师执照和国际人工智能开发执照。", // clue_strs[2]
            @"2050.3.7 20:29:08 东经120°54′ 北纬30°64′ 乌镇
2050.3.7 23:29:37 东经121°31′ 北纬31°02′ 嘉兴
2050.3.8 13:49:27 东经122°01′ 北纬31°30′ 上海
2050.3.9 05:00:08 东经122°31′ 北纬31°23′ 上海洋山港
2050.3.9 05:17:49 信号消失
正在尝试连接GPS信号……连接成功……
恢复部分GPS记录
……
2050.3.12 北纬42°    东经12°    罗马
2050.3.13 北纬51°30′ 东经0.1°5′  伦敦
2050.3.13 北纬42°51’ 东经2°20’   巴黎
……
信号中断" // clue_strs[3]
        };
        string[] mail_strs = {
            "发件人：Lee", // mail_strs[0]
            @"Hey,how is everything going?
还是我应该说见字如晤，hhh，这个时代也就你喜欢这种说辞了
OK, fine, 言归正传。
昨天，我去看望外公的时候发现CURE遗失了。
你记得Dr.Grace吗？我们department的天才研究员。
CURE是她研发的precision health management AI。
我记得你读博士的时候有参与CURE的项目，故有求于你。
盼复",
            "昨天发现CURE遗失后，我让我的AI assistant整理了一下\nDATA which I have recently\n附于附件中"
        };
    }
}
