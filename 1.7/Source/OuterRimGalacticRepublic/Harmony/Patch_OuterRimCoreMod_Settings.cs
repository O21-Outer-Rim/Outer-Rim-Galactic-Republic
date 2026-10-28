using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;
using HarmonyLib;
using OuterRimCore;

namespace OuterRimGalacticRepublic
{
    [HarmonyPatch(typeof(OuterRimCoreMod), "DoOptionsCategoryContents")]
    public static class Patch_OuterRimCoreMod_Settings
    {
        [HarmonyPostfix]
        public static void Postfix(ref Listing_Standard listing)
        {
            OuterRimGalacticRepublicMod.mod.DoOptionsCategoryContents(listing);
        }
    }
}
