using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Jaranweb.iTunesAgent.Properties;
using Jaranweb.iTunesAgent.Configuration12;
using log4net;

namespace Jaranweb.iTunesAgent
{
    /// <summary>
    /// Contains methods for managing configuration.
    /// </summary>
    public class ConfigurationHelper
    {
        private static ILog l = LogManager.GetLogger(typeof(ConfigurationHelper));
        /// <summary>
        /// Move configuration from iTA 1.x to 1.2
        /// </summary>
        /// <returns></returns>
        public static bool MovePre12Configuration()
        {
            MessageBox.Show("It seems that you have recently upgraded me to a new "
                + "version. I need to perform some changes to my configuration.\n\nIf you "
                + "have existing configuration from an earlier version, then I will help "
                + "you convert this. Please click 'OK' to continue.",
                "Configuration changes required", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            try
            {
                WriteNewConfiguration();
            }
            catch (Exception ex)
            {
                string message = "I failed to write default configuration to "
                    + MainForm.DATA_PATH + "\\ita-config.xml. I can "
                    + "not continue without this configuration.";
                
                l.Error(message, ex);

                MessageBox.Show(message, "Configuation failure",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return false;
            }

            try
            {
                WriteNewDeviceConfiguration();
            }
            catch (Exception ex)
            {
                string message = "I failed to write default device configuration to "
                    + MainForm.DATA_PATH + "\\device-config.xml.\n\nI can "
                    + "not continue without this configuration.";

                l.Error(message, ex);

                MessageBox.Show(message, "Configuation failure",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return false;
            }



            if (MessageBox.Show("Do you want me to import device configuration you have already set up?\n\nNote: Choosing 'No' will reset application settings to default.", "Move device configuration?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FolderBrowserDialog folders = new FolderBrowserDialog();
                folders.ShowNewFolderButton = false;
                folders.Description = "Please choose the installation folder of your old iTunes Agent installation";

                if (folders.ShowDialog() == DialogResult.OK)
                {
                    string appPath = folders.SelectedPath;

                    // Existing configuration 
                    try
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(Configuration));
                        Configuration oldConfig = (Configuration)deserializer.Deserialize(
                            new XmlTextReader(new StreamReader(appPath + "\\ita-config.xml")));
                        Configuration newConfig = new Configuration();
                        newConfig.ShowNotificationPopups = oldConfig.ShowNotificationPopups;
                        newConfig.UseListFolder = oldConfig.UseListFolder;

                        XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                        XmlTextWriter xtw = new XmlTextWriter(new StreamWriter(MainForm.DATA_PATH
                            + "\\ita-config.xml"));
                        serializer.Serialize(xtw, newConfig);
                        xtw.Close();

                    }
                    catch (Exception ex)
                    {
                        string message = "I was unable to read the old configuration file in " + appPath
                            + ", or write existing configuration to the new location " + MainForm.DATA_PATH
                            + "\\ita-config.xml. I will now exit. You may start me again and try another "
                            + "time, or simply continue using the new default configration.\n\nError was: "
                            + ex.Message;

                        l.Error(message, ex);

                        MessageBox.Show(message,
                            "Failed to locate configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        return false;
                    }

                    // Existing device configuration
                    try
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(DeviceConfiguration));
                        DeviceConfiguration oldConfig = (DeviceConfiguration)deserializer.Deserialize(
                            new XmlTextReader(new StreamReader(appPath + "\\device-config.xml")));
                        DeviceConfiguration newConfig = new DeviceConfiguration();

                        foreach (SyncPattern sp in oldConfig.SyncPatterns)
                            newConfig.AddSyncPattern(sp);

                        foreach (Device d in oldConfig.Devices)
                            newConfig.AddDevice(d);


                        XmlSerializer serializer = new XmlSerializer(typeof(DeviceConfiguration));
                        XmlTextWriter xtw = new XmlTextWriter(new StreamWriter(MainForm.DATA_PATH
                            + "\\device-config.xml"));
                        serializer.Serialize(xtw, newConfig);
                        xtw.Close();

                    }
                    catch (Exception ex)
                    {
                        string message = "I was unable to read the old configuration file in " + appPath
                            + ", or write existing configuration to the new location " + MainForm.DATA_PATH
                            + "\\ita-config.xml. I will now exit. You may start me again and try another "
                            + "time, or simply continue using the new default configration.\n\nError was: "
                            + ex.Message;

                        l.Error(message, ex);

                        MessageBox.Show(message,
                            "Failed to locate configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        return false;
                    }

                
                }            
            }

            // Done. Write file indicating that the upgrade was successful.
            try
            {
                File.Create(MainForm.DATA_PATH + "\\.upgraded_12");
                MessageBox.Show("Application configuration was successfully converted for the new version.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                l.Error(ex);

                MessageBox.Show("I failed to move configuration for the new version. Please try restarting the application.", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return false ;
            }

            return true;
                                
        }

        /// <summary>
        /// Write new device configuration. Since 1.2.
        /// </summary>
        protected static void WriteNewDeviceConfiguration()
        {
            StreamWriter fw = new StreamWriter(MainForm.DATA_PATH + "\\device-config.xml");
            fw.Write(Resources.device_config);
            fw.Flush();
            fw.Close();
        }

        /// <summary>
        /// Write new default configuration. Since 1.2.
        /// </summary>
        /// 
        protected static void WriteNewConfiguration()
        {
            StreamWriter fw = new StreamWriter(MainForm.DATA_PATH + "\\ita-config.xml");
            fw.Write(Resources.ita_config);
            fw.Flush();
            fw.Close();
        }

        /// <summary>
        /// Get the data path to use by the application. The path returned by the runtime 
        /// also contains the version number, but the path should be used without any version 
        /// number.
        /// </summary>
        /// <returns></returns>
        public static String GetAppDataPath()
        {
            string original = Application.UserAppDataPath;
            return original.Substring(0, original.LastIndexOf("\\"));
        }
    }
}
