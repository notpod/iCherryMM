﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notpod.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Notpod.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static System.Drawing.Bitmap aboutimg {
            get {
                object obj = ResourceManager.GetObject("aboutimg", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;DeviceConfiguration xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///  &lt;SyncPatterns&gt;
        ///    &lt;SyncPattern&gt;
        ///      &lt;Identifier&gt;itunes-style&lt;/Identifier&gt;
        ///      &lt;Name&gt;iTunes&lt;/Name&gt;
        ///      &lt;Pattern&gt;%ARTIST%\%ALBUM%\%TRACKNUMSPACE%%NAME%&lt;/Pattern&gt;
        ///      &lt;Description&gt;This pattern places the tracks the same way iTunes places tracks in a managed iTunes music folder. Files are organized by Artist\Album\TrackNumber Name. This [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string device_config {
            get {
                return ResourceManager.GetString("device_config", resourceCulture);
            }
        }
        
        internal static System.Drawing.Bitmap exit {
            get {
                object obj = ResourceManager.GetObject("exit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap help {
            get {
                object obj = ResourceManager.GetObject("help", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;Configuration xmlns:xsi=&quot;http://www.w3.org/2001/XMLSchema-instance&quot; xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
        ///  &lt;ShowNotificationPopups&gt;true&lt;/ShowNotificationPopups&gt;
        ///  &lt;UseListFolder&gt;true&lt;/UseListFolder&gt;
        ///  &lt;CloseSyncWindowOnSuccess&gt;true&lt;/CloseSyncWindowOnSuccess&gt;
        ///&lt;/Configuration&gt;.
        /// </summary>
        internal static string ita_config {
            get {
                return ResourceManager.GetString("ita_config", resourceCulture);
            }
        }
        
        internal static System.Drawing.Icon ita_new {
            get {
                object obj = ResourceManager.GetObject("ita_new", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot; ?&gt;
        ///&lt;log4net&gt;  
        ///  &lt;appender name=&quot;DebugFile&quot; type=&quot;log4net.Appender.FileAppender&quot;&gt;
        ///    &lt;file value=&quot;debug.log&quot; /&gt;
        ///    &lt;appendToFile value=&quot;true&quot; /&gt;
        ///
        ///    &lt;layout type=&quot;log4net.Layout.PatternLayout&quot;&gt;
        ///      &lt;conversionPattern value=&quot;%5level [%thread] (%logger:%line) - %message%newline&quot; /&gt;
        ///    &lt;/layout&gt;
        ///  &lt;/appender&gt;
        ///
        ///  &lt;root&gt;
        ///    &lt;level value=&quot;DEBUG&quot; /&gt;
        ///    &lt;appender-ref ref=&quot;DebugFile&quot; /&gt;
        ///  &lt;/root&gt;
        ///&lt;/log4net&gt;.
        /// </summary>
        internal static string logging {
            get {
                return ResourceManager.GetString("logging", resourceCulture);
            }
        }
    }
}
