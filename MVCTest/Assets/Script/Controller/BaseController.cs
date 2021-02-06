using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class BaseController<Controller, View> : MonoBehaviour
where Controller : BaseController<Controller, View>,new()
where View : IView, new()
{
    //单例
    private static volatile Controller instance;
    private static object initLock = new object();

    public static Controller Instance
    {
        get
        {
            if (instance == null)
            {
                throw new ArgumentNullException($"未初始化{nameof(Controller)}控制器");
            }
            else
                return instance;
        }
    }

    public static void Init(string ResourcePath, string CanvasName)
    {
        if (instance == null)
        {
            lock (initLock)
            {
                if (instance == null)
                {
                    //从预制体中加载
                    GameObject res = Resources.Load(ResourcePath) as GameObject;
                    GameObject obj = Instantiate(res);

                    //设置画布为父对象
                    obj.transform.SetParent(GameObject.Find(CanvasName).transform, false);

                    //加载到场景中的资源生成控制器
                    instance = obj.GetComponent<Controller>();
                }
            }
        }
    }

    protected View view;//需要被匹配的View

    //匹配View
    protected virtual void Start()
    {
        //视图更新监听玩家数据更新事件
        EventManager.Instance.AddEventListener("update_playerData", UpdateView);
        
        view = transform.gameObject.GetComponent<View>();
        view?.UpdateInfo(PlayerModel.Instance);
    }

    //视图显示否
    public static void ShowView()
    {
        instance?.gameObject.SetActive(true);
    }
    public static void HideView()
    {
        instance?.gameObject.SetActive(false);
    }
    //销毁UI
    public static void Destroy()
    {
        EventManager.Instance.RemoveEventListener("update_playerData", instance.UpdateView);
        Destroy(instance?.gameObject);
    }
    //更新视图——根据玩家数据
    protected virtual void UpdateView()
    {
        instance?.view.UpdateInfo(PlayerModel.Instance);
    }
}
