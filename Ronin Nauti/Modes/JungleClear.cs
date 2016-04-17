using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Constants;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu.Values;
using EloBuddy.SDK.Rendering;
using SharpDX;
using Mario_s_Lib;
using static RoninNauti.Menus;
using static RoninNauti.SpellsManager;

namespace RoninNauti.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class JungleClear
    {
        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }
        public static void Execute()
        {
            

            var source = EntityManager.MinionsAndMonsters.GetJungleMonsters(_Player.ServerPosition, Q.Range).OrderByDescending(a => a.MaxHealth).FirstOrDefault();

           

            if (Q.IsReady() && JungleClearMenu.GetCheckBoxValue("qUse"))
            {
                Q.Cast(source);
                return;
            }

            if (W.IsReady() && JungleClearMenu.GetCheckBoxValue("wUse"))
            {
                W.Cast();
                return;

            }
            if (E.IsReady() && JungleClearMenu.GetCheckBoxValue("eUse"))
            {
                E.Cast();
                return;
            }
            return;
        }
    }
    }
