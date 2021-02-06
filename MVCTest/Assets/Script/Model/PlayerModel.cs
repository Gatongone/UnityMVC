using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public sealed class PlayerModel
{

    //PlayerModel单例
    private static readonly Lazy<PlayerModel> _instance = new Lazy<PlayerModel>(() => new PlayerModel());

    public static PlayerModel Instance { get { return _instance.Value; } }

    private PlayerModel()
    {
        this.name = PlayerPrefs.GetString("PlayerName", "未命名");
        this.level = PlayerPrefs.GetInt("PlayerLevel", 1);
        this.diamondNum = PlayerPrefs.GetInt("PlayerDiamondNum", 10);
        this.goldNum = PlayerPrefs.GetInt("PlayerGoldNum", 5000);
        this.power = PlayerPrefs.GetInt("PlayerPower", 110);
        this.att = PlayerPrefs.GetInt("PlayerAtt", 120);
        this.def = PlayerPrefs.GetInt("PlayerDef", 30);
        this.spd = PlayerPrefs.GetInt("PlayerSpd", 60);
        this.hp = PlayerPrefs.GetInt("PlayerHp", 1200);

        EventManager.Instance.AddEventListener("update_playerData", saveData);
        EventManager.Instance.AddEventListener("LevelUp", LevelUp);
    }

    //字段数据
    private string name;
    private int level;
    private int diamondNum;
    private int goldNum;
    private int power;
    private int att;
    private int def;
    private int spd;
    private int hp;

    //属性
    public string Name { get => name; set => name = value; }
    public int Level { get => level; set => level = level > 0 ? 0 : value; }
    public int DiamondNum { get => diamondNum; set => diamondNum = diamondNum > 0 ? 0 : value; }
    public int GoldNum { get => goldNum; set => goldNum = goldNum > 0 ? 0 : value; }
    public int Power { get => power; set => power = power > 0 ? 0 : value; }
    public int Att { get => att; set => att = att > 0 ? 0 : value; }
    public int Def { get => def; set => def = def > 0 ? 0 : value; }
    public int Spd { get => spd; set => spd = spd > 0 ? 0 : value; }
    public int Hp { get => hp; set => hp = hp > 0 ? 0 : value; }

    public void saveData()
    {
        PlayerPrefs.SetString("PlayerName", this.name);
        PlayerPrefs.SetInt("PlayerLevel", this.level);
        PlayerPrefs.SetInt("PlayerDiamondNum", this.diamondNum);
        PlayerPrefs.SetInt("PlayerGoldNum", this.goldNum);
        PlayerPrefs.SetInt("PlayerPower", this.power);
        PlayerPrefs.SetInt("PlayerAtt", this.att);
        PlayerPrefs.SetInt("PlayerDef", this.def);
        PlayerPrefs.SetInt("PlayerSpd", this.spd);
        PlayerPrefs.SetInt("PlayerHp", this.hp);

    }
    private void LevelUp()
    {
        Debug.Log("升级了");

        this.level += 1;
        this.power = 100;
        this.att += level * 7;
        this.def += level * 3;
        this.spd += level * 2;
        this.hp += level * level;

        EventManager.Instance.InvokeEvent("update_playerData");
    }
    
}
