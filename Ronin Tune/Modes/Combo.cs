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
using static RoninTune.Menus;
using static RoninTune.SpellsManager;

namespace RoninTune.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class Combo
    {
        /// <summary>
        /// Put in here what you want to do when the mode is running
        /// </summary>
        public static readonly AIHeroClient Player = ObjectManager.Player;


        public static void Execute()
        {

            var enemiesq = EntityManager.Heroes.Enemies.OrderByDescending
                (a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(Player) <= Q.Range);
            var enemiesr = EntityManager.Heroes.Enemies.OrderByDescending
                (a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(Player) <= R.Range);
            var enemiesw = EntityManager.Heroes.Enemies.OrderByDescending
                (a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(Player) <= W.Range);
            var enemies = EntityManager.Heroes.Enemies.OrderByDescending
                (a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(Player) <= E.Range);
            var target = TargetSelector.GetTarget(1900, DamageType.Magical);

           if (ComboMenu.GetCheckBoxValue("cOne"))
            {

                if (R.IsReady() && target.IsValidTarget(R.Range) && ComboMenu.GetCheckBoxValue("rUse"))
                    foreach (var ultenemies in enemiesr)
                    {

                        R.Cast();
                        R1.Cast(ultenemies);
                    }

                if (E.IsReady() && ComboMenu.GetCheckBoxValue("eUse"))
                foreach (var eenemies in enemies)

                {
                    E.Cast(eenemies);
                }

                if (W.IsReady() && ComboMenu.GetCheckBoxValue("wUse"))
                {
                    W.Cast();
                }

                if (Q.IsReady() && target.IsValidTarget(Q.Range) && ComboMenu.GetCheckBoxValue("qUse"))
                {
                    foreach (var qenemies in enemiesq)
                    {
                        var predQ = Q.GetPrediction(qenemies);

                        {
                            Q.Cast(predQ.CastPosition);
                        }
                    }
                }

            }

            else if (ComboMenu.GetCheckBoxValue("cTwo"))
            {

                if (R.IsReady() && target.IsValidTarget(R.Range) && ComboMenu.GetCheckBoxValue("rUse"))
                    foreach (var ultenemies in enemiesr)
                    {

                        R.Cast();
                        R1.Cast(ultenemies);
                    }

                if (W.IsReady() && ComboMenu.GetCheckBoxValue("wUse"))
                {
                    W.Cast();
                }

                if (E.IsReady() && target.IsValidTarget(E.Range) && ComboMenu.GetCheckBoxValue("eUse"))
                    foreach (var eenemies in enemies)

                    {
                        E.Cast(eenemies);
                    }

                if (Q.IsReady() && target.IsValidTarget(Q.Range) && ComboMenu.GetCheckBoxValue("qUse"))
                {
                    foreach (var qenemies in enemiesq)
                    {
                        var predQ = Q.GetPrediction(qenemies);

                        {
                            Q.Cast(predQ.CastPosition);
                        }
                    }
                }
            }

           else if (ComboMenu.GetCheckBoxValue("cThree"))
            {

                if (R.IsReady() && target.IsValidTarget(R.Range) && ComboMenu.GetCheckBoxValue("rUse"))
                    foreach (var ultenemies in enemiesr)
                    {

                        R.Cast();
                        R1.Cast(ultenemies);
                    }

                if (Q.IsReady() && target.IsValidTarget(Q.Range) && ComboMenu.GetCheckBoxValue("qUse"))
                {
                    foreach (var qenemies in enemiesq)
                    {
                        var predQ = Q.GetPrediction(qenemies);

                        {
                            Q.Cast(predQ.CastPosition);
                        }

                        if (E.IsReady() && ComboMenu.GetCheckBoxValue("eUse"))
                    foreach (var eenemies in enemies)

                    {
                        E.Cast(eenemies);
                    }


            
                    }
                }

            }




            //Q.TryToCast(target, ComboMenu);
            //W.TryToCast(target, ComboMenu);
            //E.TryToCast(target, ComboMenu);
            //R.TryToCast(target, ComboMenu);

        }
    }
}