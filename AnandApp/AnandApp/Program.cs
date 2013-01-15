using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text;
using White.Core;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using System.Threading;
using White.Core.UIItems.Finders;
using White.Core.Factory;
using System.Diagnostics;
using White.Core.UIItems.TableItems;
using White.Core.InputDevices;


namespace AnandApp
{
    class Program
    {
        private TableRow row;
        private Table table;
        static void Main(string[] args)
        {
            string FilePatha = "C:\\Program Files (x86)\\Default Company Name\\AnandTool\\DropDownProject.exe";
            string exeParameters = "";
            Process process = new Process();
            process.StartInfo.FileName = FilePatha;
            process.StartInfo.Arguments = exeParameters;
            process.Start();
            Application app = Application.Attach(process);
            Thread.Sleep(6000);
            Window BunkerLiftingDialog = app.GetWindow(SearchCriteria.ByAutomationId("xtrDataEntry"), InitializeOption.NoCache);
            BunkerLiftingDialog.Focus();
            string WindowTitle = BunkerLiftingDialog.Name.ToString();
            Console.WriteLine(WindowTitle);
            Program appInstance = new Program();
            appInstance.EditBoxEnter(BunkerLiftingDialog, "txtShow", "Test Text");
            appInstance.getGridData(BunkerLiftingDialog);
            
        }
        public void EditBoxEnter(Window win, string Textboxname, string val)
        {
            TextBox TextObj = win.Get<TextBox>(SearchCriteria.ByAutomationId(Textboxname));
            White.Core.InputDevices.AttachedKeyboard keyboard = win.Keyboard;
            if (TextObj != null)
            {
                TextObj.Focus();
                TextObj.RaiseClickEvent();
// below line fails
                keyboard.Enter("Harriet");
// even below commented line fails
                //TextObj.Enter(val);
                //TextObj.BulkText = "My simple Text";
                //Keyboard.Instance.Enter("my simple");
                string aa = TextObj.Text;
                Console.WriteLine(aa + " - Value Entered in Textbox");
               
            }
        }


            public void getGridData(Window win)
            {
            Thread.Sleep(1000);
             table = win.Get<Table>(SearchCriteria.ByAutomationId("grdDisplay"));
            TableRows rows = table.Rows;
            row = rows[0];
// below line fails even though it is identified in Spy
            TableCell cell = row.Cells[0];
            String ab = cell.Value.ToString();
            Console.WriteLine(ab + " Cell Data");
            Console.ReadLine();
            }

        

    }
}

