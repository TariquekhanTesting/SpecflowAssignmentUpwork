using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;
using System.Configuration;


namespace SeleniumSpecflowUpwork.TestUtilities
{
    class BusinessLib
    {

        public static String getData(int row, int col)
        {
            String value;
        
            excel.Application x1app = new excel.Application();

            excel.Workbook x1Wb = x1app.Workbooks.Open(@ConfigurationManager.AppSettings["TestDataPath"]);       
            excel.Worksheet x1Ws = x1Wb.Sheets[1];
            excel.Range x1range = x1Ws.UsedRange;
         
            value = Convert.ToString(x1range.Cells[row][col].value2);
            x1app.Quit();
            return value;
        }


    }
}
