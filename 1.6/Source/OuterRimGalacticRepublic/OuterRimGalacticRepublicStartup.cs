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
    [StaticConstructorOnStartup]
    public static class OuterRimGalacticRepublicStartup
    {
        static OuterRimGalacticRepublicStartup()
        {
            CheckRepublicHasAtLeastOneBattalion();
        }

        public static void CheckRepublicHasAtLeastOneBattalion()
        {
            OuterRimGalacticRepublicSettings settings = OuterRimGalacticRepublicMod.settings;

                //!settings.republicClones41st &&
                //!settings.republicClones91st &&
                //!settings.republicClones104th &&
                //!settings.republicClones327th &&
                //!settings.republicClones432nd &&
                //!settings.republicClones501st &&
                //!settings.republicClones618th &&

            if (!settings.republicClones21st && 
                !settings.republicClones187th && 
                !settings.republicClones212th &&
                !settings.republicClones442nd &&
                !settings.republicClonesCoruscantGuard)
            {
                settings.republicClones212th = true;
            }
        }
    }
}
