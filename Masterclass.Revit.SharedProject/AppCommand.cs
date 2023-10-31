using Autodesk.Revit.UI;

using Masterclass.Revit.FirstButton;
using Masterclass.Revit.SecondButton;

using System;
using System.Linq;

namespace Masterclass.Revit
{
    public class AppCommand : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            try
            {
                app.CreateRibbonTab("Masterclass");
            }
            catch (Exception)
            {
                // ignored
            }

            var ribbonPanel = app.GetRibbonPanels("Masterclass").FirstOrDefault(x => x.Name == "Masterclass") ?? app.CreateRibbonPanel("Masterclass", "Masterclass");

            // (Darshan) create buttons
            FirstButtonCommand.CreateButton(ribbonPanel);
            ribbonPanel.AddSeparator();
            SecondButtonCommand.CreateButton(ribbonPanel);

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication app)
        {
            // something that external like sockets open, server setup listening to port you need to discard it here 
            // clean up
            return Result.Succeeded;
        }
    }
}
