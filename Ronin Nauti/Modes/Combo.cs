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

    internal class Combo
    {
        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }
        public static void Execute()
        {

            if (ComboMenu.GetCheckBoxValue("One"))
            { 
            var Target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

            if (Target == null) return;

            if (Target.IsValidTarget())
            {
                HitChance h = HitChance.Medium;
                if (RoninNauti.Menus.HitchanceQ == 1)
                    h = HitChance.Low;
                else if (RoninNauti.Menus.HitchanceQ == 2)
                    h = HitChance.Medium;
                else if (RoninNauti.Menus.HitchanceQ == 3)
                    h = HitChance.High;
                if (Target != null)
                    if (Q.IsReady() && ComboMenu.GetCheckBoxValue("qUse") && Q.GetPrediction(Target).HitChance >= HitChance.High)
                    {
                        Q.Cast(Target);

                    }
                var alvo = TargetSelector.GetTarget(1000, DamageType.Magical);

                if (E.IsReady() && ComboMenu.GetCheckBoxValue("eUse") && Player.Instance.IsInAutoAttackRange(Target))
                {
                    E.Cast();

                }

                if (W.IsReady() && ComboMenu.GetCheckBoxValue("wUse") && Player.Instance.IsInAutoAttackRange(Target))
                {
                    W.Cast();

                }
                var enemies = EntityManager.Heroes.Enemies.OrderByDescending(a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(_Player) <= R.Range);
                var checkhp = ComboMenu["hptoult"].Cast<Slider>().CurrentValue;
                var manual = UltimateMenu["manu.ult"].Cast<CheckBox>().CurrentValue;
                if (R.IsReady() && !manual)
                {
                    foreach (var ultenemies in enemies)

                    {
                            var useR = UltimateMenu["r.ult" + ultenemies.ChampionName].Cast<CheckBox>().CurrentValue;
                            if (ultenemies.HealthPercent <= checkhp)
                        {
                            if (useR)
                            {
                                R.Cast(ultenemies);
                            }
                        }
                    }
                }
                return;
            }
            }

            if (ComboMenu.GetCheckBoxValue("Two"))
            {
                var Target = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

                if (Target == null) return;

                if (Target.IsValidTarget())
                {
                    if (W.IsReady() && ComboMenu.GetCheckBoxValue("wUse") && Player.Instance.IsInAutoAttackRange(Target))
                    {
                        W.Cast();

                    }

                    if (E.IsReady() && ComboMenu.GetCheckBoxValue("eUse") && Player.Instance.IsInAutoAttackRange(Target))
                    {
                        E.Cast();

                    }

                    HitChance h = HitChance.Medium;
                    if (RoninNauti.Menus.HitchanceQ == 1)
                        h = HitChance.Low;
                    else if (RoninNauti.Menus.HitchanceQ == 2)
                        h = HitChance.Medium;
                    else if (RoninNauti.Menus.HitchanceQ == 3)
                        h = HitChance.High;
                    if (Target != null)
                        if (Q.IsReady() && ComboMenu.GetCheckBoxValue("qUse") && Q.GetPrediction(Target).HitChance >= HitChance.High)
                        {
                            Q.Cast(Target);

                        }

                    var alvo = TargetSelector.GetTarget(1000, DamageType.Magical);
                    var enemies = EntityManager.Heroes.Enemies.OrderByDescending(a => a.HealthPercent).Where(a => !a.IsMe && a.IsValidTarget() && a.Distance(_Player) <= R.Range);
                    var checkhp = ComboMenu["hptoult"].Cast<Slider>().CurrentValue;
                    var manual = ComboMenu["manu.ult"].Cast<CheckBox>().CurrentValue;
                    if (R.IsReady() && !manual)
                    {
                        foreach (var ultenemies in enemies)

                        {
                            var useR = ComboMenu["rUse" + ultenemies.ChampionName].Cast<CheckBox>().CurrentValue;
                            if (ultenemies.HealthPercent <= checkhp)
                            {
                                if (useR)
                                {
                                    R.Cast(ultenemies);
                                }
                            }
                        }
                    }
                    return;
                }
            }





        }
    }
}

