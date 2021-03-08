using lean.UI.Helpers.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lean.UI.Services.Config
{
    public class SettingsConfig
    {
        public static void RegisterConfigurations()
        {
            //var settings = IOHelper.ReadFile(MyConstants.AppSettingsPath.MapPath());
            //if (!string.IsNullOrEmpty(settings))
            //{
            //    var configurationMapper = JsonConvert.DeserializeObject<ConfigurationMapper>(settings);
            //    //maintenance
            //    Configurations.IsMaintenance = configurationMapper.IsMaintenance;
            //    Configurations.EmailConfigurations_UseGodaddySmtpClient = configurationMapper.EmailConfigurations.UseGodaddySmtpClient;
            //    Configurations.EmailConfigurations_Email = configurationMapper.EmailConfigurations.UseGodaddySmtpClient
            //        ? configurationMapper.EmailConfigurations.ProfessionalEmail
            //        : configurationMapper.EmailConfigurations.Email;
            //    Configurations.EmailConfigurations_To = configurationMapper.EmailConfigurations.To;
            //    Configurations.EmailConfigurations_Password = configurationMapper.EmailConfigurations.Password;
            //}
        }
    }
}