using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace KeyLockIndicatorDeskBand
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        private const string PARAM = "targetdir";
        private const string FILE_NAME = "KeyLockIndicatorDeskBand.dll";
        private readonly string PROGRAM_NAME = GetFrameworkDirectory() + "regasm.exe";
        private const string UNREGISTER = "/unregister ";
        private const string CODEBASE = "/codebase ";
        private const string BACKSLASH = "\"";
        private const string KeydotNetFolder = @"Software\Microsoft\.NetFramework";
        private const string ROOT_KEY = "InstallRoot";
        private const string Format = @"v{0}.{1}.{2}\";
        
        public Installer1()
        {
            InitializeComponent();
        }

        private void Installer1_AfterInstall(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = BACKSLASH + path + FILE_NAME + BACKSLASH;
            string command = PROGRAM_NAME;
            string args = CODEBASE + filepath;
            MessageBox.Show("AI");
            var process = Process.Start(command, args);
            string info = process.StandardOutput.ReadToEnd();
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AI.txt", info);
            process.Close();
        }

        private void Installer1_AfterUninstall(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = BACKSLASH + path + FILE_NAME + BACKSLASH;
            string command = PROGRAM_NAME;
            string args = UNREGISTER + filepath;
            MessageBox.Show("AU");
            var process = Process.Start(command, args);
            string info = process.StandardOutput.ReadToEnd();
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AU.txt", info);
            process.Close();
        }

        private void Installer1_Committed(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = BACKSLASH + path + FILE_NAME + BACKSLASH;
            string command = PROGRAM_NAME;
            string args = CODEBASE + filepath;
            MessageBox.Show("C");
            var process = Process.Start(command, args);
            string info = process.StandardOutput.ReadToEnd();
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\C.txt", info);
            process.Close();
        }

        private void Installer1_AfterRollback(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = BACKSLASH + path + FILE_NAME + BACKSLASH;
            string command = PROGRAM_NAME;
            string args = UNREGISTER + filepath;
            MessageBox.Show("AR");
            var process = Process.Start(command, args);
            string info = process.StandardOutput.ReadToEnd();
            File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\AR.txt", info);
            process.Close();
        }

        public static string GetFrameworkDirectory()
        {
            // This is the location of the .Net Framework Registry Key
            string framworkRegPath = KeydotNetFolder;

            // Get a non-writable key from the registry
            RegistryKey netFramework = Registry.LocalMachine.OpenSubKey(framworkRegPath, false);

            // Retrieve the install root path for the framework
            string installRoot = netFramework.GetValue(ROOT_KEY).ToString();

            // Retrieve the version of the framework executing this program
            string version = string.Format(Format,
             Environment.Version.Major,
             Environment.Version.Minor,
             Environment.Version.Build);

            // Return the path of the framework
            return System.IO.Path.Combine(installRoot, version);
        }
    }
}
