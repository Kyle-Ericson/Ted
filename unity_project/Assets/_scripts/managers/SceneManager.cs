﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ericson;

public class SceneManager : eSingletonMono<SceneManager> {



    public bool isOptionsOpen = false;

    void Start ()
    {
        Init();
	}
    public override void Init()
    {
        InputEvents.ins.Init();
        SoundManager.ins.Init();
        InitializeScenes();
        ToTitle();
    }
    void InitializeScenes()
    {
        GameScene.ins.Init();
        TitleScene.ins.Init();
        PregameScene.ins.Init();
        PostgameScene.ins.Init();
        OptionsScene.ins.Init();
        SocketManager.ins.Init();
        LobbyScene.ins.Init();
        TransitionScene.ins.Init();
        SetParents();
    }
    void SetParents()
    {
        GameScene.ins.gameObject.transform.SetParent(this.gameObject.transform);
        TitleScene.ins.gameObject.transform.SetParent(this.gameObject.transform);
        PregameScene.ins.gameObject.transform.SetParent(this.gameObject.transform);
        PostgameScene.ins.gameObject.transform.SetParent(this.gameObject.transform);
        OptionsScene.ins.gameObject.transform.SetParent(this.gameObject.transform);
        LobbyScene.ins.gameObject.transform.SetParent(this.gameObject.transform);
        TransitionScene.ins.gameObject.transform.SetParent(this.gameObject.transform);
    }
    public void ToTitle()
    {
        HideAll();
        TitleScene.ins.Show();
        SoundManager.ins.PlayTitleMusic();
        PersistentSettings.gameKey = "";
        PersistentSettings.gameMode = GameMode.local;
    }
    public void ToPost()
    {
        HideAll();
        PostgameScene.ins.Show();
        PostgameScene.ins.UpdateAll();
    }
    public void ToPregame()
    {
        HideAll();
        PregameScene.ins.Show();
        PregameScene.ins.maplist.buttons[0].onClick.Invoke();
    }
    public void ToLobby()
    {
        HideAll();
        PersistentSettings.gameMode = GameMode.online;
        LobbyScene.ins.Show();
    }
    public void ToWait()
    {
        HideAll();
        TransitionScene.ins.Show();
        TransitionScene.ins.SetText("Game Key: " + PersistentSettings.gameKey +"\nWaiting for another player...");
    }
    public void HideAll()
    {
        GameScene.ins.Hide();
        TitleScene.ins.Hide();
        PregameScene.ins.Hide();
        OptionsScene.ins.Hide();
        isOptionsOpen = false;
        PostgameScene.ins.Hide();
        LobbyScene.ins.Hide();
        TransitionScene.ins.Hide();
    }
    public void StartMatch(int map)
    {
        HideAll();
        GameScene.ins.Show();
        GameScene.ins.SetupMatch(map);
        SoundManager.ins.PlayGameMusic();
    }
    
    public void ToggleOptions()
    {
        isOptionsOpen = !isOptionsOpen;
        OptionsScene.ins.gameObject.SetActive(isOptionsOpen);
    }
}