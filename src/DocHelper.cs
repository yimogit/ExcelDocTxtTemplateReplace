using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ExcelDocTxtTemplateReplace
{
    public class DocHelper
    {
        private IWorkbook LoadWorkbook(string path)
        {
            var ext = Path.GetExtension(path);
            if (string.IsNullOrWhiteSpace(ext))
                return null;
            ext = ext.ToLower();
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                if (ext == ".xls")
                {
                    return new HSSFWorkbook(file);
                }
                else if (ext == ".xlsx")
                {
                    return new XSSFWorkbook(file);
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// 替换Excel
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="dics"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool ExcelReplace(string path, string savePath, Dictionary<string, string> dics)
        {
            IWorkbook workbook = LoadWorkbook(path);
            if (workbook == null)
            {
                return false;
            }
            for (var i = 0; i < workbook.NumberOfSheets; i++)
            {
                var sheet = workbook.GetSheetAt(i);
                for (var j = 0; j < sheet.LastRowNum; j++)
                {
                    var row = sheet.GetRow(j);
                    if (row != null)
                    {
                        for (var k = 0; k < row.LastCellNum; k++)
                        {
                            var cell = row.GetCell(k);
                            if (cell != null && cell.CellType == CellType.String)
                            {
                                foreach (var item in dics)
                                {
                                    cell.SetCellValue(new Regex(item.Key).Replace(cell.StringCellValue, item.Value));
                                }
                            }
                        }
                    }
                }
            }
            using (var file = new FileStream(savePath, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
                file.Flush();
                file.Close();
                workbook.Close();
            }
            return true;
        }
        /// <summary>
        /// 替换Word
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dics"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public bool WordReplace(string path, string savePath, Dictionary<string, string> dics)
        {
            using (var doc = new Spire.Doc.Document())
            {
                doc.LoadFromFile(path);
                foreach (var item in dics)
                {
                    doc.Replace(new Regex(item.Key), item.Value);
                }
                doc.SaveToFile(savePath);
                doc.Close();
            }
            return true;
        }
        /// <summary>
        /// 替换Txt文本
        /// </summary>
        /// <param name="path"></param>
        /// <param name="dics"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        public bool TxtReplace(string path, string savePath, Dictionary<string, string> dics)
        {
            using (StreamReader sr = new StreamReader(path, Encoding.Default))
            {
                var str = sr.ReadToEnd();
                foreach (var item in dics)
                {
                    str = new Regex(item.Key).Replace(str, item.Value);
                }
                File.WriteAllText(savePath, str, Encoding.Default);
                return true;
            }
        }
    }
}
