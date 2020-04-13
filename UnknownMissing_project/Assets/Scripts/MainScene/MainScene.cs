using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FairyGUI;
// 最开始的初始界面
public class MainScene : MonoBehaviour
{
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
        SceneManager.LoadScene("SubtitleScene");
    }
 
}
