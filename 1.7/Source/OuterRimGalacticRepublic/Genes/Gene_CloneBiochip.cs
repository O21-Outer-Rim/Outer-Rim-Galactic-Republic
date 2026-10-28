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
    public class Gene_CloneBiochip : Gene
    {
        public override void PostAdd()
        {
            base.PostAdd();
            if(pawn.DevelopmentalStage != DevelopmentalStage.Newborn)
            {
                pawn.gender = Gender.Male;
                pawn.story.bodyType = BodyTypeDefOf.Male;
                pawn.story.headType = OuterRimGalacticRepublicDefOf.Male_AverageNormal;
                pawn.story.hairDef = PawnStyleItemChooser.RandomHairFor(pawn);
                pawn.ageTracker.AgeBiologicalTicks = (20 * 3600000) + (60000 * Rand.Range(1, 28)) + (Find.TickManager.TicksSinceSettle * 2);
                pawn.ageTracker.AgeChronologicalTicks = Mathf.RoundToInt(pawn.ageTracker.AgeBiologicalTicks / 2);
            }
        }
    }
}
