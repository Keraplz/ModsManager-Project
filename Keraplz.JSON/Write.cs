using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

using Newtonsoft.Json;

namespace Keraplz.JSON
{
    public class Write
    {
        public static int n = 0;
        //static string typeer;
        static string pather;

        static Boolean oneuse = true;
        static string typefi;
        static string filepathfi;
        static string filenamefi;

        //public static void WriteJSON(string input_type, string input_filepath, IList<string> input_files)
        //{
        //    try
        //    {
        //        if (input_files == null || input_files.Count == 0) { }
        //        else
        //        {
        //            Base.Define SR_Files = new Base.Define
        //            {
        //                type = input_type,
        //                filepath = input_filepath,
        //                files = input_files
        //            };
        //
        //            // serialize JSON directly to a file
        //            using (StreamWriter file = File.CreateText("ModsManager/json/ListedXNB.json"))
        //            {
        //                JsonSerializer serializer = new JsonSerializer();
        //                serializer.Formatting = Formatting.Indented;
        //                serializer.Serialize(file, SR_Files);
        //                file.Close();
        //            }
        //
        //            input_files.Clear();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error found in Keraplz.JSON.Write.WriteJSON");
        //    }
        //}
        public static void WriteJSON(String input_type, String input_filepath, IList<String> input_files, String json_filename)
        {
            try
            {
                //setType(input_type);
                setPath(input_filepath);

                using (StreamWriter sw = File.AppendText("ModsManager/_logs/writer.txt"))
                {
                    sw.WriteLine((n + 1).ToString("0000") + " - " + input_filepath + "  =>  " + pather);
                }

                n = n + 1;

                if (input_files == null || input_files.Count == 0) { }
                else
                {
                    if (oneuse)
                    {
                        typefi = input_type;
                        filepathfi = input_filepath;
                        filenamefi = json_filename;

                        oneuse = false;
                    }

                    Base.SpeedRunners SR_Files = new Base.SpeedRunners
                    {
                        Type = input_type,
                        Filepath = input_filepath,
                        Files = input_files
                    };

                    string FLjson;

                    if (json_filename.EndsWith(".json")) FLjson = json_filename;
                    else FLjson = json_filename + ".json";

                    if (!Directory.Exists("ModsManager/_content/" + pather))
                        Directory.CreateDirectory("ModsManager/_content/" + pather);

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText("ModsManager/_content/" + pather + "/" + FLjson))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, SR_Files);
                        file.Close();
                    }

                    input_files.Clear();
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    sw.WriteLine("Error found in Keraplz.JSON.Write.WriteJSON(" + typefi + ", " + filepathfi + ", " + "IList<string>" + ", " + filenamefi + ")");
                    sw.WriteLine(e.Message);
                }
            }
        }

        public static void ModDefinion(String json_filename, IList<String> input_pathfiles)
        {
            try
            {
                if (input_pathfiles == null || input_pathfiles.Count == 0) { }
                else
                {
                    Base.Mods SR_Mods = new Base.Mods
                    {
                        Installed = false,
                        Type = Base.toLabel_modType,
                        Author = Base.toLabel_modAuthor,
                        Description = Base.toLabel_modDescription,
                        Content = input_pathfiles
                    };

                    // serialize JSON directly to a file
                    using (StreamWriter file = File.CreateText("mods/" + json_filename + ".json"))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Formatting = Formatting.Indented;
                        serializer.Serialize(file, SR_Mods);
                        file.Close();
                    }

                    input_pathfiles.Clear();
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    sw.WriteLine("Error found in Keraplz.JSON.Write.ModDefinion(" + json_filename + ", " + "IList<string>" + ")");
                    sw.WriteLine(e.Message);
                }
            }
        }
        public static void ModDefinion_edit_installed(String json_filename, Boolean input_isInstalled)
        {
            try
            {
                Base.Mods SR_Mods = new Base.Mods
                {
                    Installed = input_isInstalled,
                    Type = Read.mods_GetType(json_filename),
                    Author = Read.mods_GetAuthor(json_filename),
                    Description = Read.mods_GetDescription(json_filename),
                    Content = Read.mods_GetContent(json_filename)
                };

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText("mods/" + json_filename + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, SR_Mods);
                    file.Close();
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    sw.WriteLine("Error found in Keraplz.JSON.Write.ModDefinion_edit_installed(" + json_filename + ", " + input_isInstalled.ToString() + ")");
                    sw.WriteLine(e.Message);
                }
            }
        }

        public static void Configuration(Boolean input_firsttimesetup, String json_filename/*, IList<String> input_pathfiles*/)
        {
            try
            {
                //if (input_pathfiles == null || input_pathfiles.Count == 0) { }
                //else
                //{
                IList<String> input_mods = new List<String>();
                IList<String> input_lastbackup = new List<String>();
                string dt = (DateTime.Now.Minute + "/" + DateTime.Now.Hour + "/" + DateTime.Now.DayOfYear).ToString();

                foreach (string s in Directory.GetFiles("mods", "*.json"))
                {
                    input_mods.Add(s);
                    input_lastbackup.Add(Path.GetFileNameWithoutExtension(s) + @""": """ + dt);
                }

                Base.Configuration ManagerConfig = new Base.Configuration
                {
                    CurrentBuild = File.ReadLines(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/SpeedRunnersLog.txt").First().Split('(', ')')[1],
                    Mods = input_mods,
                    FirstTimeSetup = input_firsttimesetup,
                    LastBackup = input_lastbackup
                };

                // serialize JSON directly to a file
                using (StreamWriter file = File.CreateText(json_filename))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Formatting = Formatting.Indented;
                    serializer.Serialize(file, ManagerConfig);
                    file.Close();
                }

                //input_pathfiles.Clear();
                //}
            }
            catch (Exception e)
            {
                using (StreamWriter sw = File.AppendText("ModsManager/_logs/errorlog.txt"))
                {
                    sw.WriteLine("Error found in Keraplz.JSON.Write.Configuration()");
                    sw.WriteLine(e.Message);
                }
            }
        }

        private static void setPath(string path)
        {
            if (path.EndsWith("Audio/") || path.EndsWith("Audio"))
            {
                pather = "Audio";
            }
            else if (path.EndsWith("Backgrounds/") || path.EndsWith("Backgrounds"))
            {
                pather = "Backgrounds";
            }
            else if (path.EndsWith("CEngine/") || path.EndsWith("CEngine"))
            {
                pather = "CEngine";
            }
            else if (path.EndsWith("Characters/") || path.EndsWith("Characters"))
            {
                pather = "Characters";
            }
            else if (path.EndsWith("Comics/") || path.EndsWith("Comics"))
            {
                pather = "Comics";
            }
            else if (path.EndsWith("Levels/") || path.EndsWith("Levels"))
            {
                pather = "Levels";
            }
            else if (path.EndsWith("Localisation/") || path.EndsWith("Localisation"))
            {
                pather = "Localisation";
            }
            else if (path.EndsWith("Shaders/") || path.EndsWith("Shaders"))
            {
                pather = "Shaders";
            }
            else if (path.EndsWith("Sprites/") || path.EndsWith("Sprites"))
            {
                pather = "Sprites";
            }
            else if (path.EndsWith("Tiles/") || path.EndsWith("Tiles"))
            {
                pather = "Tiles";
            }
            else if (path.EndsWith("UI/") || path.EndsWith("UI"))
            {
                pather = "UI";
            }
            else if (Path.GetDirectoryName(path).Length >= 10)
            {
                string helper = Path.GetDirectoryName(path);
                pather = helper.Remove(0, 8);
            }
            else { /*Console.WriteLine(" Ignored path => " + path);*/ }
        }
        //private static void setType(string type)
        //{
        //    if (
        //        type == "UI" ||
        //        type == "Common" ||
        //        type == "Countdown" ||
        //        type == "Font" ||
        //        type == "Passports" ||
        //        type == "Replays" ||
        //        type == "Ingame" ||
        //        type == "LoadingScreens" ||
        //        type == "LocalMultiplayer" ||
        //        type == "ESLTakeover" ||
        //        type == "KingOfSpeed" ||
        //        type == "KingOfSpeedPromo" ||
        //        type == "LevelEditorContest" ||
        //        type == "ScoutPromo" ||
        //        type == "SpeedRunners" ||
        //        type == "MainMenu" ||
        //        type == "Progression" ||
        //        type == "MultiplayerHUD" ||
        //        type == "Chat" ||
        //        type == "LevelSelect" ||
        //        type == "Lobby" ||
        //        type == "MultiplayerMenu" ||
        //        type == "OptionsMenu" ||
        //        type == "Popup" ||
        //        type == "Roulette" ||
        //        type == "WinScreen" ||
        //        type == "SingleplayerHUD" ||
        //        type == "Start" ||
        //        type == "Story" ||
        //        type == "StoryLevelSelect" ||
        //        type == "SuddenDeath" ||
        //        type == "TrailEditor" ||
        //        type == "WorkshopMenu"
        //        )
        //    {
        //        typeer = "UI";
        //    }
        //    else if (
        //        type == "Sprites" ||
        //        type == "Bookcase" ||
        //        type == "Boss" ||
        //        type == "Airport" ||
        //        type == "Casino" ||
        //        type == "Factory" ||
        //        type == "Festival" ||
        //        type == "Library" ||
        //        type == "Mansion" ||
        //        type == "Metro" ||
        //        type == "NightClub" ||
        //        type == "Plaza" ||
        //        type == "Powerplant" ||
        //        type == "Resort" ||
        //        type == "Ship" ||
        //        type == "Silo" ||
        //        type == "Ski" ||
        //        type == "ThemePark" ||
        //        type == "Zoo" ||
        //        type == "Deco"
        //        )
        //    {
        //        typeer = "Sprites";
        //    }
        //    else if (type == "Tiles")
        //    {
        //        typeer = "Tiles";
        //    }
        //    else if (type == "Shaders")
        //    {
        //        typeer = "Shaders";
        //    }
        //    else if (type == "Localisation")
        //    {
        //        typeer = "Localisation";
        //    }
        //    else if (type == "Comics")
        //    {
        //        typeer = "Comics";
        //    }
        //    else if (
        //        type == "Characters" ||
        //        type == "BeachBodySpeedrunner" ||
        //        type == "Buckshot" ||
        //        type == "Burger" ||
        //        type == "CinnamonToastKen" ||
        //        type == "Cosmonaut" ||
        //        type == "DoctorSmart" ||
        //        type == "Dodger" ||
        //        type == "Excel" ||
        //        type == "Falcon" ||
        //        type == "Flamenco" ||
        //        type == "FortKnight" ||
        //        type == "GangBeast" ||
        //        type == "Gil" ||
        //        type == "Hothead" ||
        //        type == "Jailbird" ||
        //        type == "JesseCox" ||
        //        type == "Loading" ||
        //        type == "Lucjadore" ||
        //        type == "ManekiNeko" ||
        //        type == "Markiplier" ||
        //        type == "Moonraker" ||
        //        type == "MrQuick" ||
        //        type == "Octodad" ||
        //        type == "Payday" ||
        //        type == "PeanutButterGamer" ||
        //        type == "PewDiePie" ||
        //        type == "Salem" ||
        //        type == "Scout" ||
        //        type == "SherlockBones" ||
        //        type == "SkullDuggery" ||
        //        type == "Speedrunner" ||
        //        type == "Strippin" ||
        //        type == "SummertimeCosmonaut" ||
        //        type == "UberHaxorNova" ||
        //        type == "Unic" ||
        //        type == "VelociTrex" ||
        //        type == "XL"
        //        )
        //    {
        //        typeer = "Characters";
        //    }
        //    else if (
        //        type == "Debug" ||
        //        type == "Localisation" ||
        //        type == "CEngine"
        //        )
        //    {
        //        typeer = "CEngine";
        //    }
        //    else if (
        //        type == "ENV_Airport" ||
        //        type == "ENV_Area1" ||
        //        type == "ENV_Area2" ||
        //        type == "ENV_Area3" ||
        //        type == "ENV_AreaVR" ||
        //        type == "ENV_Casino" ||
        //        type == "ENV_Mansion" ||
        //        type == "ENV_NightClub" ||
        //        type == "ENV_Prototype" ||
        //        type == "ENV_Ship" ||
        //        type == "ENV_Ski" ||
        //        type == "ENV_ThemePark" ||
        //        type == "ENV_Zoo" ||
        //        type == "Backgrounds"
        //        )
        //    {
        //        typeer = "Backgrounds";
        //    }
        //    else if (
        //        type == "Music" ||
        //        type == "Sfx" ||
        //        type == "Actors" ||
        //        type == "Ambient" ||
        //        type == "Player" ||
        //        type == "Retro" ||
        //        type == "Stingers" ||
        //        type == "UI" ||
        //        type == "Weapons" ||
        //        type == "Ingame" ||
        //        type == "Menu" ||
        //        type == "Postgame" ||
        //        type == "Roulette" ||
        //        type == "Audio"
        //        )
        //    {
        //        typeer = "Audio";
        //    }
        //}

        //private static void helper(IList<string> input_type, IList<string> input_filepath)
        //{
        //    for (int n = 0; n < input_type.Count() + 1; n++)
        //    {
        //        string typeer = input_type[n];
        //        for (int m = 0; m < input_type.Count() + 1; m++)
        //        {
        //            string fileer = input_type[m];
        //            Base.Define SR_Files = new Base.Define
        //            {
        //                type = typeer,
        //                filepath = fileer,
        //            };
        //        }
        //    }
        //}

    }
}