using FumoTagsMelonLoader.Modules;
using MelonLoader;
using System;
[assembly: MelonInfo(typeof(FumoTagsMelonLoader.Loader), "Fumo Tags Melonloader", "1.0.1.2", "Mezque", "https://github.com/Mezque/FumoTagsMelonloader")]
[assembly: MelonColor(ConsoleColor.Red)]
[assembly: MelonGame("VRChat", "VRChat")]

namespace FumoTagsMelonLoader
{
    public class Loader : MelonMod
    {
        public override void OnApplicationStart()
        {
            LoggerInstance.Msg("If You Do Not Have A Tag You May Request One On Discord.");
            LoggerInstance.Msg("Discord Invite: https://discord.gg/g7AyvCme3t");
            LoggerInstance.Msg($"\x1b[35m[FUMO \x1b[36mDEBUG] \x1b[37m Fumo Tags Starting!");
            MelonCoroutines.Start(CustomTags.TagListNetworkManager());
        }
    }
}
