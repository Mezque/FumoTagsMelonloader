using System;
using System.Collections;
using System.Net;
using UnityEngine;
using VRC;
using VRC.Core;

namespace FumoTagsMelonLoader.Modules
{
    internal class CustomTags
    {
        public static IEnumerator TagListNetworkManager()
        {
            String[] Match = { "|" };
            String[] newline = { "\n" };
            WebClient client = new WebClient();
            string DevList = client.DownloadString("https://raw.githubusercontent.com/FumoClient/Trolly/main/R-ID-DL");
            string LDB = client.DownloadString("https://raw.githubusercontent.com/FumoClient/Trolly/main/R-ID-UL");
            String[] DevDB = DevList.Split(newline, StringSplitOptions.RemoveEmptyEntries);
            String[] DataBase = LDB.Split(newline, StringSplitOptions.RemoveEmptyEntries);
            while (APIUser.CurrentUser == null)
            {
                yield return null;
            }
            while (NetworkManager.field_Internal_Static_NetworkManager_0 == null)
            {
                yield return null;
            }
            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0.field_Private_HashSet_1_UnityAction_1_T_0.Add(new Action<Player>(RemotePlayer =>
            {
                foreach (var User in DataBase)
                {
                    if (User.Contains(UserProtections.SHA256(RemotePlayer.prop_APIUser_0.id)))
                    {
                        var FumoTag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                        FumoTag.name = "FumoClientUserTag";
                        var CTagTM = FumoTag.GetComponent<TMPro.TextMeshProUGUI>();
                        CTagTM.color = Color.white;
                        CTagTM.text = $"<color=#D0B3FF>Fumo User</color>";
                        String[] TagP = User.Split(Match, StringSplitOptions.RemoveEmptyEntries);
                        if (TagP.Length == 3)
                        {
                            var Tag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                            Tag.name = "FumoUserTag";
                            var TagTM = Tag.GetComponent<TMPro.TextMeshProUGUI>();
                            TagTM.color = Color.white;
                            TagTM.text = $"<color={UserProtections.DecodeBase64(TagP.GetValue(2).ToString())}>{UserProtections.DecodeBase64(TagP.GetValue(1).ToString())}</color>";
                        }
                    }
                }

                foreach (var User in DevDB)
                {
                    if (User.Contains(UserProtections.SHA256(RemotePlayer.prop_APIUser_0.id)))
                    {
                        var CTag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                        CTag.name = "FumoStaffTag";
                        var CTagTM = CTag.GetComponent<TMPro.TextMeshProUGUI>();
                        CTagTM.color = Color.white;
                        CTagTM.text = $"<color=#D0B3FF>Fumo Staff</color>";
                        String[] TagP = User.Split(Match, StringSplitOptions.RemoveEmptyEntries);
                        if (TagP.Length == 3)
                        {
                            var Tag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                            Tag.name = "FumoUserTag";
                            var TagTM = Tag.GetComponent<TMPro.TextMeshProUGUI>();
                            TagTM.color = Color.white;
                            TagTM.text = $"<color={UserProtections.DecodeBase64(TagP.GetValue(2).ToString())}>{UserProtections.DecodeBase64(TagP.GetValue(1).ToString())}</color>";
                        }
                    }
                }
                if (RemotePlayer.prop_APIUser_0.hasModerationPowers)
                {
                    var FCModTag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                    FCModTag.name = "FumoModTag";
                    var TagTM = FCModTag.GetComponent<TMPro.TextMeshProUGUI>();
                    TagTM.color = Color.white;
                    TagTM.text = "<color=red>VRChat Staff</color>";
                }
                if (RemotePlayer.prop_VRCPlayerApi_0.isMaster)
                {
                    var FCMasterTag = GameObject.Instantiate(RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats/Trust Text"), RemotePlayer.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Quick Stats"));
                    FCMasterTag.name = "FumoMasterTag";
                    var TagTM = FCMasterTag.GetComponent<TMPro.TextMeshProUGUI>();
                    TagTM.color = Color.white;
                    TagTM.text = "<color=yellow>Master</color>";
                }
            }));
        }
    }
}
