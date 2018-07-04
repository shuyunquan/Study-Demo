using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;


namespace 测试控制台
{
    class Program
    {
        static void Main(string[] args)
        {
            #region
            //string fileDir = Environment.CurrentDirectory + "\\模板\\长流陂水厂.xls";
            //FileStream Dir = new FileStream(fileDir, FileMode.Open, FileAccess.Read);     
            //HSSFWorkbook workbook = new HSSFWorkbook(Dir);
            //ISheet sheet = workbook.GetSheet("Sheet1");

            //var row = sheet.GetRow(9);

            //sheet.GetRow(3).GetCell(1).SetCellValue("我");
            //sheet.GetRow(4).GetCell(1).SetCellValue("的");
            //sheet.GetRow(5).GetCell(1).SetCellValue("妈");
            //sheet.GetRow(6).GetCell(1).SetCellValue("呀");
            //sheet.GetRow(7).GetCell(1).SetCellValue("千");
            //sheet.GetRow(8).GetCell(1).SetCellValue("古");
            //sheet.GetRow(9).GetCell(1).SetCellValue("名");
            //sheet.GetRow(3).GetCell(2).SetCellValue("将");

            //sheet.ForceFormulaRecalculation = true;  //强制计算Excel中的公式

            //FileStream file = new FileStream(Environment.CurrentDirectory + $"\\结果\\长流陂水厂{DateTime.Now.ToString("D")}.xls", FileMode.Create);
            //workbook.Write(file);
            //file.Close();
            #endregion


            DateTime dt = DateTime.Now;
            int week = (int)dt.DayOfWeek;

            int t1 = (int)Convert.ToDateTime("2018-06-04").DayOfWeek;
            int t2 = (int)Convert.ToDateTime("2018-06-05").DayOfWeek;
            int t3 = (int)Convert.ToDateTime("2018-06-06").DayOfWeek;
            int t4 = (int)Convert.ToDateTime("2018-06-07").DayOfWeek;
            int t5 = (int)Convert.ToDateTime("2018-06-08").DayOfWeek;
            int t6 = (int)Convert.ToDateTime("2018-06-09").DayOfWeek;
            int t7 = (int)Convert.ToDateTime("2018-06-10").DayOfWeek;

        }
    }
}
