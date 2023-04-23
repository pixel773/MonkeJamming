using BepInEx;
using System;
using UnityEngine;
using Utilla;
using HoneyLib.Utils;

namespace MonkeJamming
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.7")]
    [BepInDependency("com.buzzbzzzbzzbzzzthe18th.gorillatag.HoneyLib")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        GameObject city;
        GameObject forest;
        GameObject cave;
        GameObject Mountains;
        GameObject SkyJungle;
        GameObject Basement;

        void Start()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            city = GameObject.Find("city");
            forest = GameObject.Find("forest");
            SkyJungle = GameObject.Find("skyjungle");
            Mountains = GameObject.Find("mountain");
            cave = GameObject.Find("cave");
            Basement = GameObject.Find("DungeonBasement");
        }

        void FixedUpdate()
        {
            EasyInput.UpdateInput();

            if (EasyInput.RightStickClick)
            {
                if (cave.activeSelf == true) GameObject.Find("SoundPostCave").GetComponent<SynchedMusicController>().testPlay = true;
                if (city.activeSelf == true) GameObject.Find("SoundPostCity").GetComponent<SynchedMusicController>().testPlay = true;
                if (forest.activeSelf == true) GameObject.Find("SoundPostForest").GetComponent<SynchedMusicController>().testPlay = true;
                if (SkyJungle.activeSelf == true) GameObject.Find("SoundPostClouds").GetComponent<SynchedMusicController>().testPlay = true;
                if (Mountains.activeSelf == true) GameObject.Find("SoundPostMountain").GetComponent<SynchedMusicController>().testPlay = true;
                if (Basement.activeSelf == true) GameObject.Find("BasementMusicSpeaker").GetComponent<SynchedMusicController>().testPlay = true;
            }
        }
        
    }
}
