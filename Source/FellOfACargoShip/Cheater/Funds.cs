﻿using System;
using BattleTech;
using HBS;

namespace FellOfACargoShip.Cheater
{
    internal static class Funds
    {
        private static SimGameState simGameState = SceneSingletonBehavior<UnityGameInstance>.Instance.Game.Simulation;

        public static void Add(string param)
        {
            if (param == "help")
            {
                string help = "";
                help += "• This command will add funds to your company";
                help += Environment.NewLine;
                help += "• Params: the desired amount of c-bills";
                help += Environment.NewLine;
                help += "• Example: '/funds 3000000'";
                PopupHelper.Info(help);

                return;
            }



            string message = "";

            if (!int.TryParse(param, out int cbills) || cbills <= 0)
            {
                message = $"Param is not a positive number.";
                Logger.Debug($"[Cheater_Funds_Add] {message}");
                PopupHelper.Info(message);

                return;
            }

            simGameState.AddFunds(cbills, null, true);

            message = $"Added {cbills} C-Bills to company.";
            Logger.Debug($"[Cheater_Funds_Add] {message}");
            PopupHelper.Info(message);
        }
    }
}
