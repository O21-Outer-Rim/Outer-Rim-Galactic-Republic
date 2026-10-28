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
    public class OuterRimGalacticRepublicSettings : ModSettings
    {
        public bool verboseLogging = false;

        public bool republicClones21st = false;
        //public bool republicClones41st = false;
        //public bool republicClones91st = false;
        //public bool republicClones104th = false;
        public bool republicClones187th = false;
        public bool republicClones212th = true;
        //public bool republicClones327th = false;
        //public bool republicClones432nd = false;
        public bool republicClones442nd = false;
        //public bool republicClones501st = false;
        //public bool republicClones618th = false;
        public bool republicClonesCoruscantGuard = false;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look(ref republicClones21st, "republicClones21st", false);
            //Scribe_Values.Look(ref republicClones41st, "republicClones41st", false);
            //Scribe_Values.Look(ref republicClones91st, "republicClones91st", false);
            //Scribe_Values.Look(ref republicClones104th, "republicClones104th", false);
            Scribe_Values.Look(ref republicClones187th, "republicClones187th", false);
            Scribe_Values.Look(ref republicClones212th, "republicClones212th", true);
            //Scribe_Values.Look(ref republicClones327th, "republicClones327th", false);
            //Scribe_Values.Look(ref republicClones432nd, "republicClones432nd", false);
            Scribe_Values.Look(ref republicClones442nd, "republicClones442nd", false);
            //Scribe_Values.Look(ref republicClones501st, "republicClones501st", false);
            //Scribe_Values.Look(ref republicClones618th, "republicClones618th", false);
            Scribe_Values.Look(ref republicClonesCoruscantGuard, "republicClonesCoruscantGuard", false);
        }

        public bool IsValidSetting(string input)
        {
            if (GetType().GetFields().Where(p => p.FieldType == typeof(bool)).Any(i => i.Name == input))
            {
                return true;
            }

            return false;
        }

        public IEnumerable<string> GetEnabledSettings
        {
            get
            {
                return GetType().GetFields().Where(p => p.FieldType == typeof(bool) && (bool)p.GetValue(this)).Select(p => p.Name);
            }
        }
    }
}
