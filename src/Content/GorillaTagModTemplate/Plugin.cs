using System;
using System.Reflection;
using BepInEx;
using UnityEngine;

namespace GorillaTagModTemplateProject
{
	[BepInPlugin("AuthorLowerName.GorillaTagLowerModTemplateProject", "GorillaTagModTemplateProject", "1.0.0")]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
        public const string InstanceId = PluginInfo.GUID;

        void Start()
		{
            var harmony = Harmony.CreateAndPatchAll(GetType().Assembly, "AuthorLowerName.GorillaTagLowerModTemplateProject");
            GorillaTagger.OnPlayerSpawned(OnGameInitialized);
		}

		void OnGameInitialized()
		{

		}

		void Update()
		{
			if (NetworkSystem.Instance.InRoom && NetworkSystem.Instance.GameModeString.Contains("MODDED"))
			{
				if (!inRoom)
				{
					inRoom = true;
				}
			}
			else
			{
                if (inRoom)
                {
                    inRoom = false;
                }
            }
		}
	}
}