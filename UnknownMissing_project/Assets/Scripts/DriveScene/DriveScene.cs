using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
namespace app{
public partial class HomeScene : MonoBehaviour
{
    void Start() // 主要用来完成初始化和控件获得
    {
        initUI();
        isActive = true; // 开始动画
        Debug.Log("start!");
    }
    void Update()
    {
        
    }
}
}