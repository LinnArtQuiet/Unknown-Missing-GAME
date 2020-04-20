using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FairyGUI;
using System;
using System.Runtime.InteropServices;
// 最开始的初始界面
public class MainScene : MonoBehaviour
{
    [DllImport("User32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
    public static extern int MessageBox(IntPtr handle, String message, String title, int type);//具体方法

    public AudioSource music;
    public AudioSource sound;
    public AudioClip bgm_wav;
    public AudioClip click_wav;
    void Start()
    {
        music = gameObject.AddComponent<AudioSource>();
        sound = gameObject.AddComponent<AudioSource>();
        bgm_wav = Resources.Load<AudioClip>("music/MainScene");
        click_wav = Resources.Load<AudioClip>("music/Click");
        music.clip = bgm_wav;
        music.loop = true;
        music.Play();
        
        UIPanel panel = gameObject.GetComponent<UIPanel>();
        GComponent view = panel.ui;
        GButton button = view.GetChild("StartButton").asButton;
        button.onClick.Add(OnClick);
    }

    void OnClick(){
        music.clip = click_wav;
        music.Play();
        PlayerPrefs.SetInt("isClueUse", 0); 
        PlayerPrefs.SetInt("isClueGPS", 0); 
        PlayerPrefs.SetInt("isClueShelf", 0); 
        PlayerPrefs.SetInt("isCluePicture", 0); 

        PlayerPrefs.SetInt("isClueMap", 0); // 回不回信的那个按钮的显示
        PlayerPrefs.SetInt("isClueBrain", 0); // 回不回信的那个按钮的显示
        PlayerPrefs.SetInt("isClueBall", 0); // 回不回信的那个按钮的显示
        PlayerPrefs.SetInt("isClueDesk", 0); // 回不回信的那个按钮的显示

        PlayerPrefs.SetInt("isBackMail", 1); // 回不回信的那个按钮的显示
        PlayerPrefs.SetInt("m_i", 0);
        SceneManager.LoadScene("SubtitleScene");
    }

    public void OnCloseGame()
    {
        int returnNumber = MessageBox(IntPtr.Zero, "是否退出？", "UnknownMissing", 1);
        if(returnNumber == 1){
            Application.Quit();  
        }
    }

}
