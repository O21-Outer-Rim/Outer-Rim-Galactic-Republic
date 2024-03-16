using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

using TabulaRasa;

namespace OuterRimGalacticRepublic
{
    public class OuterRimGalacticRepublicMod : Mod
    {
        public static OuterRimGalacticRepublicMod mod;
        public static OuterRimGalacticRepublicSettings settings;

        public Vector2 optionsScrollPosition;
        public float optionsViewRectHeight;

        internal static string VersionDir => Path.Combine(mod.Content.ModMetaData.RootDir.FullName, "Version.txt");
        public static string CurrentVersion { get; private set; }

        public OuterRimGalacticRepublicMod(ModContentPack content) : base(content)
        {
            mod = this;
            settings = GetSettings<OuterRimGalacticRepublicSettings>();

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            CurrentVersion = $"{version.Major}.{version.Minor}.{version.Build}";

            LogUtil.LogMessage($"{CurrentVersion} ::");

            if (Prefs.DevMode)
            {
                File.WriteAllText(VersionDir, CurrentVersion);
            }

            Harmony OuterRimHarmony = new Harmony("Neronix17.OuterRimGalacticRepublic.RimWorld");
            OuterRimHarmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        public override string SettingsCategory() => "Outer Rim - Galactic Republic";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            bool flag = optionsViewRectHeight > inRect.height;
            Rect viewRect = new Rect(inRect.x, inRect.y, inRect.width - (flag ? 26f : 0f), optionsViewRectHeight);
            Widgets.BeginScrollView(inRect, ref optionsScrollPosition, viewRect);
            Listing_Standard listing = new Listing_Standard();
            Rect rect = new Rect(viewRect.x, viewRect.y, viewRect.width, 999999f);
            listing.Begin(rect);
            // ============================ CONTENTS ================================
            DoOptionsCategoryContents(listing);
            // ======================================================================
            optionsViewRectHeight = listing.CurHeight;
            listing.End();
            Widgets.EndScrollView();
        }

        public void DoOptionsCategoryContents(Listing_Standard listing)
        {
            listing.Note("Some settings may require a game restart to take effect.", GameFont.Tiny);
            listing.GapLine();
            listing.Note("Selected battalions will show up as part of the Republic faction in any visits, raids and settlements.", GameFont.Tiny);
            listing.CheckboxLabeled("Republic (21st Nova Corps/Galactic Marines)", ref settings.republicClones21st);
            //listing.CheckboxLabeled("Republic (41st Elite Corps)", ref settings.republicClones41st);
            //listing.CheckboxLabeled("Republic (91st Mobile Recon Corps)", ref settings.republicClones91st);
            //listing.CheckboxLabeled("Republic (104th Legion/Wolfpack)", ref settings.republicClones104th);
            listing.CheckboxLabeled("Republic (187th Legion)", ref settings.republicClones187th);
            listing.CheckboxLabeled("Republic (212th Battalion)", ref settings.republicClones212th);
            //listing.CheckboxLabeled("Republic (327th Star Corps)", ref settings.republicClones327th);
            //listing.CheckboxLabeled("Republic (432nd Strike Force)", ref settings.republicClones432nd);
            listing.CheckboxLabeled("Republic (442nd Siege Battalion)", ref settings.republicClones442nd);
            //listing.CheckboxLabeled("Republic (501st Legion)", ref settings.republicClones501st);
            //listing.CheckboxLabeled("Republic (618th Tactical Strike Legion)", ref settings.republicClones618th);
            listing.CheckboxLabeled("Republic (Coruscant Guard)", ref settings.republicClonesCoruscantGuard);

            OuterRimGalacticRepublicStartup.CheckRepublicHasAtLeastOneBattalion();
        }
    }
}
