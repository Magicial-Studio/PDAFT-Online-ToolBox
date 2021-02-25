using System;
using System.Windows.Forms;
using System.Reflection;

namespace PDAFT_Online_ToolBox
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        private static string sVersion;
        public static string Name => "PDAFT Online Toolbox";
        public static bool UpdateCheckedSucceed = false;
        public static bool UnstableVersion = true;
        public static string Version
        {
            get
            {
                if (!string.IsNullOrEmpty(sVersion))
                    return sVersion;

                return sVersion = FixUpVersionString(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            }
        }
        public static string FixUpVersionString( string version )
        {
            while ( version.EndsWith( ".0" ) )
                version = version.Remove( version.Length - 2, 2 );

            if ( !version.Contains( "." ) )
                version += ".0";

            return version;
        }
        [STAThread]
        
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ToolBox());
        }
    }
}
