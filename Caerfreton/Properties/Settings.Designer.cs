﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18046
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Caerfreton.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Caerfreton.mdf;Integ" +
            "rated Security=True;Connect Timeout=30")]
        public string CaerfretonConnectionString {
            get {
                return ((string)(this["CaerfretonConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=(localdb)\\v11.0;Initial Catalog=\"D:\\DOCUMENTS\\VISUAL STUDIO 2012\\PROJ" +
            "ECTS\\CAERFRETON\\CAERFRETON\\CAERFRETON.MDF\";Integrated Security=True")]
        public string D__DOCUMENTS_VISUAL_STUDIO_2012_PROJECTS_CAERFRETON_CAERFRETON_CAERFRETON_MDFConnectionString {
            get {
                return ((string)(this["D__DOCUMENTS_VISUAL_STUDIO_2012_PROJECTS_CAERFRETON_CAERFRETON_CAERFRETON_MDFConn" +
                    "ectionString"]));
            }
        }
    }
}