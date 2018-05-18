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

        UIMenuItem resetWantedLevel;

        public Class1()
        {
            Setup();


            Tick += onTick;
            KeyDown += onKeyDown;
        }

        void Setup()
        {
            modMenuPool = new MenuPool();
            mainMenu = new UIMenu("Mod Menu", "Select An Option");
            modMenuPool.Add(mainMenu);

            playerMenu = modMenuPool.AddSubMenu(mainMenu, "Player Options");
            weaponsMenu = modMenuPool.AddSubMenu(mainMenu, "Weapons Options");
            vehicleMenu = modMenuPool.AddSubMenu(mainMenu, "Vehicles Options");

            SetupPlayerFunctions();
            SetupWeaponFunctions();
            SetupVehicleFuntions();
            
        }

        void SetupPlayerFunctions()
        {
            ResetWantedLevel();
            Godmode();
            neverWanted();
            changeModel();
        }

        void SetupWeaponFunctions()
        {
            WeaponSelectorMenu();
            GetAllWeapons();
        }

        void SetupVehicleFuntions()
        {
            VehicleSelectorMenu();
            VehicleSpawnByName();
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
            UIMenuItem alienItem = new UIMenuItem("Alien");
            UIMenuItem copItem = new UIMenuItem("Cop");
            UIMenuItem rangerItem = new UIMenuItem("Ranger");
            UIMenuItem clayItem = new UIMenuItem("ClayPain");
            UIMenuItem clownItem = new UIMenuItem("Clown");
            UIMenuItem lamarItem = new UIMenuItem("Lamar");
            UIMenuItem jimmyItem = new UIMenuItem("Jimmy");
            UIMenuItem traceyItem = new UIMenuItem("Tracey");
            UIMenuItem ballasItem = new UIMenuItem("Ballas");
            UIMenuItem marineItem = new UIMenuItem("Marine");
            UIMenuItem westonItem = new UIMenuItem("David Weston");
            UIMenuItem cjItem = new UIMenuItem("Fake CJ");
            UIMenuItem bitchItem = new UIMenuItem("Bitch");

            mainModel.AddItem(alienItem);
            mainModel.AddItem(copItem);
            mainModel.AddItem(rangerItem);
            mainModel.AddItem(clayItem);
            mainModel.AddItem(clownItem);
            mainModel.AddItem(lamarItem);
            mainModel.AddItem(jimmyItem);
            mainModel.AddItem(traceyItem);
            mainModel.AddItem(ballasItem);
            mainModel.AddItem(marineItem);
            mainModel.AddItem(westonItem);
            mainModel.AddItem(cjItem);
            mainModel.AddItem(bitchItem);

            mainModel.OnItemSelect += (sender, item, index) =>
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

                if (item == lamarItem)
                {
                    Ped gamePed = Game.Player.Character;
                    Game.Player.ChangeModel(PedHash.LamarDavis);
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
