using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace 导出Excel
{
    class Program
    {
        [STAThread] 
        static void Main(string[] args)
        {
            
            string fileName = "模板";

            string saveFileName = "";

            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.DefaultExt = "xls";

            saveDialog.Filter = "Excel文件|*.xls";

            saveDialog.FileName = fileName;


            saveDialog.ShowDialog();

            saveFileName = saveDialog.FileName; 

            if (saveFileName.IndexOf(":") < 0) return; //被点了取消

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)

            {

                MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");

                return;

            }

            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;

            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);

            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 

            //写入标题             


            worksheet.Cells[1, 1] = "燃烧吧！三国";

            //写入数值

            //for (int r = 0; r < dataGridView1.Rows.Count; r++)

            //{ for (int i = 0; i < dataGridView1.ColumnCount; i++) 

            //{ 

                worksheet.Cells[2,  1] = "我的意志";
                worksheet.Cells[2, 2] = "绝不销毁！";

            //} 

                System.Windows.Forms.Application.DoEvents();

            //}

            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应

            MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);

           if (saveFileName != "")

           {     

               try 
               {
                   workbook.Saved = true;
                   workbook.SaveCopyAs(saveFileName);  //fileSaved = true;                 
               }                  

               catch (Exception ex)                 
               {                  
                   MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);                  
               }             

           }              

            xlApp.Quit();              

            GC.Collect();//强行销毁  


        }
    }
}
