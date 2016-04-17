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
    /// This mode will always run
    /// </summary>
    internal class Active
    {
        public static AIHeroClient _Player
        {
            get { return ObjectManager.Player; }
        }
        public static AIHeroClient Target = null;
        public static void Execute()
        {
        }
        public static void Interrupter_OnInterruptableSpell(Obj_AI_Base unit, Interrupter.InterruptableSpellEventArgs spell)
        {
            if (MiscMenu["interruptq"].Cast<CheckBox>().CurrentValue && Q.IsReady() && Q.GetPrediction(Target).HitChance >= HitChance.High)
            {
                if (unit.Distance(_Player.ServerPosition, true) <= Q.Range && Q.GetPrediction(Target).HitChance >= HitChance.High)
                {
                    Q.Cast(Target);
                }
            }
            if (MiscMenu["interruptr"].Cast<CheckBox>().CurrentValue && R.IsReady())
            {
                if (unit.Distance(_Player.ServerPosition, true) <= R.Range)
                {
                    R.Cast();
                }
            }
        }
    }
}