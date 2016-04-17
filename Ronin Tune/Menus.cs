﻿using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using Mario_s_Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace RoninTune
{
    internal class Menus
    {
        public const string ComboMenuID = "combomenuid";
        public const string HarassMenuID = "harassmenuid";
        public const string AutoHarassMenuID = "autoharassmenuid";
        public const string LaneClearMenuID = "laneclearmenuid";
        public const string LastHitMenuID = "lasthitmenuid";
        public const string JungleClearMenuID = "jungleclearmenuid";
        public const string KillStealMenuID = "killstealmenuid";
        public const string DrawingsMenuID = "drawingsmenuid";
        public const string MiscMenuID = "miscmenuid";
        public static Menu FirstMenu;

        public static bool SmiteToggle
        {
            get { return _smiteToggle.CurrentValue; }
        }

        public static bool SmiteEnemies
        {
            get { return _smiteEnemies.CurrentValue; }
        }

        public static bool SmiteCombo
        {
            get { return _smiteCombo.CurrentValue; }
        }

        public static int RedSmitePercent
        {
            get { return _redSmitePercent.CurrentValue; }
        }
        // --------------------------------------------------------------COMBO LOGICS-------------------------------------------------------------- //
        //public static readonly string[] AvailableModes =
        //{
        //        "Combo R - W - E - Q",
        //        "Combo R - E - Q - W",
        //        "Gank Combo",
        //        "Combo - without Ultimate",
        //};
        //private static readonly KeyBind _enabled;
        //private static readonly KeyBind _Extra0Key;
        //public static bool Enabled
        //{
        //    get { return _enabled.CurrentValue; }
        //}
        //public static int CurrentMode
        //{
        //    get { return _mode.CurrentValue; }
        //}
        //public static KeyBind FlashKey
        //{
        //    get { return _Extra0Key; }
        //}
        // --------------------------------------------------------------COMBO LOGICS-------------------------------------------------------------- //

        public static Menu ComboMenu;
        public static Menu HarassMenu;
        public static Menu AutoHarassMenu;
        public static Menu LaneClearMenu;
        public static Menu LasthitMenu;
        public static Menu JungleClearMenu;
        public static Menu KillStealMenu;
        public static Menu DrawingsMenu;
        public static Menu MiscMenu;
        public static readonly KeyBind _smiteEnemies;
        public static readonly KeyBind _smiteCombo;
        private static readonly KeyBind _smiteToggle;
        private static readonly Slider _redSmitePercent;
        public static ColorSlide QColorSlide;
        public static ColorSlide WColorSlide;
        public static ColorSlide EColorSlide;
        public static ColorSlide RColorSlide;
        public static ColorSlide DamageIndicatorColorSlide;

        public static void CreateMenu()
        {
            FirstMenu = MainMenu.AddMenu("Ronin " + Player.Instance.ChampionName, Player.Instance.ChampionName.ToLower() + "hue");
            ComboMenu = FirstMenu.AddSubMenu("♠ Combo", ComboMenuID);
            HarassMenu = FirstMenu.AddSubMenu("♠ Harass", HarassMenuID);
            AutoHarassMenu = FirstMenu.AddSubMenu("♠ AutoHarass", AutoHarassMenuID);
            LaneClearMenu = FirstMenu.AddSubMenu("♠ LaneClear", LaneClearMenuID);
            //LasthitMenu = FirstMenu.AddSubMenu("♠ LastHit", LastHitMenuID);
            JungleClearMenu = FirstMenu.AddSubMenu("♠ JungleClear", JungleClearMenuID);
            KillStealMenu = FirstMenu.AddSubMenu("♠ KillSteal", KillStealMenuID);
            MiscMenu = FirstMenu.AddSubMenu("♠ Misc", MiscMenuID);
            DrawingsMenu = FirstMenu.AddSubMenu("♠ Drawings", DrawingsMenuID);
 

             ComboMenu.AddGroupLabel("ComboMenu");
             ComboMenu.AddGroupLabel("ONLY USE ON COMBO");
            ComboMenu.AddSeparator(15);
            // --------------------------------------------------------------COMBO LOGICS-------------------------------------------------------------- //
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            ///ComboMenu.CreateComboBox("Choose your Logic", "Logics", new List<string> { "Normal", "Normal 2", "Gank" });
            //ComboMenu.Add("ComboLogics", new ComboBox("Choose your Logics", 0, "1 - [ComboOne]", "2 - [ComboTwo]", "3 - [GankCombo]"));
            ComboMenu.AddLabel("ComboLogics");
            ComboMenu.CreateCheckBox("Normal", "cOne", false);
            ComboMenu.AddGroupLabel("Combo R - W - E - Q");
            ComboMenu.AddSeparator(15);
            ComboMenu.CreateCheckBox("Combo Two", "cTwo", false);
            ComboMenu.AddGroupLabel("Combo R - E - W - Q");
            ComboMenu.AddSeparator(15);
            ComboMenu.CreateCheckBox("Combo Three", "cThree", true);
            ComboMenu.AddGroupLabel("Combo R - Q - E");
            ComboMenu.AddSeparator(15);
            //ComboMenu.CreateCheckBox("Gank Combo", "gThree");
            //ComboMenu.AddSeparator(15);
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            ComboMenu.CreateCheckBox(" - Use Q", "qUse");
            ComboMenu.CreateCheckBox(" - Use W", "wUse");
            ComboMenu.CreateCheckBox(" - Use E", "eUse");
            ComboMenu.CreateCheckBox(" - Use R", "rUse");
            ComboMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            // --------------------------------------------------------------COMBO LOGICS-------------------------------------------------------------- //

            HarassMenu.AddGroupLabel("HarassMenu");
            HarassMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            HarassMenu.CreateCheckBox(" - Use Q", "qUse", true);
            HarassMenu.CreateCheckBox(" - Use W", "wUse");
            HarassMenu.CreateCheckBox(" - Use E", "eUse");
            HarassMenu.AddGroupLabel("Settings");
            HarassMenu.CreateSlider("Mana must be higher than [{0}%] to use Harass spells", "manaSlider", 30);
            HarassMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            HarassMenu.AddSeparator();

            AutoHarassMenu.AddGroupLabel("AutoHarass");
            AutoHarassMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            AutoHarassMenu.CreateCheckBox(" - Use Q", "qUse");
            AutoHarassMenu.CreateCheckBox(" - Use E", "eUse");
            AutoHarassMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            AutoHarassMenu.AddGroupLabel("Settings");
            AutoHarassMenu.CreateKeyBind("Enable/Disable AutoHarass", "autoHarassKey", 'Z', 'U');
            AutoHarassMenu.CreateSlider("Mana must be lower than [{0}%] to use AutoHarass spells", "manaSlider", 80);

            LaneClearMenu.AddGroupLabel("LaneClear");
            LaneClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            LaneClearMenu.CreateCheckBox(" - Use Q", "qUse");
            LaneClearMenu.CreateCheckBox(" - Use E", "eUse", false);
            LaneClearMenu.AddGroupLabel("Settings");
            LaneClearMenu.CreateSlider("Mana must be higher than [{0}%] to use LaneClear spells", "manaSlider", 30);
            LaneClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            LaneClearMenu.AddSeparator();

            //LasthitMenu.AddGroupLabel("LastHit");
            //LasthitMenu.CreateCheckBox(" - Use Q", "qUse");
            //LasthitMenu.CreateCheckBox(" - Use W", "wUse");
            //LasthitMenu.CreateCheckBox(" - Use E", "eUse");
            //LasthitMenu.CreateCheckBox(" - Use R", "rUse");
            //LasthitMenu.AddGroupLabel("Settings");
            //LasthitMenu.CreateSlider("Mana must be lower than [{0}%] to use LastHit spells", "manaSlider", 30);
            //LasthitMenu.AddSeparator();

            JungleClearMenu.AddGroupLabel("JungleClear");
            JungleClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            JungleClearMenu.CreateCheckBox(" - Use Q", "qUse");
            JungleClearMenu.CreateCheckBox(" - Use W", "wUse", false);
            JungleClearMenu.CreateCheckBox(" - Use E", "eUse");
            JungleClearMenu.AddGroupLabel("Settings");
            JungleClearMenu.CreateSlider("Mana must be higher than [{0}%] to use JungleClear spells", "manaSlider", 30);
            JungleClearMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            JungleClearMenu.AddSeparator();

            KillStealMenu.AddGroupLabel("KS Farm");
            KillStealMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            KillStealMenu.CreateCheckBox(" - Use Q", "qUse", true);
            KillStealMenu.CreateCheckBox(" - Use E", "eUse", true);
            KillStealMenu.CreateCheckBox(" - Use R", "rUse", false);
            KillStealMenu.Add("sm", new CheckBox("Use Smite to killsteal"));
            KillStealMenu.AddGroupLabel("Settings");
            KillStealMenu.CreateSlider("Mana must be higher than [{0}%] to use Killsteal spells", "manaSlider", 30);
            KillStealMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            KillStealMenu.AddSeparator();

            //MiscMenu.AddLabel("Ignite");
            //MiscMenu.Add("ig", new CheckBox("Use Ignite"));

            //MiscMenu.AddLabel("Smite");
            //MiscMenu.Add("smcb", new CheckBox("Use Smite in Combo"));
            //if (Game.MapId == GameMapId.SummonersRift)
            //{
            //    MiscMenu.Add("smjc", new CheckBox("Use smite to junglesteal"));
            //    MiscMenu.Add("Baron", new CheckBox("Jungsteal Baron"));
            //    MiscMenu.Add("Dragon", new CheckBox("Jungsteal Dragon"));
            //    MiscMenu.Add("Herald", new CheckBox("Jungsteal Herald"));
            //    MiscMenu.Add("Red", new CheckBox("Jungsteal Red"));
            //    MiscMenu.Add("Blue", new CheckBox("Jungsteal Blue"));
            //    MiscMenu.Add("Razorbeak", new CheckBox("Jungsteal Crimson Raptor", false));
            //    MiscMenu.Add("Krug", new CheckBox("Jungsteal Ancient Krug", false));
            //    MiscMenu.Add("Murkwolf", new CheckBox("Jungsteal Greater Murk Wolf", false));
            //    MiscMenu.Add("Gromp", new CheckBox("Jungsteal Gromp", false));
            //    MiscMenu.Add("Crab", new CheckBox("Jungsteal Crap"));
            //}


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

         
            MiscMenu.AddLabel("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬");
            MiscMenu.CreateCheckBox("- Use OP W Logic", "wLogic");
            MiscMenu.AddSeparator(10);

            DrawingsMenu.AddGroupLabel("Draw Settings");
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
            DrawingsMenu.AddSeparator();
            
        }
        public static bool BlockSpells
        {
            get { return MiscMenu.GetCheckBoxValue("wLogic"); }
        }

    }
    }
