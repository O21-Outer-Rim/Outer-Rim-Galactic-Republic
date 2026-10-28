using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace OuterRimGalacticRepublic
{
    [DefOf]
    public static class OuterRimGalacticRepublicDefOf
    {
        static OuterRimGalacticRepublicDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(OuterRimGalacticRepublicDefOf));
        }

        [MayRequireBiotech]
        public static GeneDef OuterRim_CloneBiochip;

        [MayRequireBiotech]
        public static XenotypeDef OuterRim_FettClone;

        public static HeadTypeDef Male_AverageNormal;
    }
}
