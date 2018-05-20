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
        MenuPool modMenuPool;
        UIMenu mainMenu;

        UIMenu playerMenu;
        UIMenu weaponsMenu;
        UIMenu vehicleMenu;
        UIMenu bodyguardMenu; 

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
            bodyguardMenu = modMenuPool.AddSubMenu(mainMenu, "Bodyguard Menu");

            SetupPlayerFunctions();
            SetupWeaponFunctions();
            SetupVehicleFuntions();
            SetupBodyguardFunctions();
            
        }

        void SetupPlayerFunctions()
        {
            ResetWantedLevel();
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
        }

        void SetupVehicleFuntions()
        {
            VehicleSelectorMenu();
            VehicleSpawnByName();
        }

        void SetupBodyguardFunctions()
        {
            SpawnBodyguard();
            deleteBody();
        }


        
        


        void ResetWantedLevel()
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
            var checkbox = new UIMenuCheckboxItem("Reset Wanted Level", checkbox2, "The police ignore you");
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
           

        void changeModel()
        {
            UIMenu mainModel = modMenuPool.AddSubMenu(playerMenu, "Model Changer");
            UIMenuItem outfitsrandom = new UIMenuItem("~b~Randomize Outfits");
            UIMenuItem alienItem = new UIMenuItem("Alien");
            UIMenuItem copItem = new UIMenuItem("Cop");
            UIMenuItem rangerItem = new UIMenuItem("Ranger");
            UIMenuItem clayItem = new UIMenuItem("ClayPain");
            UIMenuItem clownItem = new UIMenuItem("Clown");
            UIMenuItem jesusItem = new UIMenuItem("Jesus");
            UIMenuItem catItem = new UIMenuItem("Cat");
            UIMenuItem formageItem = new UIMenuItem("Cris Formage");
            UIMenuItem ballasItem = new UIMenuItem("Ballas");
            UIMenuItem marineItem = new UIMenuItem("Marine");
            UIMenuItem fbiItem = new UIMenuItem("FBI Man");
            UIMenuItem superItem = new UIMenuItem("Superman");
            UIMenuItem cjItem = new UIMenuItem("Fake CJ");
            UIMenuItem zombieItem = new UIMenuItem("Zombie");

            mainModel.AddItem(outfitsrandom);
            mainModel.AddItem(alienItem);
            mainModel.AddItem(copItem);
            mainModel.AddItem(rangerItem);
            mainModel.AddItem(clayItem);
            mainModel.AddItem(clownItem);
            mainModel.AddItem(jesusItem);
            mainModel.AddItem(catItem);
            mainModel.AddItem(formageItem);
            mainModel.AddItem(ballasItem);
            mainModel.AddItem(marineItem);
            mainModel.AddItem(fbiItem);
            mainModel.AddItem(superItem);
            mainModel.AddItem(cjItem);
            mainModel.AddItem(zombieItem);

            mainModel.OnItemSelect += (sender, item, index) =>
            {

                    if (item == outfitsrandom)
                    {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.Character.RandomizeOutfit();
                    }

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

                    if (item == catItem)
                    {
                        Ped gamePed = Game.Player.Character;
                        Game.Player.ChangeModel(PedHash.Cat);
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
            };

        }

        void KillPlayerMenu()
        {
            KillPlayerItem = new UIMenuItem("Kill Yourself","You can die :(");
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
            UIMenuItem body2lItem = new UIMenuItem("~b~HandGuns");
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
            UIMenuItem body3Item = new UIMenuItem("~b~Machine Guns");
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
            UIMenuItem body4Item = new UIMenuItem("~b~Assault Riffle");
            UIMenuItem assaultriffleItem = new UIMenuItem("Assault Riffle");
            UIMenuItem assaultrifflemk2Item = new UIMenuItem("Assault RIffle Mk2");
            UIMenuItem carabineriffleItem = new UIMenuItem("Carabine");
            UIMenuItem carabinerifflemk2Item = new UIMenuItem("Carabine Mk2");
            UIMenuItem advancedriffleItem = new UIMenuItem("Advanced Riffle");
            UIMenuItem specialcarabineItem = new UIMenuItem("Special Carabine");
            UIMenuItem bullpupriffleItem = new UIMenuItem("Bullpup Riffle");
            UIMenuItem compactriffleItem = new UIMenuItem("Compact Riffle");

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
            };


        }





        void onTick(object sender, EventArgs e)
        {
            if (modMenuPool != null)
                modMenuPool.ProcessMenus();
        }

        void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z && !modMenuPool.IsAnyMenuOpen())
            {
                mainMenu.Visible = !mainMenu.Visible;
            }
        }
    }
}
