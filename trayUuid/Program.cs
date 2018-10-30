using System;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;

namespace trayUuid
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NotifyIcon niIcon = new NotifyIcon();
            niIcon.Icon = (Icon)trayUuid.ResourceManager.GetObject("TrayUuidIcon");
            niIcon.Text = "UUID Generator";

            ContextMenu mnuContext = new ContextMenu();

            MenuItem mnuRegFormat = new MenuItem("Clipboard: UUID in &registry format {xxxxxxxx-xxxx...}", new EventHandler(evHandler_GenerateUuid_RegistryFormat)); mnuContext.MenuItems.Add(mnuRegFormat);
            MenuItem mnuRegIGuard = new MenuItem("Clipboard: UUID C &header inclusion guard", new EventHandler(evHandler_GenerateUuid_CInclusionGuard)); mnuContext.MenuItems.Add(mnuRegIGuard);
            MenuItem mnuRegIGuard2 = new MenuItem("Clipboard: UUID &C header inclusion guard with extern C", new EventHandler(evHandler_GenerateUuid_CInclusionGuard_WithExtern)); mnuContext.MenuItems.Add(mnuRegIGuard2);
            MenuItem mnuExit = new MenuItem("&Exit", new EventHandler(evHandler_ClickExit)); mnuContext.MenuItems.Add(mnuExit);

            niIcon.ContextMenu = mnuContext;
            niIcon.Visible = true;

            Application.Run();

            niIcon.Visible = false;
        }

        private static void evHandler_ClickExit(object Sender, EventArgs e)
        {
            Application.Exit();
        }

        private static void evHandler_GenerateUuid_RegistryFormat(object Sender, EventArgs e)
        {
            Guid gNew = Guid.NewGuid();
            String strGuid = "{" + gNew.ToString() + "}";

            Clipboard.SetText(strGuid);
        }
        private static void evHandler_GenerateUuid_CInclusionGuard(object Sender, EventArgs e)
        {
            Guid gNew = Guid.NewGuid();
            String strGuid = gNew.ToString();
            strGuid = strGuid.Replace("-", "_");
            String strGuard = "#ifndef __is_included__" + strGuid + "\r\n#define __is_included__" + strGuid + "\r\n\r\n\r\n#endif /* __is_included__"+strGuid+" */\r\n\r\n";

            Clipboard.SetText(strGuard);
        }

        private static void evHandler_GenerateUuid_CInclusionGuard_WithExtern(object Sender, EventArgs e)
        {
            Guid gNew = Guid.NewGuid();
            String strGuid = gNew.ToString();
            strGuid = strGuid.Replace("-", "_");
            String strGuard = "#ifndef __is_included__" + strGuid + "\r\n#define __is_included__" + strGuid + "\r\n" +
                "\r\n#ifdef __cplusplus\r\n\textern \"C\" {\r\n#endif\r\n\r\n" +
                "\r\n\r\n#ifdef __cplusplus\r\n\t} /* extern \"C\" */\r\n#endif\r\n"+
                "\r\n\r\n#endif /* __is_included__" + strGuid + " */\r\n\r\n";

            Clipboard.SetText(strGuard);
        }
    }
}
