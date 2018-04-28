using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.Data;
using System.IO;
using System.Text;
using com.force.json;

namespace NPOI导出Excel.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            DataTable table = CreatTable();
            CreateSheet("许嵩", table);
            return View();
        }
        /// <summary>
        /// 创建工作簿
        /// </summary>
        /// <param name="fileName">下载文件名</param>
        /// <param name="dt">数据源</param>
        public static void CreateSheet(string fileName, DataTable dt)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();

            //创建一个名称为Payment的工作表
            ISheet paymentSheet = workbook.CreateSheet("MileageAnalysis");

            //数据源
            DataTable tbPayment = dt;

            //头部标题
            IRow paymentHeaderRow = paymentSheet.CreateRow(0);

            //循环添加标题
            foreach (DataColumn column in tbPayment.Columns)
                paymentHeaderRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);

            // 内容
            int paymentRowIndex = 1;

            foreach (DataRow row in tbPayment.Rows)
            {
                IRow newRow = paymentSheet.CreateRow(paymentRowIndex);

                //循环添加列的对应内容
                foreach (DataColumn column in tbPayment.Columns)
                {
                    newRow.CreateCell(column.Ordinal).SetCellValue(row[column].ToString());
                }

                paymentRowIndex++;
            }

            //列宽自适应，只对英文和数字有效
            for (int i = 0; i <= dt.Rows.Count; i++)
            {
                paymentSheet.AutoSizeColumn(i);
            }
            //获取当前列的宽度，然后对比本列的长度，取最大值
            for (int columnNum = 0; columnNum <= dt.Columns.Count; columnNum++)
            {
                int columnWidth = paymentSheet.GetColumnWidth(columnNum) / 256;
                for (int rowNum = 1; rowNum <= paymentSheet.LastRowNum; rowNum++)
                {
                    IRow currentRow;
                    //当前行未被使用过
                    if (paymentSheet.GetRow(rowNum) == null)
                    {
                        currentRow = paymentSheet.CreateRow(rowNum);
                    }
                    else
                    {
                        currentRow = paymentSheet.GetRow(rowNum);
                    }

                    if (currentRow.GetCell(columnNum) != null)
                    {
                        ICell currentCell = currentRow.GetCell(columnNum);
                        int length = Encoding.Default.GetBytes(currentCell.ToString()).Length;
                        if (columnWidth < length)
                        {
                            columnWidth = length;
                        }
                    }
                }
                paymentSheet.SetColumnWidth(columnNum, columnWidth * 256);
            }

            //将表内容写入流 通知浏览器下载
            workbook.Write(ms);
            System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.xls", fileName));
            System.Web.HttpContext.Current.Response.BinaryWrite(ms.ToArray()); //进行二进制流下在

            workbook = null;
            ms.Close();
            ms.Dispose();
        }

        /// <summary>
        /// 虚拟 DataTable内容
        /// </summary>
        /// <returns></returns>
        public static DataTable CreatTable()
        {

            string json = "{\"total\":8,\"rows\":[{\"VehicleID\":\"粤BY818T\",\"Mileage\":0},{\"VehicleID\":\"粤B594L0\",\"Mileage\":0},{\"VehicleID\":\"粤B8C97M\",\"Mileage\":52718.32},{\"VehicleID\":\"粤B2K52P\",\"Mileage\":109411},{\"VehicleID\":\"粤BKB951\",\"Mileage\":43296.82},{\"VehicleID\":\"粤BW83B7\",\"Mileage\":8711.193},{\"VehicleID\":\"粤BK716T\",\"Mileage\":72072.73},{\"VehicleID\":\"粤B2W6G9\",\"Mileage\":167095.3}]}";

            JSONObject obj = new JSONObject(json);
            int num = obj.GetInt("total");
            JSONArray jArr = obj.GetJSONArray("rows");



            //创建DataTable 将数据库中没有的数据放到这个DT中
            DataTable datatable = new DataTable();
            datatable.Columns.Add("车辆名称", typeof(string));
            datatable.Columns.Add("行驶里程", typeof(string));
            datatable.Columns.Add("时间区间", typeof(string));
            //创建DatatTable 结束---------------------------

            //开始给临时datatable赋值
            for (int i = 0; i < 7; i++)
            {
                JSONObject obj2 = jArr.GetJSONObject(i);
                DataRow row = datatable.NewRow();
                row["车辆名称"] = obj2.GetString("VehicleID");
                //row["行驶里程"] = obj2.GetString("Mileage");
                //row["时间区间"] = "哈哈哈  ";
                datatable.Rows.Add(row);
            }
            return datatable;
        }
    }
}
