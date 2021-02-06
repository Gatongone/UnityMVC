using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MainController : BaseController<MainController, MainView>
{
    void Start()
    {
        base.Start();
        //技能按钮
        view.skill_btn.onClick.AddListener(() => { });
        
        //视图按钮
        view.roll_btn.onClick.AddListener(ShowRoll);
    }
    private void ShowRoll()
    {
        RoleController.Init("UI/RolePanel","Canvas");
        RoleController.ShowView();
    }
}
