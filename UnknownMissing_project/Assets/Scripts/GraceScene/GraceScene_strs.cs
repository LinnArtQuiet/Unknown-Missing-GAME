using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

namespace app{
public partial class GraceScene : MonoBehaviour
{
    private string[] strs = {
        "欢迎光临，您不是该住宅的住户，请问您需要拜访的人是？",
        "Grace。",
        "住户识别成功，您在可拜访的名单上，但住户主人不在住处，\n请问是否接受人工智能接待。",
        "接受。", // strs[3]
        "好的，欢迎光临，我是Grace的工作助理Skeletons，\n Grace有事外出，由我来接待你，该处为您可以访问的房间，\n你可以在实验室里面查找一些资料，但请不要离开我的视线范围。",
        "您可以左右拖动场景，并点击场景中的道具收集线索。\n点击我可以查看已经收集到的线索或预约无人驾驶系统返回工作室。"
    };
        private string[] clue_strs = {
            @"2045年旅行计划：
雅典、孟买、西安、罗马、波尔图、
巴塞罗那、鹿特丹、伯明翰、马赛、
汉堡、大阪、圣彼得堡、纽约",
            @"随手一记：
现在市面上的医疗管理AI都太机械了，
无法在心灵上与人类有很好的交流。
或许可以试试让我研发的机器人跟我一起去旅行，
再导入一些人文风情的数据进行训练，
会不会有不一样的效果产生呢？",
            @"《大国崛起》是一部历史题材的纪录片，
            于2006年11月13日在中央电视台财经频道首播。
该片记录了葡萄牙、西班牙、荷兰、英国、法国、德国、
日本、俄罗斯、美国，九个国家相继崛起的过程，
并总结了国家崛起的历史规律。",
            @"…
第5章 希腊—罗马的文明
第6章 印度文明
第7章 中国文明
…
第22章 西欧的扩张：伊比利亚阶段，1500—1600年
第23章 西欧的扩张：荷兰、法国、英国阶段，1600—1763年
第24章 俄国在亚洲的扩张
…
第31章 中国和日本
第32章 非洲
…"
        };
    }
}