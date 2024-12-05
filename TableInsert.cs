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
  
    public class TableInsert
    {
      
        static public void CreateTableIns(List<Data> datas)
        {
            // берем активный документ
            Document doc =
              Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;
            Table tb = new Table();
            // спрашиваем у пользователя куда вставить таблицу
            PromptPointResult pr =
              ed.GetPoint("\nEnter table insertion point: ");
            // если все хорошо создаем обьект таблица
            if (pr.Status == PromptStatus.OK)
            {
                tb.TableStyle = db.Tablestyle;
                tb.NumRows = datas.Count+2;
                tb.NumColumns = 4;
                tb.SetRowHeight(3);
                tb.SetColumnWidth(20);
                tb.Position = pr.Value;


                // создаем массив строк и столбцов
                string[,] str = new string[datas.Count+2, 4];
                str[0, 0] = "Part No.05-12-2024 F";
                str[0, 1] = "Name ";
                str[0, 2] = "Material ";
                str[0, 3] = "Material2 ";
                str[1, 0] = "Поз.";
                str[1, 1] = "Наименование";
                str[1, 2] = "Кол.";
                str[1, 3] = "Примечание";
                int countrow = 2;
                int countcolumn = 0;
                int countPlus = datas.Count + 1;
                foreach (Data data in datas)
                {
                    str[countrow, countcolumn] = data.Poz;
                    str[countrow, countcolumn + 1] = data.Name;
                    str[countrow, countcolumn + 2] = data.Num;
                    str[countrow, countcolumn + 3] = data.Description;
                    countcolumn = 0;
                    countrow++;
                }
                // Use a nested loop to add and format each cell
                for (int i = 0; i < countrow; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        tb.TextHeight(i, j);
                        tb.SetTextString(i, j, str[i, j]);
                        tb.Alignment(i, j);
                    }
                }
                tb.GenerateLayout();

                // открываем транзакцию
                Transaction tr =
                  doc.TransactionManager.StartTransaction();
                using (tr)
                {
                    BlockTable bt =
                      (BlockTable)tr.GetObject(
                        doc.Database.BlockTableId,
                        OpenMode.ForRead
                      );
                    BlockTableRecord btr =
                      (BlockTableRecord)tr.GetObject(
                        bt[BlockTableRecord.ModelSpace],
                        OpenMode.ForWrite
                      );
                    btr.AppendEntity(tb);
                    tr.AddNewlyCreatedDBObject(tb, true);
                    tr.Commit();
                }
            }
        }
    }
}
