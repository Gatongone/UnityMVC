using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoleView : MonoBehaviour,IView
{
    public Button close_btn;
    public Button levelUp_btn;
    public Text playerLevel_txt;
    public Text playerAtt_txt;
    public Text playerDef_txt;
    public Text playerSpd_txt;
    public Text playerHp_txt;

    public void UpdateInfo(PlayerModel data)
    {
        playerLevel_txt.text = data.Level.ToString();
        playerAtt_txt.text = data.Att.ToString();
        playerDef_txt.text = data.Def.ToString();
        playerSpd_txt.text = data.Spd.ToString();
        playerHp_txt.text = data.Hp.ToString();
    }
}
