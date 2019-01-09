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
using NativeUI;


namespace ModMenu
{
    public class Class1 : Script
    {
        private bool checkbox1 = false;
        private bool checkbox2 = false;
        private bool checkbox3 = false;
        MenuPool modMenuPool;
        UIMenu mainMenu;
        UIMenu playerMenu;
        UIMenu weaponsMenu;
        UIMenu vehicleMenu;
        UIMenu cashMenu;
        UIMenu bodyguardMenu;
        UIMenu miscMenu;

        UIMenuItem resetWantedLevel;
        UIMenuItem KillPlayerItem;



        public Class1()
        {
            Setup();


            Tick += onTick;
            KeyDown += onKeyDown;
        }

        void Setup()
        {
            modMenuPool = new MenuPool();
            mainMenu = new UIMenu("Essential Menu", "Made ~b~By Anonik v1.0");
            modMenuPool.Add(mainMenu);

            playerMenu = modMenuPool.AddSubMenu(mainMenu, "Player Options");
            weaponsMenu = modMenuPool.AddSubMenu(mainMenu, "Weapons Options");
            vehicleMenu = modMenuPool.AddSubMenu(mainMenu, "Vehicles Options");
            cashMenu = modMenuPool.AddSubMenu(mainMenu, "Money Options");
            bodyguardMenu = modMenuPool.AddSubMenu(mainMenu, "Bodyguard Menu");
            miscMenu = modMenuPool.AddSubMenu(mainMenu, "Misc Options");

            SetupPlayerFunctions();
            SetupWeaponFunctions();
            SetupVehicleFuntions();
            SetupMoneyFunctions();
            SetupBodyguardFunctions();
            SetupMiscFunctions();
            
        }

        void SetupPlayerFunctions()
        {
            //ResetWantedLevel();
            Godmode();
            neverWanted();
            changeModel();
            KillPlayerMenu();
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
            VehicleSelectorMenu();
            VehicleSpawnByName();
            VehicleFixHealth();
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

            cashMenu.AddItem(add10k);
            cashMenu.AddItem(add50k);
            cashMenu.AddItem(add100k);
            cashMenu.AddItem(add500k);
            cashMenu.AddItem(add1milion);
            cashMenu.AddItem(add5milion);
            cashMenu.AddItem(add20milion);
            cashMenu.AddItem(add100milion);
            cashMenu.AddItem(add1bilion);

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
            };
        }

        void SetupBodyguardFunctions()
        {
            SpawnBodyguard();
            deleteBody();
        }

        void SetupMiscFunctions()
        {
            spawnGioele();
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



        void spawnGioele()
        {
            UIMenuItem spawngioele = new UIMenuItem("Gioele Spawn");
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
                        UI.Notify("Unlimite Ammo: ~b~ON");
                       

                        Function.Call(Hash.SET_PED_INFINITE_AMMO_CLIP,Game.Player.Character);
                        //Function.Call(Hash.SET_PED_INFINITE_AMMO,Game.Player.Character.Weapons.Current);
                        

                    }//end true check

                    if (checked_ == false)
                    {
                        Function.Call(Hash.GET_MAX_AMMO_IN_CLIP);
                        UI.Notify("Unlimite Ammo: ~r~OFF");
                        
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

        /*void truenerverwanted()
        {
            Function.Call(Hash.SET_POLICE_IGNORE_PLAYER);

        }*/


        


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
                    Game.Player.Character.Health = -1;
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
            };


        }





        void onTick(object sender, EventArgs e)
        {
            if (modMenuPool != null)
                modMenuPool.ProcessMenus();
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
                vehicleMenu.SetBannerType("scripts\\carBanner.jpg");
                cashMenu.SetBannerType("scripts\\moneyBanner.jpg");
                UI.Notify("Essential Menu v1.0");

            }
        }
    }
}
