﻿using System;
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
using static RoninVelkoz.Menus;
using static RoninVelkoz.SpellsManager;

namespace RoninVelkoz.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class Harass
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);

            if (HarassMenu.GetCheckBoxValue("qUse") && qtarget.IsValidTarget(SpellsManager.Q.Range) && Q.IsReady())
            {
                Q.Cast(qtarget);
            }

            if (HarassMenu.GetCheckBoxValue("eUse") && E.IsReady() && etarget.IsValidTarget(SpellsManager.E.Range))
            {
                E.Cast(etarget);
            }

            if (HarassMenu.GetCheckBoxValue("wUse") && W.IsReady() && wtarget.IsValidTarget(SpellsManager.W.Range))
            {
                W.Cast(wtarget);
            }

        }
    }
}