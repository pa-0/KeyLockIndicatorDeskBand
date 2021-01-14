using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace KeyLockIndicatorDeskBand
{
    [RunInstaller(true)]
    public partial class Installer1 : System.Configuration.Install.Installer
    {
        private const string PARAM = "targetdir";
        private const string FILE_NAME = "KeyLockIndicatorDeskBand.dll";
        private const string PROGRAM_NAME = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm.exe";

        public Installer1()
        {
            InitializeComponent();
        }

        private void Installer1_AfterInstall(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = path + Path.PathSeparator + FILE_NAME;
            string command = PROGRAM_NAME;
            string args = "/codebase " + filepath;
            Process.Start(command, args);
        }

        private void Installer1_AfterUninstall(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = path + Path.PathSeparator + FILE_NAME;
            string command = PROGRAM_NAME;
            string args = "/unregister " + filepath;
            Process.Start(command, args);
        }

        private void Installer1_Committed(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = path + Path.PathSeparator + FILE_NAME;
            string command = PROGRAM_NAME;
            string args = "/codebase " + filepath;
            Process.Start(command, args);
        }

        private void Installer1_AfterRollback(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = path + Path.PathSeparator + FILE_NAME;
            string command = PROGRAM_NAME;
            string args = "/unregister " + filepath;
            Process.Start(command, args);
        }
    }
}
