﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ericson;


public class InputEvents : ESingletonMono<InputEvents> {


    public Vector3 prevMousePos = Vector3.zero;
    public delegate void MouseLClick();
    public event MouseLClick OnMouseLClick;
    public delegate void MouseRClick();
    public event MouseRClick OnMouseRClick;
    public delegate void MouseMoved();
    public event MouseMoved OnMouseMoved;
    

    private void Update()
    {
        if (GameScene.ins.gameState == GameState.paused) return;
        if(GameScene.ins.running)
        {
            Check_Game_Inputs();
        }
        Testing_Inputs();
    }
    private void Check_Game_Inputs()
    {
        if (Input.GetMouseButtonDown(0) && OnMouseLClick != null) OnMouseLClick();
        if (Input.GetMouseButtonDown(1) && OnMouseRClick != null) OnMouseRClick();
        if (Input.mousePosition != prevMousePos && OnMouseMoved != null)
        {
            OnMouseMoved();
            prevMousePos = Input.mousePosition;
        }
    }
    private void Testing_Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Scene_Manager.ins.Change_Scene(Scene.title);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Scene_Manager.ins.Change_Scene(Scene.options);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Scene_Manager.ins.Change_Scene(Scene.pregame);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Scene_Manager.ins.Change_Scene(Scene.postgame);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Scene_Manager.ins.Start_Match(0, 2);
        }
    }
    
}