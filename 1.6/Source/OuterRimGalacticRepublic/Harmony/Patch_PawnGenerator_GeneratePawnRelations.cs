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
	[HarmonyPatch(typeof(PawnGenerator))]
	[HarmonyPatch("GeneratePawnRelations")]
	public static class Patch_PawnGenerator_GeneratePawnRelations
	{
		[HarmonyPrefix]
		public static bool Prefix(Pawn pawn)
		{
			if (pawn.genes != null && pawn.genes.HasGene(OuterRimGalacticRepublicDefOf.OuterRim_CloneBiochip))
			{
				return false;
			}
			return false;
		}
	}
}
