using System.IO;
using System.Linq;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using SimpleLogger;

namespace Patcher2
{
    public static class PathScanner
    {
        public static string GetRADS()
        {
            Logger.Log("Looking for RADS directory..");

            var v1 = RiotGamesReg();
            Logger.Log($"RiotGamesReg: {v1} (exists: {Directory.Exists(v1)})");
            if (Directory.Exists(v1))
            {
                Logger.Log("Success!");
                return v1;
            }

            var v2 = RiotGamesIncReg();
            Logger.Log($"RiotGamesIncReg: {v2} (exists: {Directory.Exists(v2)})");
            if (Directory.Exists(v2))
            {
                Logger.Log("Success!");
                return v2;
            }

            var v3 = AskUser();
            Logger.Log($"AskUser: {v3} (exists: {Directory.Exists(v3)})");
            if (Directory.Exists(v3))
            {
                Logger.Log("Success!");
                return v3;
            }

            Logger.Log("Failed to locate RADS directory");
            return null;
        }

        private static string RiotGamesReg()
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Riot Games\RADS");
            if (reg == null)
            {
                return null;
            }
            
            return (string)reg.GetValue("LocalRootFolder");
        }

        private static string RiotGamesIncReg()
        {
            var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Riot Games, Inc\League of Legends");
            if (reg == null)
            {
                return null;
            }

            return (string)reg.GetValue("Location") + @"\RADS";
        }

        private static string AskUser()
        {
            // Init.
            var openFileDialog = new CommonOpenFileDialog
            {
                IsFolderPicker = true,
                Multiselect = false,
                Title = "Select League of Legends folder",
            };

            // Show
            var result = openFileDialog.ShowDialog();

            // File got selected
            if (result == CommonFileDialogResult.Ok)
            {
                var directory = openFileDialog.FileName;
                return directory + @"\RADS"; ;
            }
            else
            {
                return null;
            }
        }

        public static string GetEXE(string RADS)
        {
            Logger.Log("Looking for EXE file..");

            var releases = Path.Combine(RADS, @"solutions\lol_game_client_sln\releases");

            // bad
            Logger.Log($"releases: {releases} (exists: {Directory.Exists(releases)})");
            if (!Directory.Exists(releases))
            {
                Logger.Log("Failed to locate EXE file");
                return null;
            }

            var di = new DirectoryInfo(releases);
            var subDirs = di.GetDirectories().Select(d => d.Name).ToArray();
            var verDir = GetNewest(subDirs);
            var path = Path.Combine(releases, verDir, @"deploy\League of Legends.exe");

            Logger.Log($"EXE: {path} (exists: {File.Exists(path)})");
            if (!File.Exists(path))
            {
                Logger.Log("Failed to locate EXE file");
                return null;
            }

            Logger.Log("Success!");
            return path;
        }

        private static string GetNewest(string[] versions)
        {
            var highest = versions.First();

            for (var i = 1; i < versions.Length; i++)
            {
                var hs = highest.Split('.');
                var cs = versions[i].Split('.');

                for (var j = 0; j < cs.Length; j++)
                {
                    var hv = int.Parse(hs[j]);
                    var cv = int.Parse(cs[j]);

                    if (cv > hv)
                    {
                        highest = versions[i];
                        break;
                    }
                }
            }

            return highest;
        }
    }
}
