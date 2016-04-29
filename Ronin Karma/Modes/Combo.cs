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
using static RoninKarma.Menus;
using static RoninKarma.SpellsManager;

namespace RoninKarma.Modes
{

    internal class Combo
    {
        public static AIHeroClient getPlayer()
        {
            return ObjectManager.Player;
        }
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            if (ComboMenu.GetCheckBoxValue("combo1"))
            {

                if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady() && getPlayer().HealthPercent < comboUseRW)
                {
                    R.Cast();
                }

                if (ComboMenu.GetCheckBoxValue("eUse") && E.IsReady())
                {
                    E.Cast();
                }

                if (ComboMenu.GetCheckBoxValue("wUse") && wtarget.IsValidTarget(W.Range) && W.IsReady())
                {
                    W.Cast(wtarget);
                }

            if (ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady() && qtarget.IsValidTarget(Q.Range))
            {
                SpellsManager.Q.Cast(qtarget);
            }

            }

            if (ComboMenu.GetCheckBoxValue("combo2"))
            {
                if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady() && getPlayer().HealthPercent < comboUseRW)
                {
                    R.Cast();
                }

                if (ComboMenu.GetCheckBoxValue("wUse") && wtarget.IsValidTarget(W.Range) && W.IsReady())
                {
                    W.Cast(wtarget);
                }

                if (ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady() && qtarget.IsValidTarget(Q.Range))
                {
                    SpellsManager.Q.Cast(qtarget);
                }

            }

            if (ComboMenu.GetCheckBoxValue("combo3"))
            {
                if (ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady() && qtarget.IsValidTarget(Q.Range))
                {
                    SpellsManager.Q.Cast(qtarget);
                }

                if (ComboMenu.GetCheckBoxValue("wUse") && wtarget.IsValidTarget(W.Range) && W.IsReady())
                {
                    W.Cast(wtarget);
                }

                if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady() && getPlayer().HealthPercent < comboUseRW)
                {
                    R.Cast();
                }

            }

            if (ComboMenu.GetCheckBoxValue("combo4"))
            {
                if (ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady() && qtarget.IsValidTarget(Q.Range))
                {
                    SpellsManager.Q.Cast(qtarget);
                }

                if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady() && getPlayer().HealthPercent < comboUseRW)
                {
                    R.Cast();
                }

                if (ComboMenu.GetCheckBoxValue("wUse") && wtarget.IsValidTarget(W.Range) && W.IsReady())
                {
                    W.Cast(wtarget);
                }

                if (ComboMenu.GetCheckBoxValue("eUse") && E.IsReady())
                {
                    E.Cast();
                }

            }

            if (ComboMenu.GetCheckBoxValue("combo5"))
            {
                if (ComboMenu.GetCheckBoxValue("wUse") && wtarget.IsValidTarget(W.Range) && W.IsReady())
                {
                    W.Cast(wtarget);
                }

                if (ComboMenu.GetCheckBoxValue("eUse") && E.IsReady())
                {
                    E.Cast();
                }

                if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady() && getPlayer().HealthPercent < comboUseRW && ComboMenu.GetCheckBoxValue("qUse") && Q.IsReady())
                {
                    R.Cast();
                    Q.Cast(qtarget);
                }


            }


        }
    }
}