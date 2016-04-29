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
using static RoninVelkoz.Menus;
using static RoninVelkoz.SpellsManager;

namespace RoninVelkoz.Modes
{
    /// <summary>
    /// This mode will run when the key of the orbwalker is pressed
    /// </summary>
    internal class Combo
    {
        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }
        public static readonly AIHeroClient Player = ObjectManager.Player;
        public static void Execute()
        {
            var qtarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);
            var wtarget = TargetSelector.GetTarget(W.Range, DamageType.Magical);
            var etarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);
            var rtarget = TargetSelector.GetTarget(R.Range, DamageType.Magical);
            var enemiese = EntityManager.Heroes.Enemies.OrderByDescending
            (a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(Player) <= R.Range);

            if (qtarget.IsValidTarget())
            {
                //HitChance h = HitChance.Medium;
                //if (RoninVelkoz.Menus.HitchanceQ == 1)
                //    h = HitChance.Low;
                //else if (RoninVelkoz.Menus.HitchanceQ == 2)
                //    h = HitChance.Medium;
                //else if (RoninVelkoz.Menus.HitchanceQ == 3)

                //if (RoninVelkoz.Menus.HitchanceW == 1)
                //    h = HitChance.Low;
                //else if (RoninVelkoz.Menus.HitchanceW == 2)
                //    h = HitChance.Medium;
                //else if (RoninVelkoz.Menus.HitchanceW == 3)
                //    h = HitChance.High;

                //if (RoninVelkoz.Menus.HitchanceE == 1)
                //    h = HitChance.Low;
                //else if (RoninVelkoz.Menus.HitchanceE == 2)
                //    h = HitChance.Medium;
                //else if (RoninVelkoz.Menus.HitchanceE == 3)
                //    h = HitChance.High;

                //if (RoninVelkoz.Menus.HitchanceR == 1)
                //    h = HitChance.Low;
                //else if (RoninVelkoz.Menus.HitchanceR == 2)
                //    h = HitChance.Medium;
                //else if (RoninVelkoz.Menus.HitchanceR == 3)
                //    h = HitChance.High;

                if (qtarget != null)
                if (ComboMenu.GetCheckBoxValue("qUse") && qtarget.IsValidTarget(SpellsManager.Q.Range) && Q.IsReady())
                {
                    Q.Cast(qtarget);
                }
            }

            if (ComboMenu.GetCheckBoxValue("eUse") && E.IsReady() && etarget.IsValidTarget(SpellsManager.E.Range))
            {
                E.Cast(etarget);
            }

            if (ComboMenu.GetCheckBoxValue("wUse") && W.IsReady() && wtarget.IsValidTarget(SpellsManager.W.Range))
            {
                W.Cast(wtarget);
            }

            if (ComboMenu.GetCheckBoxValue("rUse") && R.IsReady() && Player.CountEnemiesInRange(SpellsManager.R.Range) >= ComboRLimiter)
            {
                foreach (var ultenemies in enemiese)
                {
                    var useR = ComboMenu["r.ult" + ultenemies.ChampionName].Cast<CheckBox>().CurrentValue;
                    {
                        if (useR)
                            R.Cast(ultenemies);
                    }
                }
            }


        }
    }
}