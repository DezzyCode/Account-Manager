using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace Account_Manager.Model
{
    public class UserData
    {
        public User[]? Users { get; set; }
    }

    public class User
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
        public string? SaftyQuest { get; set; }
        public string? SaftyQuestAnswer { get; set; }
        public List<UserSettings>? Settings { get; set; }
        public List<UserDataDetails>? Data { get; set; }
    }

    public class UserSettings
    {
        public string? ProfileImagePath { get; set; }
        public bool ShowGridInfo { get; set; }
        public bool SortAZ { get; set; }
        public string? AutoSavePath { get; set; }
        public string[]? CustomBorderColor { get; set; }
    }

    public class UserDataDetails
    {
        public string? ID { get; set; }
        public string? Application { get; set; }
        public string? AppLink { get; set; }
        public string? AppUsername { get; set; }
        public string? AppPassword { get; set; }
        public string? AppEmail { get; set; }
        public string? AppEmailPassword { get; set; }
        public string? AppInfo { get; set; }
        public string? AppTag { get; set; }
        public string? AppFiles { get; set; }
        public string[]? AppColor { get; set; }
    }

    public class LogedInUser
    {
        private static LogedInUser? instance;

        public static LogedInUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogedInUser();
                }
                return instance;
            }
        }

        public static string? CurrentUser { get; set; }
    }

    public class LogedInUserPassword
    {
        private static LogedInUser? instance;

        public static LogedInUser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogedInUser();
                }
                return instance;
            }
        }

        public static string? CurrentPassword { get; set; }
    }
}
