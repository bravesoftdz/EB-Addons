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
    internal class LaneClear
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            Orbwalker.ForcedTarget = null;
            var count = EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.ServerPosition, E.Range, false).Count();
            if (count == 0) return;
            if (E.IsReady() && LaneClearMenu.GetCheckBoxValue("eUse") && LaneClearMenu["lc.MinionsE"].Cast<Slider>().CurrentValue <= count)
            {
                E.Cast();
                return;
            }
            return;
        }
    }
}