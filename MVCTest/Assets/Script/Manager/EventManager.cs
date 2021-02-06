using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

//事件管理器(无参)
public class EventManager : BaseManager<EventManager>
{
    //事件字典
    private Dictionary<string, UnityAction> EventDictionary = new Dictionary<string, UnityAction>();

    //监听事件
    public void AddEventListener(string eventName, UnityAction Event)
    {
        if (!EventDictionary.ContainsKey(eventName))
        {
            EventDictionary.Add(eventName, Event);
            EventDictionary[eventName]=Event;
        }
        else
            EventDictionary[eventName]+=Event;
    }

    //注销监听
    public void RemoveEventListener(string eventName, UnityAction Event)
    {
        if (!EventDictionary.ContainsKey(eventName))
        {
            Debug.Log("不存在事件于字典中");
            return;
        }
        EventDictionary[eventName]-=Event;
    }

    //事件多播
    public void InvokeEvent(string eventName)
    {
        Debug.Log("执行了事件："+eventName);
        if (!EventDictionary.ContainsKey(eventName))
        {
            Debug.Log("不存在事件于字典中");
        }
        else
            EventDictionary[eventName].Invoke();
    }

}
