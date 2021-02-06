using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleController : BaseController<RoleController, RoleView>
{
    private void Start()
    {
        base.Start();
        //关闭按钮事件
        view.close_btn.onClick.AddListener(() =>
        {
            RoleController.Destroy();
        });
        //升级按钮事件
        view.levelUp_btn.onClick.AddListener(() =>
        {
            EventManager.Instance.InvokeEvent("LevelUp");
        });
    }
}
