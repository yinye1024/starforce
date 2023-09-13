/*----------------------------------------------------------------
// Author：隐叶
// Copyright © 2023-2030 YinYe. All rights reserved.
//===============================================================
// 功能描述：
//
//----------------------------------------------------------------*/


using System.Collections.Generic;
using DataTable;
using GameMain.Base;

namespace GameMain.Game
{
    public class PreloadMgr:Singleton<PreloadMgr>
    {
        public readonly DataTableInfo[] TableInfoList = 
        {
            new (typeof(DTAircraft),"Aircraft.txt"),
            new (typeof(DTArmor),"Armor.txt"),
            new (typeof(DTAsteroid),"Asteroid.txt"),
            new (typeof(DTEntity),"Entity.txt"),
            new (typeof(DTMusic),"Music.txt"),
            new (typeof(DTScene),"Scene.txt"),
            new (typeof(DTSound),"Sound.txt"),
            new (typeof(DTThruster),"Thruster.txt"),
            new (typeof(DTUIForm),"UIForm.txt"),
            new (typeof(DTUISound),"UISound.txt"),
            new (typeof(DTWeapon),"Weapon.txt"),
        };

        public void DoPreload()
        {
            // Preload configs
            ConfigMgr.Instance.LoadCfg("DefaultConfig.txt");
       
            // Preload data tables
            DataTableMgr.Instance.LoadData(TableInfoList);

            // Preload dictionaries
            LocalizationMgr.Instance.LoadDict("Default.xml");

            // Preload fonts
            UIMgr.Instance.LoadFont("MainFont");
        }

        public bool IsOnLoading()
        {
            if (ConfigMgr.Instance.IsOnLoading)
            {
                return true;
            }

            if (DataTableMgr.Instance.IsOnLoading)
            {
                return true;
            }
            if (LocalizationMgr.Instance.IsOnLoading)
            {
                return true;
            }
            if (UIMgr.Instance.IsOnLoading)
            {
                return true;
            }

            return false;
        }
    }
}