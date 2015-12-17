﻿using UnityEngine;
using System.Collections;
using BeardedManStudios.Network;
namespace Lockstep
{
    public class ForgeNetworkHelperTester : BehaviourHelper
    {
        public string IP = "127.0.0.1";
        public int RoomSize = 1;


        void OnGUI () {
            if (GameManager.Instance != null && GameManager.Instance.MainNetworkHelper.IsConnected)
            {
                return;
            }
            #region Setting IP and RoomSize via GUI
            GUILayout.BeginVertical(GUILayout.Width(300f));
            GUI.color = Color.black;
            GUILayout.Label("IP: ");
            IP = GUILayout.TextField(IP);

            GUILayout.Label("Room Size");
            int.TryParse(GUILayout.TextField(RoomSize.ToString()), out RoomSize);
            #endregion

            //Below = important!
            if (GUILayout.Button("Host")) {
                //Hosting with a room size of RoomSize
                ClientManager.HostGame(RoomSize);
            }
            if (GUILayout.Button ("Connect")) {
                //Connecting to the server with ip address 'IP'
                ClientManager.ConnectGame(IP);
            }

            GUILayout.EndVertical();
        }

        void OnDisable () {
        }
    }
}