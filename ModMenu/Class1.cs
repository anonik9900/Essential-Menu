using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GTA;
using GTA.Native;
using GTA.Math;
using GTA.NaturalMotion;
using NativeUI;
using System.Media;
using System.IO;
using System.Threading;
using System.Reflection;


namespace ModMenu
{
    public class Class1 : Script
    {
        private bool checkbox1 = false;
        private bool checkbox2 = false;
        private bool checkbox3 = false;
        private bool checkbox4 = false;
        private bool moneybox = false;
        private bool thermalbox = false;
        private bool nightbox = false;
        private bool drugbox = false;
        private bool bikerbox = false;
        private bool chopbox = false;
        private bool tazbox = false;
        private bool dneonbox = false;
        private bool jumpbox = false;
        private bool invcarbox = false;
        public static bool CanPlayerSuperJump { get; set; }
        bool neverWantedOn;
        bool InfiniteAmmo;
        bool moneyDrop40kOn;
        bool moneyDrop1MilOn;
        bool moneyDrop10MilOn;
        bool moneyDrop15MilOn;
        bool moneyDrop20MilOn;
        bool moneyDrop100MilOn;

        MenuPool modMenuPool;
        UIMenu mainMenu;
        UIMenu playerMenu;
        UIMenu onlineMenu;
        UIMenu weaponsMenu;
        UIMenu vehicleMenu;
        UIMenu cashMenu;
        UIMenu bodyguardMenu;
        UIMenu visionMenu;
        UIMenu miscMenu;
        UIMenu weatherMenu;
        UIMenu timeMenu;
        UIMenu teleportMenu;
        UIMenu yanktonMenu;
        UIMenu creditsMenu;

        //UIMenuItem resetWantedLevel;
        UIMenuItem KillPlayerItem;
        


        public Class1()
        {
            Setup();

            Interval = 1;
            Tick += onTick;
            KeyDown += onKeyDown;
        }

        void Setup()
        {
       
            modMenuPool = new MenuPool();
            

            mainMenu = new UIMenu("Essential Menu", "Made ~b~By Anonik v1.2");
            mainMenu.Title.Font = GTA.Font.ChaletComprimeCologne;
            mainMenu.Subtitle.Font = GTA.Font.Pricedown;
            modMenuPool.Add(mainMenu);

            playerMenu = modMenuPool.AddSubMenu(mainMenu, "Player Options");
            onlineMenu = modMenuPool.AddSubMenu(mainMenu, "~b~(Online Options)");
            weaponsMenu = modMenuPool.AddSubMenu(mainMenu, "Weapons Options");
            vehicleMenu = modMenuPool.AddSubMenu(mainMenu, "Vehicles Options");
            cashMenu = modMenuPool.AddSubMenu(mainMenu, "Money Options");
            bodyguardMenu = modMenuPool.AddSubMenu(mainMenu, "Bodyguard Menu");
            visionMenu = modMenuPool.AddSubMenu(mainMenu, "Vision Options");
            weatherMenu = modMenuPool.AddSubMenu(mainMenu, "Weather Options");
            timeMenu = modMenuPool.AddSubMenu(mainMenu, "Time Options");
            teleportMenu = modMenuPool.AddSubMenu(mainMenu, "Teleport Options");
            yanktonMenu = modMenuPool.AddSubMenu(mainMenu, "North Yankton Options");
            creditsMenu = modMenuPool.AddSubMenu(mainMenu, "Credits");

            SetupPlayerFunctions();
            SetupOnlineFunctions();
            SetupWeaponFunctions();
            SetupVehicleFuntions();
            SetupMoneyFunctions();
            SetupBodyguardFunctions();
            SetupVisionOptions();
            SetupWeatherFunctions();
            SetupTimeFunctions();
            SetupTeleportOptions();
            SetupYanktonOptions();
            SetupCreditsFunctions();





        }

        void SetupPlayerFunctions()
        {
            //ResetWantedLevel();
            Godmode();
            neverWanted();
            changeModel();
            KillPlayerMenu();
            truenerverwanted();
            superJumpPlayer();
        }

        void SetupOnlineFunctions()
        {
            onlineMoneyDrop();
        }

        void SetupWeaponFunctions()
        {
            WeaponSelectorMenu();
            GetAllWeapons();
            getWeapon();
            GetAInfiniteAmmo();
        }

        void SetupVehicleFuntions()
        {
            CarInvincible();
            VehicleSelectorMenu();
            VehicleSpawnByName();
            VehicleFixHealth();
            SpawnCarTrue();

        }

        void SetupCreditsFunctions()
        {

            /* UIMenuItem spawngioele = new UIMenuItem("Gioele Spawn");
             miscMenu.AddItem(spawngioele);

             miscMenu.OnItemSelect += (sender, item, index) =>
             {
                 Ped bodyguard = World.CreatePed(new Model(PedHash.Armoured02SMM), Game.Player.Character.Position);
                 bodyguard.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
                 bodyguard.Armor = 100; // Armor ranges from 1-100
                 PedGroup playerGroup = Game.Player.Character.CurrentPedGroup; // gets the players current group
                 Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, bodyguard, playerGroup); // puts the bodyguard into the players group
                 Function.Call(Hash.SET_PED_COMBAT_ABILITY, bodyguard, 100); // 100 = attack

                 UI.Notify("Gioele");
             };*/

            UIMenuItem authorItem = new UIMenuItem("~g~Dev and Author: [Anonik]");
            UIMenuItem templateItem = new UIMenuItem("~r~UI by: NativeUI");
            UIMenuItem sdkItem = new UIMenuItem("~b~Sdk ScripthookV [Alexander Blade]");
            UIMenuItem sdkItem2 = new UIMenuItem("~y~Sdk ScripthookVDotNet [Crosire]");
            creditsMenu.AddItem(authorItem);
            creditsMenu.AddItem(templateItem);
            creditsMenu.AddItem(sdkItem);
            creditsMenu.AddItem(sdkItem2);


        }

        void SetupTimeFunctions()
        {
                  
            UIMenuItem time1am = new UIMenuItem("Set Time To: ~o~01:00");
            UIMenuItem time2am = new UIMenuItem("Set Time To: ~o~02:00");
            UIMenuItem time3am = new UIMenuItem("Set Time To: ~o~03:00");
            UIMenuItem time4am = new UIMenuItem("Set Time To: ~o~04:00");
            UIMenuItem time5am = new UIMenuItem("Set Time To: ~o~05:00");
            UIMenuItem time6am = new UIMenuItem("Set Time To: ~o~06:00");
            UIMenuItem time7am = new UIMenuItem("Set Time To: ~o~07:00");
                UIMenuItem time8am = new UIMenuItem("Set Time To: ~o~08:00");
                UIMenuItem time9am = new UIMenuItem("Set Time To: ~o~09:00");
                UIMenuItem time10am = new UIMenuItem("Set Time To: ~o~10:00");
                UIMenuItem time11am = new UIMenuItem("Set Time To: ~o~11:00");
                UIMenuItem time12am = new UIMenuItem("Set Time To: ~o~12:00");
                UIMenuItem time13pm = new UIMenuItem("Set Time To: ~o~13:00");
                UIMenuItem time14pm = new UIMenuItem("Set Time To: ~o~14:00");
            UIMenuItem time15pm = new UIMenuItem("Set Time To: ~o~15:00");
            UIMenuItem time16pm = new UIMenuItem("Set Time To: ~o~16:00");
            UIMenuItem time17pm = new UIMenuItem("Set Time To: ~o~17:00");
            UIMenuItem time18pm = new UIMenuItem("Set Time To: ~o~18:00");
            UIMenuItem time19pm = new UIMenuItem("Set Time To: ~o~19:00");
            UIMenuItem time20pm = new UIMenuItem("Set Time To: ~o~20:00");
            UIMenuItem time21pm = new UIMenuItem("Set Time To: ~o~21:00");
            UIMenuItem time22pm = new UIMenuItem("Set Time To: ~o~22:00");
            UIMenuItem time23pm = new UIMenuItem("Set Time To: ~o~23:00");
            UIMenuItem time0am = new UIMenuItem("Set Time To: ~o~00:00");
            timeMenu.AddItem(time1am);
            timeMenu.AddItem(time2am);
            timeMenu.AddItem(time3am);
            timeMenu.AddItem(time4am);
            timeMenu.AddItem(time5am);
            timeMenu.AddItem(time6am);
            timeMenu.AddItem(time7am);
            timeMenu.AddItem(time8am);
                timeMenu.AddItem(time9am);
                timeMenu.AddItem(time10am);
                timeMenu.AddItem(time11am);
                timeMenu.AddItem(time12am);
                timeMenu.AddItem(time13pm);
                timeMenu.AddItem(time14pm);
            timeMenu.AddItem(time15pm);
            timeMenu.AddItem(time16pm);
            timeMenu.AddItem(time17pm);
            timeMenu.AddItem(time18pm);
            timeMenu.AddItem(time19pm);
            timeMenu.AddItem(time20pm);
            timeMenu.AddItem(time21pm);
            timeMenu.AddItem(time22pm);
            timeMenu.AddItem(time23pm);
            timeMenu.AddItem(time0am);


            timeMenu.OnItemSelect += (sender, item, index) =>
                {

                    if (item == time1am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 01, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~01:00");
                    }

                    if (item == time2am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 02, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~02:00");
                    }

                    if (item == time3am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 03, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~03:00");
                    }

                    if (item == time4am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 04, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~04:00");
                    }

                    if (item == time5am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 05, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~05:00");
                    }

                    if (item == time6am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 06, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~06:00");
                    }

                    if (item == time7am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 07, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~07:00");
                    }

                    if (item == time8am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 08, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~08:00");
                    }

                    if (item == time9am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 09, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~09:00");
                    }

                    if (item == time10am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 10, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~10:00");
                    //12 = Hour
                    //30 = Minute
                    //00 = Second
                    }

                    if (item == time11am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 11, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~10:00");
                    }

                    if (item == time12am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 12, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~12:00");
                    }

                    if (item == time13pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 13, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~13:00");
                    }

                    if (item == time14pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 14, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~14:00");
                    }

                    if (item == time15pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 15, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~15:00");
                    }

                    if (item == time16pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 16, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~16:00");
                    }

                    if (item == time17pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 17, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~17:00");
                    }

                    if (item == time18pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 18, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~18:00");
                    }

                    if (item == time19pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 19, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~19:00");
                    }

                    if (item == time20pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 20, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~20:00");
                    }

                    if (item == time21pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 21, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~21:00");
                    }

                    if (item == time22pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 22, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~22:00");
                    }

                    if (item == time23pm)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 23, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~23:00");
                    }

                    if (item == time0am)
                    {
                        Function.Call(Hash.SET_CLOCK_TIME, 00, 00, 00);
                        UI.ShowSubtitle("Time Setted To: ~g~00:00");
                    }
                };

       

    
        }

        void SetupWeatherFunctions()
        {
            UIMenuItem clear = new UIMenuItem("Clear");
            UIMenuItem extrasunny = new UIMenuItem("Extrasunny");
            UIMenuItem clouds = new UIMenuItem("Clouds");
            UIMenuItem smog = new UIMenuItem("Smog");
            UIMenuItem foggy = new UIMenuItem("Foggy");
            UIMenuItem overcast = new UIMenuItem("Overcast");
            UIMenuItem rain = new UIMenuItem("Rain");
            UIMenuItem thunder = new UIMenuItem("Thunder");
            UIMenuItem clearing = new UIMenuItem("Clearing");
            UIMenuItem neutral = new UIMenuItem("Neutral");
            UIMenuItem snow = new UIMenuItem("Snow");
            UIMenuItem blizzard = new UIMenuItem("Blizzard");
            UIMenuItem snowlight = new UIMenuItem("SnowLight");
            UIMenuItem halloween = new UIMenuItem("Halloween");
            UIMenuItem christmas = new UIMenuItem("Christmas");

            weatherMenu.AddItem(clear);
            weatherMenu.AddItem(extrasunny);
            weatherMenu.AddItem(clouds);
            weatherMenu.AddItem(smog);
            weatherMenu.AddItem(foggy);
            weatherMenu.AddItem(overcast);
            weatherMenu.AddItem(rain);
            weatherMenu.AddItem(thunder);
            weatherMenu.AddItem(clearing);
            weatherMenu.AddItem(neutral);
            weatherMenu.AddItem(snow);
            weatherMenu.AddItem(blizzard);
            weatherMenu.AddItem(snowlight);
            weatherMenu.AddItem(halloween);
            weatherMenu.AddItem(christmas);

            weatherMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == clear)
                {
                    World.Weather = Weather.Clear;
                    UI.ShowSubtitle("Weather Setted to Clear");
                }

                if (item == extrasunny)
                {
                    World.Weather = Weather.ExtraSunny;
                    UI.ShowSubtitle("Weather Setted to Extrasunny");
                }

                if (item == clouds)
                {
                    World.Weather = Weather.Clouds;
                    UI.ShowSubtitle("Weather Setted to Clouds");
                }

                if (item == smog)
                {
                    World.Weather = Weather.Smog;
                    UI.ShowSubtitle("Weather Setted to Smog");
                }

                if (item == foggy)
                {
                    World.Weather = Weather.Foggy;
                    UI.ShowSubtitle("Weather Setted to Foggy");
                }

                if (item == overcast)
                {
                    World.Weather = Weather.Overcast;
                    UI.ShowSubtitle("Weather Setted to Overcast");
                }

                if (item == rain)
                {
                    World.Weather = Weather.Raining;
                    UI.ShowSubtitle("Weather Setted to Raining");
                }

                if (item == thunder)
                {
                    World.Weather = Weather.ThunderStorm;
                    UI.ShowSubtitle("Weather Setted to Thunder Storm");
                }

                if (item == clearing)
                {
                    World.Weather = Weather.Clearing;
                    UI.ShowSubtitle("Weather Setted to Clearing");
                }

                if (item == neutral)
                {
                    World.Weather = Weather.Neutral;
                    UI.ShowSubtitle("Weather Setted to Neutral");
                }

                if (item == snow)
                {
                    World.Weather = Weather.Snowing;
                    UI.ShowSubtitle("Weather Setted to Snowing");
                }

                if (item == blizzard)
                {
                    World.Weather = Weather.Blizzard;
                    UI.ShowSubtitle("Weather Setted to Blizzard");
                }

                if (item == snowlight)
                {
                    World.Weather = Weather.Snowlight;
                    UI.ShowSubtitle("Weather Setted to SnowLight");
                }

                if (item == halloween)
                {
                    World.Weather = Weather.Halloween;
                    UI.ShowSubtitle("Weather Setted to Halloween");
                }

                if (item == christmas)
                {
                    World.Weather = Weather.Christmas;
                    UI.ShowSubtitle("Weather Setted to Christmas");
                }


            };
        }

        void SetupMoneyFunctions()
        {
            UIMenuItem add10k = new UIMenuItem("Add: ~g~10k");
            UIMenuItem add50k = new UIMenuItem("Add: ~g~50k");
            UIMenuItem add100k = new UIMenuItem("Add: ~g~100k");
            UIMenuItem add500k = new UIMenuItem("Add: ~g~500k");
            UIMenuItem add1milion = new UIMenuItem("Add: ~g~1.000.000");
            UIMenuItem add5milion = new UIMenuItem("Add: ~g~5.000.000");
            UIMenuItem add20milion = new UIMenuItem("Add: ~g~20.000.000");
            UIMenuItem add100milion = new UIMenuItem("Add: ~g~100.000.000");
            UIMenuItem add1bilion = new UIMenuItem("Add: ~g~1.000.000.000");
            UIMenuItem rem10k = new UIMenuItem("Remove: ~r~10k");
            UIMenuItem rem50k = new UIMenuItem("Remove: ~r~50k");
            UIMenuItem rem100k = new UIMenuItem("Remove: ~r~100k");
            UIMenuItem rem500k = new UIMenuItem("Remove: ~r~500k");
            UIMenuItem rem1milion = new UIMenuItem("Remove: ~r~1.000.000");
            UIMenuItem rem5milion = new UIMenuItem("Remove: ~r~5.000.000");
            UIMenuItem rem20milion = new UIMenuItem("Remove: ~r~20.000.000");
            UIMenuItem rem100milion = new UIMenuItem("Remove: ~r~100.000.000");
            UIMenuItem rem1bilion = new UIMenuItem("Remove: ~r~1.000.000.000");

            //Add Cash
            cashMenu.AddItem(add10k);
            cashMenu.AddItem(add50k);
            cashMenu.AddItem(add100k);
            cashMenu.AddItem(add500k);
            cashMenu.AddItem(add1milion);
            cashMenu.AddItem(add5milion);
            cashMenu.AddItem(add20milion);
            cashMenu.AddItem(add100milion);
            cashMenu.AddItem(add1bilion);

            //Remove Cash
            cashMenu.AddItem(rem10k);
            cashMenu.AddItem(rem50k);
            cashMenu.AddItem(rem100k);
            cashMenu.AddItem(rem500k);
            cashMenu.AddItem(rem1milion);
            cashMenu.AddItem(rem5milion);
            cashMenu.AddItem(rem20milion);
            cashMenu.AddItem(rem100milion);
            cashMenu.AddItem(rem1bilion);

            cashMenu.OnItemSelect += (sender, item, index) =>
            {

                if (item == add10k)
                {
                    UI.Notify("10.000 $ has been added to your account");
                    Game.Player.Money += 10000;
                }

                if (item == add50k)
                {
                    UI.Notify("50.000 $ has been added to your account");
                    Game.Player.Money += 50000;
                }

                if (item == add100k)
                {
                    UI.Notify("100.000 $ has been added to your account");
                    Game.Player.Money += 100000;
                }

                if (item == add500k)
                {
                    UI.Notify("500.000 $ has been added to your account");
                    Game.Player.Money += 500000;
                }

                if (item == add1milion)
                {
                    UI.Notify("1.000.000 $ has been added to your account");
                    Game.Player.Money += 1000000;
                }

                if (item == add5milion)
                {
                    UI.Notify("5.000.000 $ has been added to your account");
                    Game.Player.Money += 5000000;
                }

                if (item == add20milion)
                {
                    UI.Notify("20.000.000 $ has been added to your account");
                    Game.Player.Money += 20000000;
                }

                if (item == add100milion)
                {
                    UI.Notify("100.000.000 $ has been added to your account");
                    Game.Player.Money += 100000000;
                }

                if (item == add1bilion)
                {
                    UI.Notify("1.000.000.000 $ has been added to your account");
                    Game.Player.Money += 1000000000;
                }

                if (item == rem10k)
                {
                    UI.Notify("10.000 $ has been removed to your account");
                    Game.Player.Money -= 10000;
                }

                if (item == rem50k)
                {
                    UI.Notify("50.000 $ has been removed to your account");
                    Game.Player.Money -= 50000;
                }

                if (item == rem100k)
                {
                    UI.Notify("100.000 $ has been removed to your account");
                    Game.Player.Money -= 100000;
                }

                if (item == rem500k)
                {
                    UI.Notify("500.000 $ has been removed to your account");
                    Game.Player.Money -= 500000;
                }

                if (item == rem1milion)
                {
                    UI.Notify("1.000.000 $ has been removed to your account");
                    Game.Player.Money -= 1000000;
                }

                if (item == rem5milion)
                {
                    UI.Notify("5.000.000 $ has been removed to your account");
                    Game.Player.Money -= 5000000;
                }

                if (item == rem20milion)
                {
                    UI.Notify("20.000.000 $ has been removed to your account");
                    Game.Player.Money -= 20000000;
                }

                if (item == rem100milion)
                {
                    UI.Notify("100.000.000 $ has been removed to your account");
                    Game.Player.Money -= 100000000;
                }

                if (item == rem1bilion)
                {
                    UI.Notify("1.000.000.000 $ has been removed to your account");
                    Game.Player.Money -= 1000000000;
                }
            };
        }

        void SetupYanktonOptions()
        {
            UIMenuItem loadmap = new UIMenuItem("Load North Yankton","Load and Teleport to the North Yankton Map");
            UIMenuItem unloadmap = new UIMenuItem("Unload North Yankton","Unload the North Yankton Map");

            yanktonMenu.AddItem(loadmap);
            yanktonMenu.AddItem(unloadmap);

            yanktonMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == loadmap)
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        UI.Notify("North Yankton: ~g~ON");
                        player.Character.Position = new Vector3(3360.19f, -4849.67f, 111.8f);
                        Function.Call(Hash.REQUEST_IPL, "plg_01");
                        Function.Call(Hash.REQUEST_IPL, "prologue01");
                        Function.Call(Hash.REQUEST_IPL, "prologue01_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue01c");
                        Function.Call(Hash.REQUEST_IPL, "prologue01c_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue01d");
                        Function.Call(Hash.REQUEST_IPL, "prologue01d_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue01f");
                        Function.Call(Hash.REQUEST_IPL, "prologue01f_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue01g");
                        Function.Call(Hash.REQUEST_IPL, "prologue01h");
                        Function.Call(Hash.REQUEST_IPL, "prologue01h_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue01i");
                        Function.Call(Hash.REQUEST_IPL, "prologue01i_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue01j");
                        Function.Call(Hash.REQUEST_IPL, "prologue01j_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue01k");
                        Function.Call(Hash.REQUEST_IPL, "prologue01k_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue01z");
                        Function.Call(Hash.REQUEST_IPL, "prologue01z_lod");
                        Function.Call(Hash.REQUEST_IPL, "plg_02");
                        Function.Call(Hash.REQUEST_IPL, "prologue02");
                        Function.Call(Hash.REQUEST_IPL, "prologue02_lod");
                        Function.Call(Hash.REQUEST_IPL, "plg_03");
                        Function.Call(Hash.REQUEST_IPL, "prologue03");
                        Function.Call(Hash.REQUEST_IPL, "prologue03_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue03b");
                        Function.Call(Hash.REQUEST_IPL, "prologue03b_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue03_grv_dug");
                        Function.Call(Hash.REQUEST_IPL, "prologue03_grv_dug_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue03b");
                        Function.Call(Hash.REQUEST_IPL, "prologue0_grv_torch");
                        Function.Call(Hash.REQUEST_IPL, "plg_04");
                        Function.Call(Hash.REQUEST_IPL, "prologue04");
                        Function.Call(Hash.REQUEST_IPL, "prologue04_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue04b");
                        Function.Call(Hash.REQUEST_IPL, "prologue04b_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue04_cover");
                        Function.Call(Hash.REQUEST_IPL, "des_potree_end");
                        Function.Call(Hash.REQUEST_IPL, "des_potree_start");
                        Function.Call(Hash.REQUEST_IPL, "des_potree_start_lod");
                        Function.Call(Hash.REQUEST_IPL, "plg_05");
                        Function.Call(Hash.REQUEST_IPL, "prologue05");
                        Function.Call(Hash.REQUEST_IPL, "prologue05_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue05b");
                        Function.Call(Hash.REQUEST_IPL, "prologue05b_lod");
                        Function.Call(Hash.REQUEST_IPL, "plg_06");
                        Function.Call(Hash.REQUEST_IPL, "prologue06");
                        Function.Call(Hash.REQUEST_IPL, "prologue06_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue06b");
                        Function.Call(Hash.REQUEST_IPL, "prologue06b_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue06_int");
                        Function.Call(Hash.REQUEST_IPL, "prologue06_int_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue06_pannel");
                        Function.Call(Hash.REQUEST_IPL, "prologue06_pannel_lod");
                        Function.Call(Hash.REQUEST_IPL, "prologue_m2_door");
                        Function.Call(Hash.REQUEST_IPL, "prologue_m2_door_lod");
                        Function.Call(Hash.REQUEST_IPL, "plg_occl_00");
                        Function.Call(Hash.REQUEST_IPL, "prologue_occl");
                        Function.Call(Hash.REQUEST_IPL, "plg_rd");
                        Function.Call(Hash.REQUEST_IPL, "prologuerd");
                        Function.Call(Hash.REQUEST_IPL, "prologuerdb");
                        Function.Call(Hash.REQUEST_IPL, "prologuerd_lod");

                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(3360.19f, -4849.67f, 111.8f);

                    }
                    
                }

                if (item == unloadmap)
                {
                    UI.Notify("North Yankton: ~g~OFF");
                    Function.Call(Hash.REMOVE_IPL, "plg_01");
                    Function.Call(Hash.REMOVE_IPL, "prologue01");
                    Function.Call(Hash.REMOVE_IPL, "prologue01_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue01c");
                    Function.Call(Hash.REMOVE_IPL, "prologue01c_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue01d");
                    Function.Call(Hash.REMOVE_IPL, "prologue01d_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue01f");
                    Function.Call(Hash.REMOVE_IPL, "prologue01f_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue01g");
                    Function.Call(Hash.REMOVE_IPL, "prologue01h");
                    Function.Call(Hash.REMOVE_IPL, "prologue01h_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue01i");
                    Function.Call(Hash.REMOVE_IPL, "prologue01i_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue01j");
                    Function.Call(Hash.REMOVE_IPL, "prologue01j_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue01k");
                    Function.Call(Hash.REMOVE_IPL, "prologue01k_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue01z");
                    Function.Call(Hash.REMOVE_IPL, "prologue01z_lod");
                    Function.Call(Hash.REMOVE_IPL, "plg_02");
                    Function.Call(Hash.REMOVE_IPL, "prologue02");
                    Function.Call(Hash.REMOVE_IPL, "prologue02_lod");
                    Function.Call(Hash.REMOVE_IPL, "plg_03");
                    Function.Call(Hash.REMOVE_IPL, "prologue03");
                    Function.Call(Hash.REMOVE_IPL, "prologue03_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue03b");
                    Function.Call(Hash.REMOVE_IPL, "prologue03b_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue03_grv_dug");
                    Function.Call(Hash.REMOVE_IPL, "prologue03_grv_dug_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue03b");
                    Function.Call(Hash.REMOVE_IPL, "prologue0_grv_torch");
                    Function.Call(Hash.REMOVE_IPL, "plg_04");
                    Function.Call(Hash.REMOVE_IPL, "prologue04");
                    Function.Call(Hash.REMOVE_IPL, "prologue04_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue04b");
                    Function.Call(Hash.REMOVE_IPL, "prologue04b_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue04_cover");
                    Function.Call(Hash.REMOVE_IPL, "des_potree_end");
                    Function.Call(Hash.REMOVE_IPL, "des_potree_start");
                    Function.Call(Hash.REMOVE_IPL, "des_potree_start_lod");
                    Function.Call(Hash.REMOVE_IPL, "plg_05");
                    Function.Call(Hash.REMOVE_IPL, "prologue05");
                    Function.Call(Hash.REMOVE_IPL, "prologue05_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue05b");
                    Function.Call(Hash.REMOVE_IPL, "prologue05b_lod");
                    Function.Call(Hash.REMOVE_IPL, "plg_06");
                    Function.Call(Hash.REMOVE_IPL, "prologue06");
                    Function.Call(Hash.REMOVE_IPL, "prologue06_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue06b");
                    Function.Call(Hash.REMOVE_IPL, "prologue06b_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue06_int");
                    Function.Call(Hash.REMOVE_IPL, "prologue06_int_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue06_pannel");
                    Function.Call(Hash.REMOVE_IPL, "prologue06_pannel_lod");
                    Function.Call(Hash.REMOVE_IPL, "prologue_m2_door");
                    Function.Call(Hash.REMOVE_IPL, "prologue_m2_door_lod");
                    Function.Call(Hash.REMOVE_IPL, "plg_occl_00");
                    Function.Call(Hash.REMOVE_IPL, "prologue_occl");
                    Function.Call(Hash.REMOVE_IPL, "plg_rd");
                    Function.Call(Hash.REMOVE_IPL, "prologuerd");
                    Function.Call(Hash.REMOVE_IPL, "prologuerdb");
                    Function.Call(Hash.REMOVE_IPL, "prologuerd_lod");
                }
            };
        }

        void SetupTeleportOptions()
        {
            UIMenuItem teleportwaypoint = new UIMenuItem("Waypoint");
            UIMenuItem teleportchilliad = new UIMenuItem("Chilliad");
            UIMenuItem teleportpbank = new UIMenuItem("Pacific Standard Bank");
            UIMenuItem teleportpub1 = new UIMenuItem("Tequilala");
            UIMenuItem teleportpub2 = new UIMenuItem("Bahama Mamas");
            UIMenuItem teleportbell = new UIMenuItem("Cluckin Bell");
            UIMenuItem teleportfib = new UIMenuItem("FIB Lobby");
            UIMenuItem teleportfloyd = new UIMenuItem("Floyd House");
            UIMenuItem teleportlifeinvader = new UIMenuItem("Life Invader");
            UIMenuItem teleportlester = new UIMenuItem("Lester House");
            UIMenuItem teleportoneil = new UIMenuItem("O'Neil Ranch");
            UIMenuItem teleportsolomon = new UIMenuItem("Solomon's Office");
            UIMenuItem teleportyatch = new UIMenuItem("Yatch");

            teleportMenu.AddItem(teleportwaypoint);
            teleportMenu.AddItem(teleportchilliad);
            teleportMenu.AddItem(teleportpbank);
            teleportMenu.AddItem(teleportpub1);
            teleportMenu.AddItem(teleportpub2);
            teleportMenu.AddItem(teleportbell);
            teleportMenu.AddItem(teleportfib);
            teleportMenu.AddItem(teleportfloyd);
            teleportMenu.AddItem(teleportlifeinvader);
            teleportMenu.AddItem(teleportlester);
            teleportMenu.AddItem(teleportoneil);
            teleportMenu.AddItem(teleportsolomon);
            teleportMenu.AddItem(teleportyatch);

            teleportMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == teleportwaypoint)
                {
                    Player player = Game.Player;     
                    //Player1.Position = World.GetWaypointPosition();
                    //UI.DrawTexture("./scripts/ModResorces/picname.gif", 1, 1, 9999, new Point(0, 0), new Size(80, 80));
                    /*Vector3 waypointPos = World.GetWaypointPosition();
                    if (waypointPos != Vector3.Zero)
                    {
                        Game.Player.Character.Position = waypointPos;

         
                    }*/

                    var markerPosition = World.GetWaypointPosition();
                    var groundHeight = World.GetGroundHeight(markerPosition);

                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = markerPosition + (Vector3.WorldDown * 200.5f);
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = markerPosition + (Vector3.WorldDown * 200.5f);
                    }


                }

                if (item == teleportchilliad)
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(451.2820f, 5572.9897f, 796.6793f);
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(451.2820f, 5572.9897f, 796.6793f);
                    }

      
                }


                if (item == teleportpbank)
                {
                    //Pacific Standard Bank Vault X: 255.851 Y: 217.030 Z: 101.683
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(255.851f, 217.030f, 101.683f);
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(255.851f, 217.030f, 101.683f);
                    }
                }

                if (item == teleportpub1)
                {
                    //IAA Office X: 117.220 Y: -620.938 Z: 206.047
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        //player.Character.Position = new Vector3(117.220f,-620.938f,06.047f);
                        player.Character.Position = new Vector3(-556.5089111328125f, 286.318115234375f, 81.1763f);
                        Function.Call(Hash.DISABLE_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, -556.5089111328125, 286.318115234375, 81.1763), false);
                        Function.Call(Hash.CAP_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, -556.5089111328125, 286.318115234375, 81.1763), false);
                        Function.Call(Hash.REQUEST_IPL, "v_rockclub");
                        Function.Call(Hash._DOOR_CONTROL, 993120320, -565.1712f, 276.6259f, 83.28626f, false, 0.0f, 0.0f, 0.0f);// front door
                        Function.Call(Hash._DOOR_CONTROL, 993120320, -561.2866f, 293.5044f, 87.77851f, false, 0.0f, 0.0f, 0.0f);// back door

                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(255.851f, 217.030f, 101.683f);
                    }
                }

                if (item == teleportpub2)
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(-1388.0013427734375f, -618.419677734375f, 30.819599151611328f);
                        Function.Call(Hash.DISABLE_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, -1388.0013427734375, -618.419677734375, 30.819599151611328), false);
                        Function.Call(Hash.REQUEST_IPL, "v_bahama");
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(-1388.0013427734375f, -618.419677734375f, 30.819599151611328f);

                    }
                }

                if (item == teleportbell)
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(-72.68752f, 6253.72656f, 31.08991f);
                        Function.Call(Hash.REQUEST_IPL, "CS1_02_cf_onmission1");
                        Function.Call(Hash.REQUEST_IPL, "CS1_02_cf_onmission2");
                        Function.Call(Hash.REQUEST_IPL, "CS1_02_cf_onmission3");
                        Function.Call(Hash.REQUEST_IPL, "CS1_02_cf_onmission4");
                        Function.Call(Hash.REMOVE_IPL, "CS1_02_cf_offmission");
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(-72.68752f, 6253.72656f, 31.08991f);

                    }
                }

                if (item == teleportfib)
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(110.4f, -744.2f, 45.7f);
                        Function.Call(Hash.REQUEST_IPL, "FIBlobby");
                        Function.Call(Hash.REMOVE_IPL, "FIBlobbyfake");
                        Function.Call(Hash._DOOR_CONTROL, -1517873911, 106.3793f, -742.6982f, 46.51962f, false, 0.0f, 0.0f, 0.0f);
                        Function.Call(Hash._DOOR_CONTROL, -90456267, 105.7607f, -746.646f, 46.18266f, false, 0.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(110.4f, -744.2f, 45.7f);

                    }
                }

                if (item == teleportfloyd)
                {
                    {
                        Player player = Game.Player;
                        if (!player.Character.IsInVehicle())
                        {
                            player.Character.Position = new Vector3(-1149.709f, -1521.088f, 10.78267f);
                            Function.Call(Hash.REMOVE_IPL, "vb_30_crimetape");
                            Function.Call(Hash._DOOR_CONTROL, -607040053, -1149.709f, -1521.088f, 10.78267f, false, 0.0f, 0.0f, 0.0f);
                        }
                        else
                        {
                            Vehicle v = player.Character.CurrentVehicle;
                            v.Position = new Vector3(-1149.709f, -1521.088f, 10.78267f);

                        }
                    }
                }

                if (item == teleportlifeinvader)
                {
                    {
                        Player player = Game.Player;
                        if (!player.Character.IsInVehicle())
                        {
                            player.Character.Position = new Vector3(-1047.9f, -233.0f, 39.0f);
                            Function.Call(Hash.REQUEST_IPL, "facelobby");  // lifeinvader
                            Function.Call(Hash.REMOVE_IPL, "facelobbyfake");
                            Function.Call(Hash._DOOR_CONTROL, -340230128, -1042.518, -240.6915, 38.11796, true, 0.0f, 0.0f, -1.0f);
                        }
                        else
                        {
                            Vehicle v = player.Character.CurrentVehicle;
                            v.Position = new Vector3(-1047.9f, -233.0f, 39.0f);

                        }
                    }
                }

                if (item == teleportlester)
                {
                    {
                        Player player = Game.Player;
                        if (!player.Character.IsInVehicle())
                        {
                            player.Character.Position = new Vector3(1274.933837890625f, -1714.7255859375f, 53.77149963378906f);
                            Function.Call(Hash.DISABLE_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, 1274.933837890625, -1714.7255859375, 53.77149963378906), false);
                            Function.Call(Hash.REQUEST_IPL, "v_lesters");
                            Function.Call(Hash._DOOR_CONTROL, 1145337974, 1273.816f, -1720.697f, 54.92143f, false, 0.0f, 0.0f, 0.0f);
                        }
                        else
                        {
                            Vehicle v = player.Character.CurrentVehicle;
                            v.Position = new Vector3(1274.933837890625f, -1714.7255859375f, 53.77149963378906f);

                        }
                    }
                }

                if (item == teleportoneil)
                {
                    {
                        Player player = Game.Player;
                        if (!player.Character.IsInVehicle())
                        {
                            player.Character.Position = new Vector3(2441.2f, 4968.5f, 51.7f);
                            Function.Call(Hash.REMOVE_IPL, "farm_burnt");
                            Function.Call(Hash.REMOVE_IPL, "farm_burnt_lod");
                            Function.Call(Hash.REMOVE_IPL, "farm_burnt_props");
                            Function.Call(Hash.REMOVE_IPL, "farmint_cap");
                            Function.Call(Hash.REMOVE_IPL, "farmint_cap_lod");
                            Function.Call(Hash.REQUEST_IPL, "farm");
                            Function.Call(Hash.REQUEST_IPL, "farmint");
                            Function.Call(Hash.REQUEST_IPL, "farm_lod");
                            Function.Call(Hash.REQUEST_IPL, "farm_props");

                        }
                        else
                        {
                            Vehicle v = player.Character.CurrentVehicle;
                            v.Position = new Vector3(2441.2f, 4968.5f, 51.7f);

                        }
                    }
                }


                if (item == teleportsolomon)
                {
                    {
                        Player player = Game.Player;
                        if (!player.Character.IsInVehicle())
                        {
                            player.Character.Position = new Vector3(-1005.663208f, -478.3460998535156f, 49.0265f);
                            Function.Call(Hash.DISABLE_INTERIOR, Function.Call<int>(Hash.GET_INTERIOR_AT_COORDS, -1005.663208f, -478.3460998535156f, 49.0265f), false);
                            Function.Call(Hash.REQUEST_IPL, "v_58_sol_office");
                        }
                        else
                        {
                            Vehicle v = player.Character.CurrentVehicle;
                            v.Position = new Vector3(-1005.663208f, -478.3460998535156f, 49.0265f);

                        }
                    }
                }

                if (item == teleportyatch)
                {
                    Player player = Game.Player;
                    if (!player.Character.IsInVehicle())
                    {
                        player.Character.Position = new Vector3(-2045.8f, -1031.2f, 11.9f);
                        Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist");
                        Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_Bar");
                        Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_Bedrm");
                        Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_Bridge");
                        Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_DistantLights");
                        Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_enginrm");
                        Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_LODLights");
                        Function.Call(Hash.REQUEST_IPL, "hei_yacht_heist_Lounge");
                    }
                    else
                    {
                        Vehicle v = player.Character.CurrentVehicle;
                        v.Position = new Vector3(-2045.8f, -1031.2f, 11.9f);

                    }
                }



            };
        }

        void SetupBodyguardFunctions()
        {
            SpawnBodyguard();
            deleteBody();
        }

        void SetupVisionOptions()
        {
            var thermalvision = new UIMenuCheckboxItem("Thermal Vision",thermalbox);
            var nightvision = new UIMenuCheckboxItem("Night Vision", nightbox);
            var drugvision = new UIMenuCheckboxItem("Drug Vision", drugbox);
            var bikervision = new UIMenuCheckboxItem("Biker Vision", bikerbox);
            var chopvision = new UIMenuCheckboxItem("Chop Vision", chopbox);
            var tazemevision = new UIMenuCheckboxItem("DontTazeme", tazbox);
            var deadlineneonvision = new UIMenuCheckboxItem("Deadline Neon", dneonbox);
          
            visionMenu.AddItem(thermalvision);
            visionMenu.AddItem(nightvision);
            visionMenu.AddItem(drugvision);
            visionMenu.AddItem(bikervision);
            visionMenu.AddItem(chopvision);
            visionMenu.AddItem(tazemevision);
            visionMenu.AddItem(deadlineneonvision);

            visionMenu.OnCheckboxChange += (sender, item, check_) =>
            {
                if (item == thermalvision)
                {
                    if (check_ == true)
                    {
                        Game.ThermalVision = true;
                    }

                    if (check_ == false)
                    {
                        Game.ThermalVision = false;
                    }
                }

                if (item == nightvision)
                {
                    if (check_ == true)
                    {
                        Game.Nightvision = true;
                    }

                    if (check_ == false)
                    {
                        Game.Nightvision = false;
                    }
                }

                if (item == drugvision)
                {
                    if(check_ == true)
                    {
                        Function.Call(Hash._START_SCREEN_EFFECT, "DMT_flight", false);
                    }

                    if (check_ == false)
                    {
                        Function.Call(Hash._STOP_SCREEN_EFFECT, "DMT_flight");
                    }
                }

                if (item == bikervision)
                {
                    if (check_ == true)
                    {
                        Function.Call(Hash._START_SCREEN_EFFECT, "BikerFilter", false);
                    }

                    if (check_ == false)
                    {
                        Function.Call(Hash._STOP_SCREEN_EFFECT, "BikerFilter");
                    }
                }

                if (item == chopvision)
                {
                    if (check_ == true)
                    {
                        Function.Call(Hash._START_SCREEN_EFFECT, "ChopVision", false);
                    }

                    if (check_ == false)
                    {
                        Function.Call(Hash._STOP_SCREEN_EFFECT, "ChopVision");
                    }
                }

                if (item == tazemevision)
                {
                    if (check_ == true)
                    {
                        Function.Call(Hash._START_SCREEN_EFFECT, "Dont_tazeme_bro", false);
                    }

                    if (check_ == false)
                    {
                        Function.Call(Hash._STOP_SCREEN_EFFECT, "Dont_tazeme_bro");
                    }
                }

                if (item == deadlineneonvision)
                {
                    if (check_ == true)
                    {
                        Function.Call(Hash._START_SCREEN_EFFECT, "DeadlineNeon", false);
                        //BigMessageThread.MessageInstance.ShowMissionPassedMessage("ciao", 5000);
 
                    }

                        if (check_ == false)
                    {
                        Function.Call(Hash._STOP_SCREEN_EFFECT, "DeadlineNeon");

                    }
                }

            };
        }


        
        
    


        /*void ResetWantedLevel()
        {
            resetWantedLevel = new UIMenuItem("Reset Wanted Level");
            mainMenu.AddItem(resetWantedLevel);

            playerMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == resetWantedLevel)
                {
                    if (Game.Player.WantedLevel == 0)
                    {
                        UI.ShowSubtitle("You have no wanted levels!");
                    }
                    else
                    {
                        Game.Player.WantedLevel = 0;

                    }
                }
            };
        }*/


        
        void onlineMoneyDrop()
        {
            UIMenu onlinemoneydrop = modMenuPool.AddSubMenu(onlineMenu, "~g~Money Drop",Game.Player.Name);
            var add40konline = new UIMenuCheckboxItem("Drop 40K",moneybox);
            var add1miliononline = new UIMenuCheckboxItem("Drop 1 Milion", moneybox);
            var add10miliononline = new UIMenuCheckboxItem("Drop 10 Milion", moneybox);
            var add15miliononline = new UIMenuCheckboxItem("Drop 15 Milion", moneybox);
            var add20miliononline = new UIMenuCheckboxItem("Drop 20 Milion", moneybox);
            var add100miliononline = new UIMenuCheckboxItem("Drop 100 Milion", moneybox);
            onlinemoneydrop.AddItem(add40konline);
            onlinemoneydrop.AddItem(add1miliononline);
            onlinemoneydrop.AddItem(add10miliononline);
            onlinemoneydrop.AddItem(add15miliononline);
            onlinemoneydrop.AddItem(add20miliononline);
            onlinemoneydrop.AddItem(add100miliononline);

            onlinemoneydrop.OnCheckboxChange += (sender, item, checked_) =>
            {

                if (item == add40konline)
                {
                    if (checked_ == true)
                    {
                        moneyDrop40kOn = !moneyDrop40kOn;
                    }

                    if (checked_ == false)
                    {
                        moneyDrop40kOn = false;
                    }
                }

                if (item == add1miliononline)
                {
                    if (checked_ == true)
                    {
                        moneyDrop1MilOn = !moneyDrop1MilOn;
                    }

                    if (checked_ == false)
                    {
                        moneyDrop1MilOn = false;
                    }
                }

                if (item == add10miliononline)
                {
                    if (checked_ == true)
                    {
                        moneyDrop10MilOn = !moneyDrop10MilOn;
                    }

                    if (checked_ == false)
                    {
                        moneyDrop10MilOn = false;
                    }
                }

                if (item == add15miliononline)
                {
                    if (checked_ == true)
                    {
                        moneyDrop15MilOn = !moneyDrop15MilOn;
                    }

                    if (checked_ == false)
                    {
                        moneyDrop15MilOn = false;
                    }
                }

                if (item == add20miliononline)
                {
                    if (checked_ == true)
                    {
                        moneyDrop20MilOn = !moneyDrop20MilOn;
                    }

                    if (checked_ == false)
                    {
                        moneyDrop20MilOn = false;
                    }
                }

                if (item == add100miliononline)
                {
                    if (checked_ == true)
                    {
                        moneyDrop100MilOn = !moneyDrop100MilOn;
                    }

                    if (checked_ == false)
                    {
                        moneyDrop100MilOn = false;
                    }
                }


            };

        }



        

        void WeaponSelectorMenu()
        {
            UIMenu submenu = modMenuPool.AddSubMenu(weaponsMenu, "Weapon Selector Menu");

            List<dynamic> listOfWeapons = new List<dynamic>();
            WeaponHash[] allWeaponHashes = (WeaponHash[])Enum.GetValues(typeof(WeaponHash));
            for (int i = 0; i < allWeaponHashes.Length; i++)
            {
                listOfWeapons.Add(allWeaponHashes[i]);
            }

            UIMenuListItem list = new UIMenuListItem("Weapons: ", listOfWeapons, 0);
            submenu.AddItem(list);

            UIMenuItem getWeapon = new UIMenuItem("Get Weapon");
            submenu.AddItem(getWeapon);

            submenu.OnItemSelect += (sender, item, index) =>
            {
                if(item == getWeapon)
                {
                    int listIndex = list.Index;
                    WeaponHash currentHash = allWeaponHashes[listIndex];
                    Game.Player.Character.Weapons.Give(currentHash, 9999, true, true);
                }
            };
        }


        void GetAllWeapons()
        {
            UIMenuItem allWeapons = new UIMenuItem("Get All Weapons");
            weaponsMenu.AddItem(allWeapons);

            weaponsMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == allWeapons)
                {
                    WeaponHash[] allWeaponHashes = (WeaponHash[])Enum.GetValues(typeof(WeaponHash));
                    for (int i = 0; i < allWeaponHashes.Length; i++)
                    {
                        Game.Player.Character.Weapons.Give(allWeaponHashes[i], 9999, true, true);
                    }
                }
            };
        }

        void GetAInfiniteAmmo()
        {
            var checkbox_ammo = new UIMenuCheckboxItem("Get Unlimited Ammo", checkbox3, "Activate ~b~Unlimited Ammo");
            //UIMenuItem infiniteammo = new UIMenuItem("Infinite Ammo");
            weaponsMenu.AddItem(checkbox_ammo);

            weaponsMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
                if (item == checkbox_ammo)
                {
                    if (checked_ == true)
                    {
                        UI.Notify("Unlimited Ammo: ~b~ON");

                        InfiniteAmmo = !InfiniteAmmo;
     
                        /*Ped PlayerONE = Game.Player.Character;
                        PlayerONE.Weapons.Give(WeaponHash.CarbineRifle, 20, true, true);
                        Weapon currentweapon = PlayerONE.Weapons.Current;
                        currentweapon.Ammo = currentweapon.MaxAmmo;*/
                       
                        //Function.Call(Hash.SET_PED_INFINITE_AMMO_CLIP,Game.Player.Character);
                        //Function.Call(Hash.SET_PED_INFINITE_AMMO,Game.Player.Character.Weapons.Current);
                        

                    }//end true check

                    if (checked_ == false)
                    {
                        //Function.Call(Hash.GET_MAX_AMMO_IN_CLIP,Game.Player.Character);
                        UI.Notify("Unlimited Ammo: ~r~OFF");
                        InfiniteAmmo = false;
                        
                    }//end false check
                }
            };
        }



        void VehicleSelectorMenu()
        {
            UIMenu submenu = modMenuPool.AddSubMenu(vehicleMenu, "Vehicle Selector");

            List<dynamic> listOfVehicles = new List<dynamic>();
            VehicleHash[] allVehicleHashes = (VehicleHash[])Enum.GetValues(typeof(VehicleHash));
            for(int i = 0; i < allVehicleHashes.Length; i++)
            {
                listOfVehicles.Add(allVehicleHashes[i]);
            }

            UIMenuListItem list = new UIMenuListItem("Vehicle: ", listOfVehicles, 0);
            submenu.AddItem(list);

            UIMenuItem getVehicle = new UIMenuItem("Get Vehicle");
            submenu.AddItem(getVehicle);

            submenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == getVehicle)
                {
                    int listIndex = list.Index;
                    VehicleHash hash = allVehicleHashes[listIndex];

                    Ped gamePed = Game.Player.Character;

                    Vehicle v = World.CreateVehicle(hash, gamePed.Position, gamePed.Heading);
                    v.PlaceOnGround();
                    gamePed.Task.WarpIntoVehicle(v, VehicleSeat.Driver);
                }
            };
        }

        void VehicleSpawnByName()
        {
            UIMenuItem vehicleSpawnItem = new UIMenuItem("Spawn Vehicle By Name");
            vehicleMenu.AddItem(vehicleSpawnItem);
            vehicleMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == vehicleSpawnItem)
                {
                    Ped gamePed = Game.Player.Character;
                    string modelName = Game.GetUserInput(50);
                    Model model = new Model(modelName);
                    model.Request();

                    if(model.IsInCdImage && model.IsValid)
                    {
                        Vehicle v = World.CreateVehicle(model, gamePed.Position, gamePed.Heading);
                        v.PlaceOnGround();
                        gamePed.Task.WarpIntoVehicle(v, VehicleSeat.Driver);
                    }
                }
            };
        }

        void VehicleFixHealth()
        {
            UIMenuItem vehiclefixhealth = new UIMenuItem("Fix Car Health");
            vehicleMenu.AddItem(vehiclefixhealth);
            vehicleMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == vehiclefixhealth)
                {
                    UI.Notify("Vehicle Fixed");
                    Function.Call(Hash.SET_VEHICLE_FIXED,Game.Player.Character.CurrentVehicle);
                    Function.Call(Hash.FIX_VEHICLE_WINDOW,Game.Player.Character.CurrentVehicle);
                    Function.Call(Hash.SET_VEHICLE_DEFORMATION_FIXED,Game.Player.Character.CurrentVehicle);
                    Function.Call(Hash.SET_VEHICLE_TYRE_FIXED,Game.Player.Character.CurrentVehicle);
                }
            };
        }


        void CarInvincible()
        {
            var CarPlayerInvincible = new UIMenuCheckboxItem("Invincible Car", invcarbox, "Active car godmode, only if you are inside vehicle");
            vehicleMenu.AddItem(CarPlayerInvincible);

            vehicleMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
                if (item == CarPlayerInvincible)
                {
                    if (checked_ == true)
                    {
                        Ped player2 = Game.Player.Character;

                        if (!player2.IsInVehicle()) return;
                        if (Game.Player.LastVehicle == null || !Game.Player.LastVehicle.Exists()) return;

                        player2.CurrentVehicle.IsInvincible = true;
                        UI.Notify("Car Invincible: ~g~ON");


                    }

                    if (checked_ == false)
                    {
                        Ped player2 = Game.Player.Character;

                        if (!player2.IsInVehicle()) return;
                        if (Game.Player.LastVehicle == null || !Game.Player.LastVehicle.Exists()) return;

                        player2.CurrentVehicle.IsInvincible = false;
                        UI.Notify("Car Invincible: ~R~OFF");
                    }
                }
            };
        }


        void SpawnCarTrue()
        {
            UIMenu maincategory = modMenuPool.AddSubMenu(vehicleMenu, "Vehicle Spawner");
            UIMenu Supercat  = modMenuPool.AddSubMenu(maincategory, "Super");

            UIMenuItem car811Item = new UIMenuItem("811");
            UIMenuItem adderItem = new UIMenuItem("Adder");
            UIMenuItem autarchItem = new UIMenuItem("Autarch");
            UIMenuItem bansheeItem = new UIMenuItem("Banshee");
            UIMenuItem banshee2Item = new UIMenuItem("Banshee 900R");
            UIMenuItem bulletItem = new UIMenuItem("Bullet");
            UIMenuItem cheetahItem = new UIMenuItem("Cheetah");
            UIMenuItem entityxfItem = new UIMenuItem("Entity XF");
            UIMenuItem etr1Item = new UIMenuItem("ETR1");
            UIMenuItem fmjItem = new UIMenuItem("FMJ");
            UIMenuItem gp1Item = new UIMenuItem("GP1");
            UIMenuItem infernusItem = new UIMenuItem("Infernus");

            Supercat.AddItem(car811Item);
            Supercat.AddItem(adderItem);
            Supercat.AddItem(autarchItem);
            Supercat.AddItem(bansheeItem);
            Supercat.AddItem(banshee2Item);
            Supercat.AddItem(bulletItem);
            Supercat.AddItem(cheetahItem);
            Supercat.AddItem(entityxfItem);
            Supercat.AddItem(etr1Item);
            Supercat.AddItem(fmjItem);
            Supercat.AddItem(gp1Item);
            Supercat.AddItem(infernusItem);

            Supercat.OnItemSelect += (sender, item, index) =>
            {



                if (item == car811Item)
                {

                    Vehicle car811 = World.CreateVehicle(new Model("pfister811"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(car811, VehicleSeat.Driver);

                }

                if (item == adderItem)
                {

                   Vehicle adder = World.CreateVehicle(new Model("Adder"), Game.Player.Character.Position);
                   Ped gameped = Game.Player.Character;
                   gameped.Task.WarpIntoVehicle(adder, VehicleSeat.Driver);

                }

                if (item == autarchItem)
                {

                   Vehicle autarch = World.CreateVehicle(new Model("autarch"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(autarch, VehicleSeat.Driver);

                }

                if (item == bansheeItem)
                {

                    Vehicle banshee = World.CreateVehicle(new Model("banshee"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(banshee, VehicleSeat.Driver);

                }

                if (item == banshee2Item)
                {

                    Vehicle banshee2 = World.CreateVehicle(new Model("banshee2"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(banshee2, VehicleSeat.Driver);

                }

                if (item == bulletItem)
                {

                    Vehicle bullet = World.CreateVehicle(new Model("bullet"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(bullet, VehicleSeat.Driver);

                }

                if (item == cheetahItem)
                {

                    Vehicle cheetah = World.CreateVehicle(new Model("cheetah"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(cheetah, VehicleSeat.Driver);

                }

                if (item == entityxfItem)
                {

                    Vehicle entityfx = World.CreateVehicle(new Model("entityfx"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(entityfx, VehicleSeat.Driver);

                }

                if (item == etr1Item)
                {

                    Vehicle sheava = World.CreateVehicle(new Model("sheava"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(sheava, VehicleSeat.Driver);

                }

                if (item == fmjItem)
                {

                    Vehicle fmj = World.CreateVehicle(new Model("fmj"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(fmj, VehicleSeat.Driver);

                }

                if (item == gp1Item)
                {

                    Vehicle gp1 = World.CreateVehicle(new Model("gp1"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(gp1, VehicleSeat.Driver);

                }

                if (item == infernusItem)
                {

                    Vehicle infernus = World.CreateVehicle(new Model("infernus"), Game.Player.Character.Position);
                    Ped gameped = Game.Player.Character;
                    gameped.Task.WarpIntoVehicle(infernus, VehicleSeat.Driver);

                }
            };





        }

        void Godmode()
        {

            var checkbox = new UIMenuCheckboxItem("GodMode", checkbox1, "Activate ~b~GodMode");

           playerMenu.AddItem(checkbox);

            playerMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
                if (item == checkbox)
                {
                    if (checked_ == true)
                    {
                        UI.ShowSubtitle("GodMode Activated");
                        Game.Player.Character.IsInvincible = true;
                    }

                    if (checked_ == false)
                    {
                        UI.ShowSubtitle("GodMode Disactivated");
                        Game.Player.Character.IsInvincible = false;
                    }
                }
            };
        }

        void neverWanted()
        {
            var checkbox = new UIMenuCheckboxItem("Reset Wanted Level", checkbox2, "Reset the Wanted Level");
            playerMenu.AddItem(checkbox);


            playerMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
            if (item == checkbox)
            {
                if (checked_ == true)
                {

                    if (Game.Player.WantedLevel >= 1)
                    {
                        Game.Player.WantedLevel = 0;

                        UI.Notify("Wanted Level Reset");


                    }

                        
                    }

                    if (checked_ == false)
                    {
                        UI.Notify("Option Disabled");
                        Game.Player.WantedLevel = 0;
                    }
                }
            };
        }

        void truenerverwanted()
        {
            var neverWanted = new UIMenuCheckboxItem("Never Wanted", checkbox4, "No Police");
            playerMenu.AddItem(neverWanted);
            neverWanted.SetLeftBadge(UIMenuItem.BadgeStyle.Star);
            //newitem.SetRightBadge(UIMenuItem.BadgeStyle.Tick);

            playerMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
                if (item == neverWanted)
                {
                    if (checked_ == true)
                    {
                        UI.Notify("Never Wanted: ~g~ON");
                        neverWantedOn = !neverWantedOn;


                    }

                    if (checked_ == false)
                    {
                        UI.Notify("Never Wanted: ~r~OFF");
                        //Game.Player.WantedLevel = 0;
                        neverWantedOn = false;

                    }
                }
            };

        }

        void superJumpPlayer()
        {
            var SuperJumpPlayer1 = new UIMenuCheckboxItem("Super Jump", jumpbox, "Active Super Jump");
            playerMenu.AddItem(SuperJumpPlayer1);
            SuperJumpPlayer1.SetLeftBadge(UIMenuItem.BadgeStyle.Gun);

            playerMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
                if (item == SuperJumpPlayer1)
                {
                    if (checked_ == true)
                    {
                        CanPlayerSuperJump = !CanPlayerSuperJump;
                        UI.Notify("Super Jump: ~g~ON");
                    }

                    if (checked_ == false)
                    {
                        CanPlayerSuperJump = false;
                        UI.Notify("Super Jump: ~r~OFF");
                    }
                }
            };
        }





        


        void changeModel()
        {
            UIMenu mainModel = modMenuPool.AddSubMenu(playerMenu, "Model Changer");
            UIMenuItem outfitsrandom = new UIMenuItem("~b~Randomize Outfits");

            UIMenu storyModel = modMenuPool.AddSubMenu(mainModel, "Story Model");
            UIMenuItem alienItem = new UIMenuItem("Alien");
            UIMenuItem copItem = new UIMenuItem("Cop");
            UIMenuItem rangerItem = new UIMenuItem("Ranger");
            UIMenuItem clayItem = new UIMenuItem("ClayPain");
            UIMenuItem clownItem = new UIMenuItem("Clown");
            UIMenuItem jesusItem = new UIMenuItem("Jesus");
            UIMenuItem formageItem = new UIMenuItem("Cris Formage");
            UIMenuItem ballasItem = new UIMenuItem("Ballas");
            UIMenuItem marineItem = new UIMenuItem("Marine");
            UIMenuItem fbiItem = new UIMenuItem("FBI Man");
            UIMenuItem superItem = new UIMenuItem("Superman");
            UIMenuItem cjItem = new UIMenuItem("Fake CJ");
            UIMenuItem zombieItem = new UIMenuItem("Zombie");
            UIMenuItem lamarItem = new UIMenuItem("Lamar");
            UIMenuItem amandaItem = new UIMenuItem("Amanda");
            UIMenuItem traceyItem = new UIMenuItem("Tracey");
            UIMenuItem musclemainItem = new UIMenuItem("Muscle Man");
            UIMenuItem bigfootItem = new UIMenuItem("Bigfoot");

            UIMenu animalModel = modMenuPool.AddSubMenu(mainModel, "Animal Model");
            UIMenuItem catItem = new UIMenuItem("Cat");
            UIMenuItem hawkItem = new UIMenuItem("Hawk");
            UIMenuItem chopItem = new UIMenuItem("Chop");
            UIMenuItem chimpItem = new UIMenuItem("Chimp");
            UIMenuItem cowItem = new UIMenuItem("Cow");
            UIMenuItem coyoteItem = new UIMenuItem("Coyote");
            UIMenuItem crowItem = new UIMenuItem("Crow");
            UIMenuItem cormoItem = new UIMenuItem("Cormorant");
            UIMenuItem boarItem = new UIMenuItem("Board");

            //Main menu
            mainModel.AddItem(outfitsrandom);

            //Story Model
            storyModel.AddItem(alienItem);
            storyModel.AddItem(copItem);
            storyModel.AddItem(rangerItem);
            storyModel.AddItem(clayItem);
            storyModel.AddItem(clownItem);
            storyModel.AddItem(jesusItem);
            storyModel.AddItem(formageItem);
            storyModel.AddItem(ballasItem);
            storyModel.AddItem(marineItem);
            storyModel.AddItem(fbiItem);
            storyModel.AddItem(superItem);
            storyModel.AddItem(cjItem);
            storyModel.AddItem(zombieItem);
            storyModel.AddItem(lamarItem);
            storyModel.AddItem(amandaItem);
            storyModel.AddItem(traceyItem);
            storyModel.AddItem(musclemainItem);
            storyModel.AddItem(bigfootItem);

            //Animal
            animalModel.AddItem(catItem);
            animalModel.AddItem(hawkItem);
            animalModel.AddItem(chopItem);
            animalModel.AddItem(chimpItem);
            animalModel.AddItem(cowItem);
            animalModel.AddItem(coyoteItem);
            animalModel.AddItem(crowItem);
            animalModel.AddItem(cormoItem);
            animalModel.AddItem(boarItem);

            mainModel.OnItemSelect += (sender, item, index) =>
                {

                    if (item == outfitsrandom)
                    {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.Character.RandomizeOutfit();
                    }

                };

            //StoryModel

            storyModel.OnItemSelect += (sender, item, index) =>
            {

                if (item == alienItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.MovAlien01);
                }

                if (item == copItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Cop01SMY);
                }


                if (item == rangerItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Ranger01SMY);
                }

                if (item == clayItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Claypain);
                }

                if (item == clownItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Clown01SMY);
                }

                if (item == jesusItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Jesus01);
                }

                if (item == formageItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.CrisFormage);
                }

                if (item == ballasItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.BallaOrig01GMY);
                }

                if (item == marineItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Marine03SMY);
                }

                if (item == fbiItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.FibSec01SMM);
                }

                if (item == superItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Imporage);
                }

                if (item == cjItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.StrPunk02GMY);
                }

                if (item == zombieItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Zombie01);
                }

                if (item == lamarItem)
                {
                    Model model = PedHash.LamarDavis;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        // we couldn't load that model...
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);

                }


                if (item == amandaItem)
                {
                    Model model = PedHash.AmandaTownley;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                }


                if (item == traceyItem)
                {
                    Model model = PedHash.TracyDisanto;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        // we couldn't load that model...
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                }


                if (item == musclemainItem)
                {
                    Model model = PedHash.Babyd;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                }

                if (item == bigfootItem)
                {
                    Model model = PedHash.Orleans;

                    if (!model.IsLoaded && !model.Request(1000))
                    {
                        return;
                    }

                    Game.Player.ChangeModel(model);

                    Function.Call(Hash.SET_PED_DEFAULT_COMPONENT_VARIATION, Game.Player.Character);
                }

            };

            //Animal Model
            animalModel.OnItemSelect += (sender, item, index) =>
            {
                if (item == catItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Cat);
                }

                if (item == hawkItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.ChickenHawk);
                }

                if (item == chopItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Chop);
                }

                if (item == chimpItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Chimp);
                }

                if (item == cowItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Cow);
                }

                if (item == coyoteItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Coyote);
                }

                if (item == crowItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Crow);
                }

                if (item == cormoItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Cormorant);
                }

                if (item == boarItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.Boar);
                }
            };

        }

        void KillPlayerMenu()
        {
            KillPlayerItem = new UIMenuItem("Kill Yourself","You commite suicide :(");
            playerMenu.AddItem(KillPlayerItem);

            playerMenu.OnItemSelect += (sender, item, index) =>
            {
                if (item == KillPlayerItem)
                {
                    Ped player = Game.Player.Character;
                    player.Health = 0;
             
                }
            };
        }





        void SpawnBodyguard()
        {
            UIMenu spawnBody = modMenuPool.AddSubMenu(bodyguardMenu, "Spawn Bodyguard");

            UIMenuItem copItem = new UIMenuItem("Police");
            UIMenuItem franckItem = new UIMenuItem("Franklin");
            UIMenuItem trevorItem = new UIMenuItem("Trevor");
            UIMenuItem marineItem = new UIMenuItem("Marine");

            spawnBody.AddItem(copItem);
            spawnBody.AddItem(franckItem);
            spawnBody.AddItem(trevorItem);
            spawnBody.AddItem(marineItem);

            spawnBody.OnItemSelect += (sender, item, index) =>
            {
                if ( item == copItem)
                {
                    Ped player = Game.Player.Character;

                    Vector3 loc = player.Position + (player.ForwardVector * 5);

                    Ped bodyguard = World.CreatePed(PedHash.Cop01SMY, loc);

                    bodyguard.Weapons.Give(WeaponHash.Pistol50, 9999, true, true);

                    bodyguard.Armor = 100;

                    PedGroup ped = player.CurrentPedGroup;

                    Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, bodyguard, ped);

                    Function.Call(Hash.SET_PED_COMBAT_ABILITY, bodyguard, 100);

                    Function.Call(Hash.SET_PED_ACCURACY, bodyguard, 100);

                    bodyguard.Task.FightAgainstHatedTargets(50000);

                    UI.Notify("Bodyguard Spawned");

                    UI.Notify("Mod by Anonik");

                    if (player.IsInvincible == true)
                    {
                        bodyguard.IsInvincible = true;
                    }

                    if (player.IsInvincible == false)
                    {
                        bodyguard.IsInvincible = false;
                    }
                }

                if (item == franckItem)
                {
                    Ped player = Game.Player.Character;

                    Vector3 loc = player.Position + (player.ForwardVector * 5);

                    Ped bodyguard = World.CreatePed(PedHash.Franklin, loc);

                    bodyguard.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);

                    bodyguard.Armor = 100;

                    PedGroup ped = player.CurrentPedGroup;

                    Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, bodyguard, ped);

                    Function.Call(Hash.SET_PED_COMBAT_ABILITY, bodyguard, 100);

                    Function.Call(Hash.SET_PED_ACCURACY, bodyguard, 100);

                    bodyguard.Task.FightAgainstHatedTargets(50000);

                    UI.Notify("Bodyguard Spawned");

                    UI.Notify("Mod by Anonik");
                    if (player.IsInvincible == true)
                    {
                        bodyguard.IsInvincible = true;
                    }

                    if (player.IsInvincible == false)
                    {
                        bodyguard.IsInvincible = false;
                    }
                }

                if (item == trevorItem)
                {
                    Ped player = Game.Player.Character;

                    Vector3 loc = player.Position + (player.ForwardVector * 5);

                    Ped bodyguard = World.CreatePed(PedHash.Trevor, loc);

                    bodyguard.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);

                    bodyguard.Armor = 100;

                    PedGroup ped = player.CurrentPedGroup;

                    Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, bodyguard, ped);

                    Function.Call(Hash.SET_PED_COMBAT_ABILITY, bodyguard, 100);

                    Function.Call(Hash.SET_PED_ACCURACY, bodyguard, 100);

                    bodyguard.Task.FightAgainstHatedTargets(50000);

                    UI.Notify("Bodyguard Spawned");

                    UI.Notify("Mod by Anonik");

                    if (player.IsInvincible == true)
                    {
                        bodyguard.IsInvincible = true;
                    }

                    if (player.IsInvincible == false)
                    {
                        bodyguard.IsInvincible = false;
                    }
                }

                if (item == marineItem)
                {
                    Ped player = Game.Player.Character;

                    Vector3 loc = player.Position + (player.ForwardVector * 5);

                    Ped bodyguard = World.CreatePed(PedHash.Marine03SMY, loc);

                    bodyguard.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);

                    bodyguard.Armor = 100;

                    PedGroup ped = player.CurrentPedGroup;

                    Function.Call(Hash.SET_PED_AS_GROUP_MEMBER, bodyguard, ped);

                    Function.Call(Hash.SET_PED_COMBAT_ABILITY, bodyguard, 100);

                    Function.Call(Hash.SET_PED_ACCURACY, bodyguard, 100);

                    bodyguard.Task.FightAgainstHatedTargets(50000);

                    UI.Notify("Bodyguard Spawned");

                    UI.Notify("Mod by Anonik");

                    if (player.IsInvincible == true)
                    {
                        bodyguard.IsInvincible = true;
                    }

                    if (player.IsInvincible == false)
                    {
                        bodyguard.IsInvincible = false;
                    }
                }

                if (Game.Player.Character.IsDead == true)
                {

                    Function.Call(Hash.REMOVE_GROUP,Game.Player.Character.CurrentPedGroup);
                    
                }
            };


        }


        void deleteBody()
        {
            UIMenuItem Deletebody = new UIMenuItem("Delete All Bodyguard", "The Bodyguards stop following you");
            bodyguardMenu.AddItem(Deletebody);

            bodyguardMenu.OnItemSelect += (sender, item, index) =>
            {
                if ( item == Deletebody)
                {
                    Ped player = Game.Player.Character;
                    Vector3 loc = player.Position + (player.ForwardVector * 5);
                    PedGroup ped = player.CurrentPedGroup;
                    Function.Call(Hash.REMOVE_GROUP, ped);
                }
            };
        }

        

        void getWeapon()
        {
            UIMenu mainWeapon = modMenuPool.AddSubMenu(weaponsMenu, "Get Weapon");

            UIMenuItem bodyItem = new UIMenuItem("~r~Melee weapons");
            UIMenuItem knifeItem = new UIMenuItem("Knife");
            UIMenuItem stickItem = new UIMenuItem("NightStick");
            UIMenuItem hammerItem = new UIMenuItem("Hammer");
            UIMenuItem batItem = new UIMenuItem("Baseball Bat");
            UIMenuItem crowItem = new UIMenuItem("Crowbar");
            UIMenuItem golfItem = new UIMenuItem("Golf Bat");
            UIMenuItem bottleItem = new UIMenuItem("Bottle");
            UIMenuItem daggerItem = new UIMenuItem("Dagger");
            UIMenuItem hatItem = new UIMenuItem("Hatchet");
            UIMenuItem dusterItem = new UIMenuItem("Knuckle Duster");
            UIMenuItem macheteItem = new UIMenuItem("Machete");
            UIMenuItem flashItem = new UIMenuItem("Flashlight");
            UIMenuItem bladeItem = new UIMenuItem("Switch Blade");
            UIMenuItem wrenchItem = new UIMenuItem("Wrench");
            UIMenuItem axeItem = new UIMenuItem("Battle Axe");

            //HandGun
            UIMenuItem body2lItem = new UIMenuItem("~r~HandGuns");
            UIMenuItem pistolItem = new UIMenuItem("Pistol");
            UIMenuItem pistolmk2Item = new UIMenuItem("Pistol MK2");
            UIMenuItem combatPistolItem = new UIMenuItem("Combat Pistol");
            UIMenuItem pistol50Item = new UIMenuItem("50 Caliber Pistol");
            UIMenuItem snspistolItem = new UIMenuItem("SNS Pistol");
            UIMenuItem heavypistolItem = new UIMenuItem("Heavy Pistol");
            UIMenuItem vintagepistolItem = new UIMenuItem("Vintage Pistol");
            UIMenuItem marskpistolItem = new UIMenuItem("Marskman Pistol");
            UIMenuItem revolverItem = new UIMenuItem("Revolver");
            UIMenuItem appistolItem = new UIMenuItem("AP Pistol");
            UIMenuItem stungunItem = new UIMenuItem("Stun Gun");
            UIMenuItem flaregunItem = new UIMenuItem("Flare Gun");

            //MachineGun
            UIMenuItem body3Item = new UIMenuItem("~r~Machine Guns");
            UIMenuItem microsmgItem = new UIMenuItem("Micro SMG");
            UIMenuItem machinepistolItem = new UIMenuItem("Machine Pistol");
            UIMenuItem smgItem = new UIMenuItem("SMG");
            UIMenuItem assaultsmgItem = new UIMenuItem("Assault SMG");
            UIMenuItem combatpdwItem = new UIMenuItem("Combat PDW");
            UIMenuItem mgItem = new UIMenuItem("MG");
            UIMenuItem combatmgItem = new UIMenuItem("Combat MG");
            UIMenuItem combatmgmk2Item = new UIMenuItem("Combat MG MK2");
            UIMenuItem gusenbergItem = new UIMenuItem("Gusenberg");
            UIMenuItem minismgItem = new UIMenuItem("Mini SMG");

            //Assault Riffle
            UIMenuItem body4Item = new UIMenuItem("~r~Assault Rifle Gun");
            UIMenuItem assaultriffleItem = new UIMenuItem("Assault Rifle");
            UIMenuItem assaultrifflemk2Item = new UIMenuItem("Assault RIfle Mk2");
            UIMenuItem carabineriffleItem = new UIMenuItem("Carabine");
            UIMenuItem carabinerifflemk2Item = new UIMenuItem("Carabine Mk2");
            UIMenuItem advancedriffleItem = new UIMenuItem("Advanced Rifle");
            UIMenuItem specialcarabineItem = new UIMenuItem("Special Carabine");
            UIMenuItem bullpupriffleItem = new UIMenuItem("Bullpup Rifle");
            UIMenuItem compactriffleItem = new UIMenuItem("Compact Rifle");

            //Sniper Riffle
            UIMenuItem body5Item = new UIMenuItem("~r~Sniper Rifle");
            UIMenuItem sniperriffleItem = new UIMenuItem("Sniper");
            UIMenuItem heavysniperItem = new UIMenuItem("Heavy Sniper");
            UIMenuItem heavysnipermk2Item = new UIMenuItem("Heavy Sniper Mk2");
            UIMenuItem marskmanrifleItem = new UIMenuItem("Marskman Rifle");

            //Shotgun
            UIMenuItem body6Item = new UIMenuItem("~r~Shotguns");
            UIMenuItem pumpItem = new UIMenuItem("Pump Shotgun");
            UIMenuItem sawItem = new UIMenuItem("Sawnoff Shotgun");
            UIMenuItem bullupItem = new UIMenuItem("Bullup Shotgun");
            UIMenuItem assaultItem = new UIMenuItem("Assault Shotgun");
            UIMenuItem musketItem = new UIMenuItem("Musket");
            UIMenuItem pump2Item = new UIMenuItem("Pump Mk2 Shotgun");
            UIMenuItem heavyItem = new UIMenuItem("Heavy Shotgun");
            UIMenuItem dbshotItem = new UIMenuItem("Double Barrel Shotgun");
            UIMenuItem sweeperItem = new UIMenuItem("Sweeper Shotgun");
            UIMenuItem combatItem = new UIMenuItem("Combat Shotgun");

            //Melee Weapon
            mainWeapon.AddItem(bodyItem);
            mainWeapon.AddItem(knifeItem);
            mainWeapon.AddItem(stickItem);
            mainWeapon.AddItem(hammerItem);
            mainWeapon.AddItem(batItem);
            mainWeapon.AddItem(crowItem);
            mainWeapon.AddItem(golfItem);
            mainWeapon.AddItem(bottleItem);
            mainWeapon.AddItem(daggerItem);
            mainWeapon.AddItem(hatItem);
            mainWeapon.AddItem(dusterItem);
            mainWeapon.AddItem(macheteItem);
            mainWeapon.AddItem(flashItem);
            mainWeapon.AddItem(bladeItem);
            mainWeapon.AddItem(wrenchItem);
            mainWeapon.AddItem(axeItem);

            //HandGuns Weapon
            mainWeapon.AddItem(body2lItem);
            mainWeapon.AddItem(pistolItem);
            mainWeapon.AddItem(pistolmk2Item);
            mainWeapon.AddItem(combatPistolItem);
            mainWeapon.AddItem(pistol50Item);
            mainWeapon.AddItem(snspistolItem);
            mainWeapon.AddItem(heavypistolItem);
            mainWeapon.AddItem(vintagepistolItem);
            mainWeapon.AddItem(marskpistolItem);
            mainWeapon.AddItem(revolverItem);
            mainWeapon.AddItem(appistolItem);
            mainWeapon.AddItem(stungunItem);
            mainWeapon.AddItem(flaregunItem);

            //MachineGun
            mainWeapon.AddItem(body3Item);
            mainWeapon.AddItem(microsmgItem);
            mainWeapon.AddItem(machinepistolItem);
            mainWeapon.AddItem(smgItem);
            mainWeapon.AddItem(assaultsmgItem);
            mainWeapon.AddItem(combatpdwItem);
            mainWeapon.AddItem(mgItem);
            mainWeapon.AddItem(combatmgItem);
            mainWeapon.AddItem(combatmgmk2Item);
            mainWeapon.AddItem(gusenbergItem);
            mainWeapon.AddItem(minismgItem);

            //Assault Riffle
            mainWeapon.AddItem(body4Item);
            mainWeapon.AddItem(assaultriffleItem);
            mainWeapon.AddItem(assaultrifflemk2Item);
            mainWeapon.AddItem(carabineriffleItem);
            mainWeapon.AddItem(carabinerifflemk2Item);
            mainWeapon.AddItem(advancedriffleItem);
            mainWeapon.AddItem(specialcarabineItem);
            mainWeapon.AddItem(bullpupriffleItem);
            mainWeapon.AddItem(compactriffleItem);

            //Sniper Riffle
            mainWeapon.AddItem(body5Item);
            mainWeapon.AddItem(sniperriffleItem);
            mainWeapon.AddItem(heavysniperItem);
            mainWeapon.AddItem(heavysnipermk2Item);
            mainWeapon.AddItem(marskmanrifleItem);

            //Shotgun
            mainWeapon.AddItem(body6Item);
            mainWeapon.AddItem(pumpItem);
            mainWeapon.AddItem(sawItem);
            mainWeapon.AddItem(bullupItem);
            mainWeapon.AddItem(assaultItem);
            mainWeapon.AddItem(musketItem);
            mainWeapon.AddItem(pump2Item);
            mainWeapon.AddItem(heavyItem);
            mainWeapon.AddItem(dbshotItem);
            mainWeapon.AddItem(sweeperItem);
            mainWeapon.AddItem(combatItem);


            mainWeapon.OnItemSelect += (sender, item, index) =>
            {
                if (item == knifeItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Knife, 9999, true, true);
                }

                if (item == stickItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Nightstick, 9999, true, true);
                }

                if (item == hammerItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Hammer, 9999, true, true);
                }

                if (item == batItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Bat, 9999, true, true);
                }

                if (item == crowItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Crowbar, 9999, true, true);
                }

                if (item == golfItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.GolfClub, 9999, true, true);
                }

                if (item == bottleItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Bottle, 9999, true, true);
                }

                if (item == daggerItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Dagger, 9999, true, true);
                }

                if (item == hatItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Hatchet, 9999, true, true);
                }

                if (item == dusterItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.KnuckleDuster, 9999, true, true);
                }

                if (item == macheteItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Machete, 9999, true, true);
                }

                if (item == flashItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Flashlight, 9999, true, true);
                }

                if (item == bladeItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.SwitchBlade, 9999, true, true);
                }

                if (item == wrenchItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Wrench, 9999, true, true);
                }

                if (item == axeItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.BattleAxe, 9999, true, true);
                }

                //Start Fire Weapon
                
                if (item == pistolItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Pistol, 9999, true, true);
                }

                if (item == pistolmk2Item)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.PistolMk2, 9999, true, true);
                }

                if (item == combatPistolItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.CombatPistol, 9999, true, true);
                }

                if (item == pistol50Item)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Pistol50, 9999, true, true);
                }

                if (item == snspistolItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.SNSPistol, 9999, true, true);
                }

                if (item == heavypistolItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.HeavyPistol, 9999, true, true);
                }

                if (item == vintagepistolItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.VintagePistol, 9999, true, true);
                }

                if (item == marskpistolItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.MarksmanPistol, 9999, true, true);
                }

                if (item == revolverItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Revolver, 9999, true, true);
                }

                if (item == appistolItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.APPistol, 9999, true, true);
                }

                if (item == stungunItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.StunGun, 9999, true, true);
                }

                if (item == flaregunItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.FlareGun, 9999, true, true);
                }


                // MachineGun
                if (item == microsmgItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.MicroSMG, 9999, true, true);
                }

                if (item == machinepistolItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.MachinePistol, 9999, true, true);
                }

                if (item == smgItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.SMG, 9999, true, true);
                }

                if (item == assaultsmgItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.AssaultSMG, 9999, true, true);
                }

                if (item == combatpdwItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.CombatPDW, 9999, true, true);
                }

                if (item == mgItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.MG, 9999, true, true);
                }

                if (item == combatmgItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.CombatMG, 9999, true, true);
                }

                if (item == combatmgmk2Item)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.CombatMGMk2, 9999, true, true);
                }

                if (item == gusenbergItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Gusenberg, 9999, true, true);
                }

                if (item == minismgItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.MiniSMG, 9999, true, true);
                }

                
                //Assault Riffle
                if (item == assaultriffleItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.AssaultRifle, 9999, true, true);
                }

                if (item == assaultrifflemk2Item)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.AssaultrifleMk2, 9999, true, true);
                }

                if (item == carabineriffleItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.CarbineRifle, 9999, true, true);
                }

                if (item == carabinerifflemk2Item)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.CarbineRifleMk2, 9999, true, true);
                }

                if (item == advancedriffleItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.AdvancedRifle, 9999, true, true);
                }

                if (item == specialcarabineItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.SpecialCarbine, 9999, true, true);
                }

                if (item == bullpupriffleItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.BullpupRifle, 9999, true, true);
                }

                if (item == compactriffleItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.CompactRifle, 9999, true, true);
                }

                //Sniper Riffle
                if (item == sniperriffleItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.SniperRifle, 9999, true, true);
                }

                if (item == heavysniperItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.HeavySniper, 9999, true, true);
                }

                if (item == heavysnipermk2Item)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.HeavySniperMk2, 9999, true, true);
                }

                if (item == marskmanrifleItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.MarksmanRifle, 9999, true, true);
                }

                //Shotgun
                if (item == pumpItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.PumpShotgun, 9999, true, true);
                }

                if (item == sawItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.SawnOffShotgun, 9999, true, true);
                }

                if (item == bullupItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.BullpupShotgun, 9999, true, true);
                }

                if (item == assaultItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.AssaultShotgun, 9999, true, true);
                }

                if (item == musketItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.Musket, 9999, true, true);
                }

                if (item == pump2Item)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.PumpShotgunMk2, 9999, true, true);
                }

                if (item == heavyItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.HeavyShotgun, 9999, true, true);
                }

                if (item == dbshotItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.DoubleBarrelShotgun, 9999, true, true);
                }

                if (item == sweeperItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.SweeperShotgun, 9999, true, true);
                }

                if (item == combatItem)
                {
                    Game.Player.Character.Weapons.Give(WeaponHash.CombatShotgun, 9999, true, true);
                }
            };


        }





        void onTick(object sender, EventArgs e)
        {
            if (modMenuPool != null)
                modMenuPool.ProcessMenus();
            if (neverWantedOn)
            {
                Game.Player.WantedLevel = 0;
            }

            if (InfiniteAmmo)
            {
                Ped PlayerONE = Game.Player.Character;
                Weapon currentweapon = PlayerONE.Weapons.Current;
                currentweapon.Ammo = currentweapon.MaxAmmo;
            }

            if (moneyDrop40kOn)
            {
                Vector3 pos = Game.Player.Character.Position;
                var hash = Function.Call<int>(Hash.GET_HASH_KEY, "PICKUP_MONEY_CASE");
                var model = new Model(0x113FD533); // prop_money_bag_01
                model.Request(1000);
                Function.Call(Hash.CREATE_AMBIENT_PICKUP, hash, pos.X, pos.Y, pos.Z, 0, 40000, 0x113FD533, false, true);
                model.MarkAsNoLongerNeeded();
            }

            if (moneyDrop1MilOn)
            {
                Vector3 pos = Game.Player.Character.Position;
                var hash = Function.Call<int>(Hash.GET_HASH_KEY, "PICKUP_MONEY_CASE");
                var model = new Model(0x113FD533); // prop_money_bag_01
                model.Request(1000);
                Function.Call(Hash.CREATE_AMBIENT_PICKUP, hash, pos.X, pos.Y, pos.Z, 0, 1000000, 0x113FD533, false, true);
                model.MarkAsNoLongerNeeded();
            }


            if (moneyDrop10MilOn)
            {
                Vector3 pos = Game.Player.Character.Position;
                var hash = Function.Call<int>(Hash.GET_HASH_KEY, "PICKUP_MONEY_CASE");
                var model = new Model(0x113FD533); // prop_money_bag_01
                model.Request(1000);
                Function.Call(Hash.CREATE_AMBIENT_PICKUP, hash, pos.X, pos.Y, pos.Z, 0, 10000000, 0x113FD533, false, true);
                model.MarkAsNoLongerNeeded();
            }

            if (moneyDrop15MilOn)
            {
                Vector3 pos = Game.Player.Character.Position;
                var hash = Function.Call<int>(Hash.GET_HASH_KEY, "PICKUP_MONEY_CASE");
                var model = new Model(0x113FD533); // prop_money_bag_01
                model.Request(1000);
                Function.Call(Hash.CREATE_AMBIENT_PICKUP, hash, pos.X, pos.Y, pos.Z, 0, 15000000, 0x113FD533, false, true);
                model.MarkAsNoLongerNeeded();
            }

            if (moneyDrop20MilOn)
            {
                Vector3 pos = Game.Player.Character.Position;
                var hash = Function.Call<int>(Hash.GET_HASH_KEY, "PICKUP_MONEY_CASE");
                var model = new Model(0x113FD533); // prop_money_bag_01
                model.Request(1000);
                Function.Call(Hash.CREATE_AMBIENT_PICKUP, hash, pos.X, pos.Y, pos.Z, 0, 20000000, 0x113FD533, false, true);
                model.MarkAsNoLongerNeeded();
            }

            if (moneyDrop100MilOn)
            {
                Vector3 pos = Game.Player.Character.Position;
                var hash = Function.Call<int>(Hash.GET_HASH_KEY, "PICKUP_MONEY_CASE");
                var model = new Model(0x113FD533); // prop_money_bag_01
                model.Request(1000);
                Function.Call(Hash.CREATE_AMBIENT_PICKUP, hash, pos.X, pos.Y, pos.Z, 0, 100000000, 0x113FD533, false, true);
                model.MarkAsNoLongerNeeded();
            }

            if (CanPlayerSuperJump)
                Function.Call(Hash.SET_SUPER_JUMP_THIS_FRAME, Game.Player);


        }

        void onKeyDown(object sender, KeyEventArgs e)
        {
            ScriptSettings.Load("scripts\\essentialconfig.ini");
            GTA.ScriptSettings configkey;
            Keys OpenMenu;

            configkey = ScriptSettings.Load("scripts\\essentialconfig.ini");
            OpenMenu = configkey.GetValue<Keys>("Options", "OpenMenu", Keys.Z); //The Z key will be set my default, but the user can change the key

            if (e.KeyCode == OpenMenu  /*Keys.Z*/ && !modMenuPool.IsAnyMenuOpen())
            {
                mainMenu.Visible = !mainMenu.Visible;
                

                mainMenu.SetBannerType("scripts\\mainBanner.jpg"); //banner directory
                weaponsMenu.SetBannerType("scripts\\weaponsBanner.jpg");
                vehicleMenu.SetBannerType("scripts\\carBanner.jpg");
                cashMenu.SetBannerType("scripts\\moneyBanner.jpg");
                weatherMenu.SetBannerType("scripts\\weatherBanner.jpg");
                teleportMenu.SetBannerType("scripts\\teleportBanner.jpg");
                var banner = new Sprite("shopui_title_movie_masks", "shopui_title_movie_masks", new Point(0, 0), new Size(0, 0));
                visionMenu.SetBannerType(banner);
                creditsMenu.SetBannerType("scripts\\mainBanner.jpg");
                
                var background = new Sprite("commonmenu", "bgd_gradient", new Point(100, 20), new Size(200, 500));
                



            }
        }
    }
}
