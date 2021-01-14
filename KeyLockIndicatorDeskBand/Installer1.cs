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
        private const string PARAM = "TARGETDIR";
        private const string FILE_NAME = "KeyLockIndicatorDeskBand.dll";
        private const string PROGRAM_NAME = @"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\regasm.exe";
        private const string CODE_BASE = " /codebase ";
        private const string UN_REGISTER = " /unregister ";
        public Installer1()
        {
            InitializeComponent();
        }

        private void Installer1_AfterInstall(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = path + FILE_NAME;
            string command = PROGRAM_NAME;
            string args = CODE_BASE + filepath;
            Process.Start(command, args);
        }

        private void Installer1_AfterUninstall(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = path + FILE_NAME;
            string command = PROGRAM_NAME;
            string args = UN_REGISTER + filepath;
            Process.Start(command, args);
        }

        private void Installer1_Committed(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = path + FILE_NAME;
            string command = PROGRAM_NAME;
            string args = CODE_BASE + filepath;
            Process.Start(command, args);
        }

        private void Installer1_AfterRollback(object sender, InstallEventArgs e)
        {
            string path = this.Context.Parameters[PARAM];
            string filepath = path + FILE_NAME;
            string command = PROGRAM_NAME;
            string args = UN_REGISTER + filepath;
            Process.Start(command, args);
        }
    }
}
