﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;
using EloBuddy.SDK;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RoninNauti
{
    internal class Menus
    {
        public const string ComboMenuID = "combomenuid";
        public const string UltimateID = "ultimateid";
        //public const string HarassMenuID = "harassmenuid";
        //public const string AutoHarassMenuID = "autoharassmenuid";
        public const string LaneClearMenuID = "laneclearmenuid";
        //public const string LastHitMenuID = "lasthitmenuid";
        public const string JungleClearMenuID = "jungleclearmenuid";
        public const string KillStealMenuID = "killstealmenuid";
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;
        public static Menu ComboMenu;
        public static Menu UltimateMenu;
        public static Menu HarassMenu;
        public static Menu AutoHarassMenu;
        public static Menu LaneClearMenu;
        public static Menu LasthitMenu;
        public static Menu JungleClearMenu;
        //public static Menu KillStealMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;
        //These colorslider are from Mario`s Lib
        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("Ronin`s " + Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "hue");
            ComboMenu = FirstMenu.AddSubMenu("• Combo", ComboMenuID);
            UltimateMenu = FirstMenu.AddSubMenu("• Ultimate", UltimateID);
            //HarassMenu = FirstMenu.AddSubMenu("• Harass", HarassMenuID);
            //AutoHarassMenu = FirstMenu.AddSubMenu("• AutoHarass", AutoHarassMenuID);
            LaneClearMenu = FirstMenu.AddSubMenu("• LaneClear", LaneClearMenuID);
            //LasthitMenu = FirstMenu.AddSubMenu("• LastHit", LastHitMenuID);
            JungleClearMenu = FirstMenu.AddSubMenu("• JungleClear", JungleClearMenuID);
            //KillStealMenu = FirstMenu.AddSubMenu("• KillSteal", KillStealMenuID);
            MiscMenu = FirstMenu.AddSubMenu("• Misc", MiscMenuID);
            DrawingsMenu = FirstMenu.AddSubMenu("• Drawings", DrawingsMenuID);

            ComboMenu.AddGroupLabel("Combo");
            ComboMenu.AddGroupLabel("ONLY USE ON COMBO");
            ComboMenu.AddSeparator(15);
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            ComboMenu.AddLabel("ComboLogics");
            ComboMenu.CreateCheckBox("Normal", "One", true);
            ComboMenu.AddGroupLabel("Combo Q - E - W - R");
            ComboMenu.AddSeparator(15);
            ComboMenu.CreateCheckBox("Extend", "Two", false);
            ComboMenu.AddGroupLabel("Combo W - E - Q - R");
            ComboMenu.AddSeparator(15);
            ComboMenu.CreateCheckBox(" - Use Q", "qUse");
            ComboMenu.CreateCheckBox(" - Use W", "wUse");
            ComboMenu.CreateCheckBox(" - Use E", "eUse");
            ComboMenu.CreateCheckBox(" - Use R", "rUse");
            ComboMenu.Add("hitChanceQ", new Slider("Hitchance for Q", 2, 1, 3));
            ComboMenu.Add("hptoult", new Slider("Min %HP to use R", 50, 0, 100));
            ComboMenu.AddSeparator();
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            ComboMenu.AddGroupLabel("Pro Tips");
            ComboMenu.AddLabel(" -Uncheck the boxes if you wish to dont use a specific spell while you are pressing the Combo Key");

            UltimateMenu.AddGroupLabel("Ultimate Menu");
            UltimateMenu.AddSeparator();
            UltimateMenu.AddLabel("Use ultimate on");
            foreach (var enemies in EntityManager.Heroes.Enemies.Where(i => !i.IsMe))
            {
                UltimateMenu.Add("r.ult" + enemies.ChampionName, new CheckBox("" + enemies.ChampionName, false));
            }
            UltimateMenu.Add("manu.ult", new CheckBox("Use R Manual", false));

            //HarassMenu.AddGroupLabel("Harass");
            //HarassMenu.CreateCheckBox(" - Use Q", "qUse");
            //HarassMenu.CreateCheckBox(" - Use W", "wUse");
            //HarassMenu.CreateCheckBox(" - Use E", "eUse");
            //HarassMenu.CreateCheckBox(" - Use R", "rUse");
            //HarassMenu.AddGroupLabel("Settings");
            //HarassMenu.CreateSlider("Mana must be lower than [{0}%] to use Harass spells", "manaSlider", 30);

            //AutoHarassMenu.AddGroupLabel("AutoHarass");
            //AutoHarassMenu.CreateCheckBox(" - Use Q", "qUse");
            //AutoHarassMenu.CreateCheckBox(" - Use W", "wUse");
            //AutoHarassMenu.CreateCheckBox(" - Use E", "eUse");
            //AutoHarassMenu.CreateCheckBox(" - Use R", "rUse");
            //AutoHarassMenu.AddGroupLabel("Settings");
            //AutoHarassMenu.CreateKeyBind("Enable/Disable AutoHrass", "autoHarassKey", 'Z', 'U');
            //AutoHarassMenu.CreateSlider("Mana must be lower than [{0}%] to use AutoHarass spells", "manaSlider", 30);

            LaneClearMenu.AddGroupLabel("LaneClear");
            LaneClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            LaneClearMenu.CreateCheckBox(" - Use E", "eUse");
            LaneClearMenu.Add("lc.MinionsE", new Slider("Min. Minions for E ", 3, 0, 10));
            LaneClearMenu.AddGroupLabel("Settings");
            LaneClearMenu.CreateSlider("Mana must be lower than [{0}%] to use LaneClear spells", "manaSlider", 30);
            LaneClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            //LasthitMenu.AddGroupLabel("Lasthit");
            //LasthitMenu.CreateCheckBox(" - Use Q", "qUse");
            //LasthitMenu.CreateCheckBox(" - Use W", "wUse");
            //LasthitMenu.CreateCheckBox(" - Use E", "eUse");
            //LasthitMenu.CreateCheckBox(" - Use R", "rUse");
            //LasthitMenu.AddGroupLabel("Settings");
            //LasthitMenu.CreateSlider("Mana must be lower than [{0}%] to use LastHit spells", "manaSlider", 30);

            JungleClearMenu.AddGroupLabel("JungleClear");
            JungleClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            JungleClearMenu.CreateCheckBox(" - Use Q", "qUse");
            JungleClearMenu.CreateCheckBox(" - Use W", "wUse");
            JungleClearMenu.CreateCheckBox(" - Use E", "eUse");
            JungleClearMenu.AddGroupLabel("Settings");
            JungleClearMenu.CreateSlider("Mana must be lower than [{0}%] to use JungleClear spells", "manaSlider", 30);
            JungleClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");

            //KillStealMenu.AddGroupLabel("KilLSteal");
            //KillStealMenu.CreateCheckBox(" - Use Q", "qUse");
            //KillStealMenu.CreateCheckBox(" - Use W", "wUse");
            //KillStealMenu.CreateCheckBox(" - Use E", "eUse");
            //KillStealMenu.CreateCheckBox(" - Use R", "rUse");
            //KillStealMenu.AddGroupLabel("Settings");
            //KillStealMenu.CreateSlider("Mana must be lower than [{0}%] to use Killsteal spells", "manaSlider", 30);

            MiscMenu.AddGroupLabel("Skin Changer");
            
            var skinList = Mario_s_Lib.DataBases.Skins.SkinsDB.FirstOrDefault(list => list.Champ == Player.Instance.Hero);
            if (skinList != null)
            {
                MiscMenu.CreateComboBox("Choose the skin", "skinComboBox", skinList.Skins);
                MiscMenu.Get<ComboBox>("skinComboBox").OnValueChange += delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                {
                    Player.Instance.SetSkinId(sender.CurrentValue);
                };
            }

            MiscMenu.AddGroupLabel("Interrupter settings");
            MiscMenu.Add("interruptq", new CheckBox("Use Q Spell to Interrupt"));
            MiscMenu.Add("interruptr", new CheckBox("Use R Spell to Interrupt", false));
            MiscMenu.AddSeparator();
            MiscMenu.AddGroupLabel("Auto Level UP");
            MiscMenu.CreateCheckBox("Activate Auto Leveler", "activateAutoLVL", false);
            MiscMenu.AddLabel("The auto leveler will always focus R than the rest of the spells");
            MiscMenu.CreateComboBox("1st Spell to focus", "firstFocus", new List<string> {"Q", "W", "E"});
            MiscMenu.CreateComboBox("2nd Spell to focus", "secondFocus", new List<string> {"Q", "W", "E"}, 1);
            MiscMenu.CreateComboBox("3rd Spell to focus", "thirdFocus", new List<string> {"Q", "W", "E"}, 2);
            MiscMenu.CreateSlider("Delay slider", "delaySlider", 200, 150, 500);

            DrawingsMenu.AddGroupLabel("Settings");
            DrawingsMenu.CreateCheckBox(" - Draw Spell`s range only if they are ready.", "readyDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator.", "damageDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator percent.", "perDraw");
            DrawingsMenu.CreateCheckBox(" - Draw damage indicator statistics.", "statDraw", false);
            DrawingsMenu.AddGroupLabel("Spells");
            DrawingsMenu.CreateCheckBox(" - Draw Q.", "qDraw");
            DrawingsMenu.CreateCheckBox(" - Draw W.", "wDraw");
            DrawingsMenu.CreateCheckBox(" - Draw E.", "eDraw");
            DrawingsMenu.CreateCheckBox(" - Draw R.", "rDraw");
            DrawingsMenu.AddGroupLabel("Drawings Color");
            QColorSlide = new ColorSlide(DrawingsMenu, "qColor", Color.Red, "Q Color:");
            WColorSlide = new ColorSlide(DrawingsMenu, "wColor", Color.Purple, "W Color:");
            EColorSlide = new ColorSlide(DrawingsMenu, "eColor", Color.Orange, "E Color:");
            RColorSlide = new ColorSlide(DrawingsMenu, "rColor", Color.DeepPink, "R Color:");
            DamageIndicatorColorSlide = new ColorSlide(DrawingsMenu, "healthColor", Color.YellowGreen, "DamageIndicator Color:");
        }
        public static int HitchanceQ
        {
            get { return ComboMenu["hitchanceQ"].Cast<Slider>().CurrentValue; }
        }
        public static bool interruptq()
        {
            return MiscMenu["interruptq"].Cast<CheckBox>().CurrentValue;
        }
        public static bool interruptr()
        {
            return MiscMenu["interruptr"].Cast<CheckBox>().CurrentValue;
        }
        public static float minQaggresive()
        {
            return MiscMenu["combo.QminAG"].Cast<Slider>().CurrentValue;
        }
        public static float minQcombo()
        {
            return MiscMenu["combo.Qmin"].Cast<Slider>().CurrentValue;
        }
        public static int rLogicMinHp()
        {
            return ComboMenu["rlogic.minhp"].Cast<Slider>().CurrentValue;
        }
        public static int rLogicEnemyMinHp()
        {
            return ComboMenu["rlogic.ehp"].Cast<Slider>().CurrentValue;
        }

    }
}