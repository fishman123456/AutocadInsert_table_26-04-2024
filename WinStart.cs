using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutocadInsert_table_26_04_2024
{
    public class WinStart
    {

        [CommandMethod("U_83_insertTable")]
        static public void WinS()
        {
            CheckDateWork.CheckDate();
            UserControl1 userControl1 = new UserControl1();
            userControl1.ShowDialog();
            
           
           
        }
    }
}
