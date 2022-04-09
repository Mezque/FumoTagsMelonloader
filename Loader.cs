using FumoTagsMelonLoader.Modules;
using MelonLoader;
using System;
using System.Linq;
using System.IO;
[assembly: MelonInfo(typeof(FumoTagsMelonLoader.Loader), "Fumo Tags Melonloader", "1.0.1.0", "Mezque", "https://github.com/Mezque/FumoTagsMelonloader")]
[assembly: MelonColor(ConsoleColor.Red)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace FumoTagsMelonLoader
{
    public class Loader : MelonMod
    {
        public override void OnApplicationStart()
        {
            FumoClientCheck();
            LoggerInstance.Msg("If You Do Not Have A Tag You May Request One On Discord.");
            LoggerInstance.Msg("Discord Invite: https://discord.gg/g7AyvCme3t");
            LoggerInstance.Msg($"\x1b[35m[FUMO \x1b[36mDEBUG] \x1b[37m Fumo Tags Starting!");
            MelonCoroutines.Start(CustomTags.TagListNetworkManager());
        }
        private void FumoClientCheck()
        {
            if (!MelonHandler.Mods.Any(M => M.Info.Name == "Fumo Client")) return;
            MelonLogger.Warning("FumoTagsStandAlone Is Not Needed When Running Fumo Client!");
            System.IO.Directory.CreateDirectory(MelonUtils.GameDirectory + "\\Mods\\FumoUneededMods");
            string path = (MelonUtils.GameDirectory + "\\Mods\\FumoTagsMelonLoader.dll");
            string path2 = (MelonUtils.GameDirectory + "\\Mods\\FumoUneededMods\\FumoTagsMelonLoader.dll");
            try
            {
                if (!File.Exists(path))
                {
                    using (FileStream fs = File.Create(path)) { }
                }
                if (File.Exists(path2)) File.Delete(path2);
                File.Move(path, path2);
                MelonLogger.Msg("\x1b[35m[FUMO \x1b[33mFILES] \x1b[37m FumoTagsStandAlone Has Been Moved To FumoUneededMods!");

                if (File.Exists(path))
                {
                    MelonLogger.Msg("\x1b[35m[FUMO \x1b[33mFILES] \x1b[37m FumoTagsStandAlone Still Exists In Mods, Plesae Remove It!");
                }
                else
                {
                    MelonLogger.Msg("\x1b[35m[FUMO \x1b[33mFILES] \x1b[37m FumoTagsStandAlone Has Been Moved To FumoUneededMods!");
                }
            }
            catch (Exception ex)
            {
                MelonLogger.Msg($"\x1b[35m[FUMO \x1b[33mFILES] \x1b[37m The Process Failed:  {ex.ToString()}");
            }
        }
    }
}
