using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour,IView
{
    public Button skill_btn;
    public Button roll_btn;

    public Text playerName_txt;
    public Text playerLevel_txt;
    public Text playerDiamond_txt;
    public Text playerGold_txt;
    public Text playerPower_txt;

    public void UpdateInfo(PlayerModel data)
    {
        playerName_txt.text = data.Name.ToString();
        playerLevel_txt.text = data.Level.ToString();
        playerDiamond_txt.text = data.DiamondNum.ToString();
        playerGold_txt.text = data.GoldNum.ToString();
        playerPower_txt.text = data.Power.ToString();
    }
}
