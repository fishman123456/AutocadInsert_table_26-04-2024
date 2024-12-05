using Autodesk.AutoCAD.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Application = Autodesk.AutoCAD.ApplicationServices.Application;

namespace AutocadInsert_table_26_04_2024
{
    // класс для проверки текущей даты
    public static class CheckDateWork
    {

        public static void CheckDate()
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = DateTime.Parse("20/08/2026");
            Window w1 = new Window();
       
            if (dt1.Date > dt2.Date)
            {
                MessageBox.Show("Your Application is Expire");
                Document doc = Application.DocumentManager.MdiActiveDocument;
                doc.SendStringToExecute(

              "(setvar \"CMDECHO\" 0)" +

              "(command \"_.SAVEAS\" \"\" \"" + "dwgPath2" + "\")" +

              "(setvar \"CMDECHO\" " + "file save" + ")" +

              "(princ) ",

              false,

              false,

              false

            );
                // Выход из проложения добавил 01-01-2024. Чтобы порядок был....
               
                Application.ShowAlertDialog("Autocad Process Kill !!!");
                // закрытие процесса autocad 09-01-2024
                foreach (Process Proc in Process.GetProcesses())
                {
                    if (Proc.ProcessName.Equals("acad"))
                    {
                        Proc.CloseMainWindow();
                        Proc.Kill();
                    }
                }
                //w1.Close();
            }
            else
            {
                //MessageBox.Show("Работайте до   " + dt2.ToString());
            }
        }
    }
}
