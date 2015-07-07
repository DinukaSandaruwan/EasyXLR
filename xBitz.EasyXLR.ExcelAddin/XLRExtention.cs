using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using xBitz.EasyXLR.ExcelAddin.BL;
using Excel = Microsoft.Office.Interop.Excel;

namespace xBitz.EasyXLR.ExcelAddin
{
    public class XLRExtention
    {
        DataTable _tbl = new DataTable();
        int RowCount, ColumnCount;

        public static void Refresh()
        {
            XLRDataSource DS = ThisAddIn.datasource[0];
            DataHandler dt = new DataHandler();
            DS.ReFresh(dt.RefreshDataSource());
        }

        /// <summary>
        /// make this sington F2 dev required 
        /// </summary>
        /// <returns></returns>
        public static Excel.Application GetExcelApplicationInstance()
        {
            Excel.Application instance = null;
            try
            {
                instance = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            }
            catch (Exception ex)
            {
                instance = new Excel.Application();
            }
            return instance;
        }

        public static bool IsWorkbookOpen(Excel.Application xlapp, string WBfilepath)
        {
            if (xlapp == null)
                throw new Exception("ExcelFunc.IsExcelWBOpen2: Null-valued application instance");

            var wbs = (Excel.Workbooks)xlapp.Workbooks;
            try
            {                
                foreach (var wbook in wbs)
                {
                    if (WBfilepath == ((Excel.Workbook)wbook).FullName)
                        return true;
                }
            }
            catch
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Get Current WorkBook 
        /// </summary>
        /// <param name="xlapp"></param>
        /// <param name="filepath"></param>
        /// <returns></returns>

        public static Excel.Workbook GetWorkBook(Excel.Application xlapp, string filepath)
        {

            Excel.Workbook wb;

            if (!IsWorkbookOpen(xlapp, filepath))
            {
                wb = (Excel.Workbook)xlapp.Workbooks.Open(filepath, Type.Missing, ReadOnly: false);
            }
            else
            {
                string fileName = System.IO.Path.GetFileName(filepath);
                wb = xlapp.Workbooks.get_Item(fileName);
            }
            return wb;
        }

        //public static DataTable ReadDataTableFromRange(Excel.Range range, MetaData md = null)
        //{
        //    Excel.Worksheet wsheet = null;
        //    Excel.Range xrange = null;

        //    // get worksheet from rage
        //    wsheet = (Excel.Worksheet)range.Worksheet;
        //    // init variables
        //    DataTable tbl = new DataTable();
        //    object CellValue;
        //    string fieldname;
        //    FieldType ftype;

        //    // read column names from header line into DataTable
        //    // assign data types to columns (i.e. other than object) if MetaData is not null
        //    for (int i = 0; i < range.Columns.Count; i++)
        //    {
        //        // all field names are stored in small letters in MetaData
        //        fieldname = ((string)range.Cells[1, i + 1].Value2).ToLower();

        //        if (md == null)     // return a object-typed DataTable
        //            tbl.Columns.Add(fieldname.ToString(), typeof(object));

        //        else   // return a strongly typed DataTable
        //        {
        //            ftype = MetaData.GetFieldType(md, fieldname);

        //            switch (ftype)
        //            {
        //                case FieldType.TextAttribute:
        //                    tbl.Columns.Add(fieldname, typeof(string));
        //                    break;
        //                case FieldType.IntegerAttribute:
        //                    tbl.Columns.Add(fieldname, typeof(int));
        //                    break;
        //                case FieldType.DateAttribute:
        //                    tbl.Columns.Add(fieldname, typeof(DateTime));
        //                    break;
        //                case FieldType.KeyFigure:
        //                    tbl.Columns.Add(fieldname, typeof(double));
        //                    break;
        //                default:
        //                    throw new Exception("Field name '" + fieldname + "' is not defined in meta data!");
        //            }
        //        }
        //    }
        //    string sval = "EMPTY";
        //    int ival = 0;
        //    double dval = 0.0;

        //    // read cell values row by row
        //    for (int i = 0; i < range.Rows.Count - 1; i++)
        //    {
        //        tbl.Rows.Add();

        //        for (int j = 0; j < range.Columns.Count; j++)
        //        {
        //            CellValue = (object)range.Cells[2 + i, j + 1].Value2;

        //            if (md == null)     // object-typed DataTable
        //            {
        //                tbl.Rows[i][j] = CellValue;
        //            }
        //            else                // strongly-typed DataTable
        //            {
        //                fieldname = tbl.Columns[j].ColumnName;
        //                ftype = MetaData.GetFieldType(md, fieldname);

        //                switch (ftype)
        //                {
        //                    case FieldType.TextAttribute:
        //                        tbl.Rows[i][fieldname] = CellValue.ToString();
        //                        break;

        //                    case FieldType.IntegerAttribute:
        //                    case FieldType.DateAttribute:
        //                        ival = Convert.ToInt32(CellValue.ToString());

        //                        if (ftype == FieldType.IntegerAttribute)
        //                            tbl.Rows[i][fieldname] = ival;
        //                        else
        //                            tbl.Rows[i][fieldname] = DateFunctions.NumberToDate(ival);
        //                        break;

        //                    case FieldType.KeyFigure:
        //                        // throw an error if element value can't be converted to double
        //                        try
        //                        {
        //                            dval = Convert.ToDouble(CellValue.ToString());
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            throw new Exception("Cell value " + CellValue + " cannot be converted to double! " +
        //                                "Row: " + i + " Column: " + fieldname + "\n" + ex.Message);
        //                        }
        //                        tbl.Rows[i][fieldname] = dval;
        //                        break;

        //                    default:  // should not happen
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //    // return data table
        //    return tbl;
        //}


        public static Excel.ListObject FindListObject(Excel.Workbook wbook, string TableName)
        {
            if (wbook == null) return null;
            Excel.ListObject xlist = null;
            try
            {
                if (wbook.Worksheets.Count == 0) return xlist;

                foreach (var wsheet in wbook.Worksheets)
                {
                    if (((Excel.Worksheet)wsheet).ListObjects == null) continue; // don't know if this is necessary

                    for (int i = 1; i <= ((Excel.Worksheet)wsheet).ListObjects.Count; i++)
                    {
                        if (((Excel.Worksheet)wsheet).ListObjects[i].Name == TableName)
                        {
                            xlist = ((Excel.Worksheet)wsheet).ListObjects[i];
                            return xlist;
                        }
                    }
                }
            }
            catch
            {
                return xlist;
            }
            return xlist;
        }


        public static Excel.Worksheet FindWorksheet(Excel.Workbook wbook, string SheetName,
            bool AddSheetIfNotFound = false)
        {
            Excel.Worksheet wsheet = null;
            if (wbook == null) return null;

            foreach (Excel.Worksheet sheet in wbook.Sheets)
            {
                if (sheet.Name.Equals(SheetName))
                {
                    wsheet = wbook.Worksheets.get_Item(SheetName);
                    return wsheet;
                }
            }

            if (AddSheetIfNotFound)
            {
                wsheet = (Excel.Worksheet)wbook.Sheets.Add();
                wsheet.Name = SheetName;
                return wsheet;
            }
            return wsheet;
        }


        public static void WriteTableToExcelSheet(Excel.Worksheet wsheet, DataTable tbl, string TopLeftCell = "A1")
        {
            Excel.Range range = null;
            Excel.Range UpperLeftCell = null;

            try
            {
                // get upper left cell in range
                UpperLeftCell = (Excel.Range)wsheet.get_Range(TopLeftCell).Cells[1, 1];

                // clear range for table
                range = wsheet.get_Range(Cell1: UpperLeftCell.Address);
                range = range.get_Resize(tbl.Rows.Count + 1, tbl.Columns.Count);
                range.Cells.ClearContents();

                // write column names as table header (first line)
                string[] fieldNames = new string[tbl.Columns.Count];

                for (int i = 0; i < tbl.Columns.Count; i++)
                {
                    UpperLeftCell.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                    fieldNames[i] = tbl.Columns[i].ColumnName;
                }

                // for each column, create an array and set the array
                // to the excel range for that column.
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    string[,] clnDataString = new string[tbl.Rows.Count, 1];
                    int[,] clnDataInt = new int[tbl.Rows.Count, 1];
                    double[,] clnDataDouble = new double[tbl.Rows.Count, 1];

                    // row and column offsets (shifts w.r.t. upper left corner)
                    range = wsheet.get_Range(Cell1: UpperLeftCell.Address).get_Offset(1, i);

                    // define range size
                    range = range.get_Resize(tbl.Rows.Count, 1);

                    string dataTypeName = tbl.Columns[fieldNames[i]].DataType.Name;

                    for (int j = 0; j < tbl.Rows.Count; j++)
                    {
                        switch (dataTypeName.ToLower())
                        {
                            case "int32":
                                clnDataInt[j, 0] = Convert.ToInt32(tbl.Rows[j][fieldNames[i]]);
                                break;

                            case "double":
                                clnDataDouble[j, 0] = Convert.ToDouble(tbl.Rows[j][fieldNames[i]]);
                                break;

                            case "datetime":
                                //clnDataInt[j, 0] = Convert.ToInt32(DateFunctions.DateToNumber((DateTime)tbl.Rows[j][fieldNames[i]]));
                                break;

                            case "string":
                                clnDataString[j, 0] = tbl.Rows[j][fieldNames[i]].ToString();
                                break;

                            default:
                                throw new Exception("Invalid data type! Any data type other than "
                                    + "string, integer, DateTime and double is not compatible with "
                                    + " finaquant's table of type MatrixType");
                        }

                    }

                    if (dataTypeName == "Int32")
                    {
                        range.set_Value(value: clnDataInt);
                        range.NumberFormat = "General";
                    }
                    else if (dataTypeName == "DateTime")
                    {
                        range.set_Value(value: clnDataInt);
                        range.NumberFormat = "dd/mm/yyyy";  //"dd-mmm-yy";
                    }

                    else if (dataTypeName == "Double")
                    {
                        range.set_Value(value: clnDataDouble);
                        range.NumberFormat = "General";
                    }
                    else
                    {
                        range.set_Value(value: clnDataString);
                        range.NumberFormat = "General";
                    }
                }

                // make the header range bold
                range = wsheet.get_Range(Cell1: UpperLeftCell.Address).get_Resize(1, tbl.Columns.Count);
                range.Font.Bold = true;

                // autofit for better view
                wsheet.Columns.AutoFit();
            }
            catch (Exception ex)
            {
                throw new Exception("WriteTableToExcelSheet: " + ex.Message);
            }
            finally
            {
               // releaseObject(range);
               // releaseObject(UpperLeftCell);
            }
        }

       
        public Excel.ListObject WriteToExcelTable(Excel.Worksheet WSheet, string TableName, string CellStr = "A1", bool ClearSheetContent = false)
        {
            Excel.Range range;

            if (ClearSheetContent)
                WSheet.Cells.ClearContents();  // clear sheet content

            // get upper left corner of range defined by CellStr
            range = (Excel.Range)WSheet.get_Range(CellStr).Cells[1, 1];   //

            // Write table to range
            WriteTableToExcelSheet(WSheet, this._tbl, range.Address);

            // derive range for table, +1 row for table header
            range = range.get_Resize(this.RowCount + 1, this.ColumnCount);

            // add ListObject to sheet

            // ListObjects.AddEx Method
            // http://msdn.microsoft.com/en-us/library/microsoft.office.interop.excel.listobjects.addex%28v=office.14%29.aspx

            Excel.ListObject tbl = (Excel.ListObject)WSheet.ListObjects.AddEx(
                SourceType: Excel.XlListObjectSourceType.xlSrcRange,
                Source: range,
                XlListObjectHasHeaders: Excel.XlYesNoGuess.xlYes);

            // set name of excel table
            tbl.Name = TableName;

            // return excel table (ListObject)
            return (Excel.ListObject)tbl;
        }



    }
}
