using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using HarmonyLib;

namespace OuterRimGalacticRepublic
{
    [HarmonyPatch(typeof(Pawn_RelationsTracker), "SecondaryLovinChanceFactor")]
    public static class Patch_Pawn_RelationsTracker_SecondaryLovinChanceFactor
    {
        [HarmonyPostfix]
        public static void Postfix(Pawn_RelationsTracker __instance, float __result, Pawn otherPawn)
        {
            Pawn pawn = __instance.pawn;
            if (ModsConfig.BiotechActive && pawn.genes?.Xenotype != null && otherPawn.genes?.Xenotype != null)
            {
                if(pawn.genes.Xenotype == OuterRimGalacticRepublicDefOf.OuterRim_FettClone && otherPawn.genes.Xenotype == OuterRimGalacticRepublicDefOf.OuterRim_FettClone)
                {
                    __result *= 0f;
                }
            }
        }
    }
}
