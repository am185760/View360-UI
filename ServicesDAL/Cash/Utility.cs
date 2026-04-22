using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;


namespace NCR.EView360
{
    public static class Utility
    {
 
        static ArrayList _Files = null;


        private static  string GenerateSheetHeaderAndDefaultSheetData(DateTime orderDate)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
            builder.Append("<worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">");
            builder.Append("    <dimension ref=\"A1:L40\"/>");
            builder.Append("    <sheetViews>");
            builder.Append("        <sheetView tabSelected=\"1\" view=\"pageBreakPreview\" topLeftCell=\"A2\" zoomScale=\"60\" zoomScaleNormal=\"100\" workbookViewId=\"0\">");
            builder.Append("		            <selection activeCell=\"K38\" sqref=\"K38\"/>");
            builder.Append("        </sheetView>");
            builder.Append("    </sheetViews>");
            builder.Append("    <sheetFormatPr defaultRowHeight=\"13.5\"/>");
            builder.Append("    <cols>");
            builder.Append("    <col min=\"1\" max=\"1\" width=\"7.7109375\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("    <col min=\"2\" max=\"2\" width=\"9.140625\" style=\"140\"/>");

            builder.Append("            <col min=\"3\" max=\"3\" width=\"11.140625\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("    <col min=\"4\" max=\"4\" width=\"21.7109375\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("             <col min=\"5\" max=\"5\" width=\"11.7109375\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("            <col min=\"6\" max=\"6\" width=\"10.85546875\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("            <col min=\"7\" max=\"7\" width=\"14.28515625\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("            <col min=\"8\" max=\"8\" width=\"10.5703125\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("            <col min=\"9\" max=\"9\" width=\"14\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("           <col min=\"10\" max=\"10\" width=\"14.140625\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("           <col min=\"11\" max=\"11\" width=\"21.7109375\" style=\"140\" customWidth=\"1\"/>");
            builder.Append("           <col min=\"12\" max=\"16384\" width=\"9.140625\" style=\"140\"/>");
            builder.Append("       </cols>");
            builder.Append("       <sheetData>");
            builder.Append("           <row r=\"1\" spans=\"1:12\">");
            builder.Append("              <c r=\"K1\" s=\"141\"/>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"2\" spans=\"1:12\">");
            builder.Append("              <c r=\"F2\" s=\"142\" t=\"s\">");
            builder.Append("                <v>7</v>");
            builder.Append("              </c><c r=\"G2\" s=\"143\"/>");
            builder.Append("              <c r=\"H2\" s=\"143\"/>");
            builder.Append("             <c r=\"I2\" s=\"144\"/>");
            builder.Append("              <c r=\"J2\" s=\"145\" t=\"s\">");
            builder.Append("                <v>0</v>");
            builder.Append("              </c><c r=\"K2\" s=\"174\">");
            builder.Append("                <v>" + orderDate.ToOADate() + "</v>");
            builder.Append("              </c>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"3\" spans=\"1:12\">");
            builder.Append("              <c r=\"I3\" s=\"147\"/>");
            builder.Append("              <c r=\"J3\" s=\"147\" t=\"s\">");
            builder.Append("                <v>1</v>");
            builder.Append("              </c>");

            builder.Append("              <c r=\"K3\" s=\"175\" t=\"inlineStr\">");
            builder.Append("                 <is>");
            builder.Append("                     <t>" + orderDate.DayOfWeek + "</t>");
            builder.Append("                  </is>");
            builder.Append("             </c>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"4\" spans=\"1:12\">");
            builder.Append("              <c r=\"J4\" s=\"148\"/>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"5\" spans=\"1:12\">");
            builder.Append("              <c r=\"A5\" s=\"141\"/>");
            builder.Append("              <c r=\"F5\" s=\"149\" t=\"s\">");
            builder.Append("                <v>5</v>");
            builder.Append("             </c><c r=\"G5\" s=\"150\"/>");
            builder.Append("              <c r=\"J5\" s=\"151\"/>");
            builder.Append("              <c r=\"K5\" s=\"152\"/>");
            builder.Append("              <c r=\"L5\" s=\"141\"/>");
            builder.Append("          </row>");
            builder.Append("          <row r=\"6\" spans=\"1:12\">");
            builder.Append("              <c r=\"A6\" s=\"153\" t=\"s\">");
            builder.Append("                <v>90</v>");
            builder.Append("             </c><c r=\"B6\" s=\"154\" t=\"s\">");
            builder.Append("                <v>2</v>");
            builder.Append("             </c><c r=\"C6\" s=\"154\" t=\"s\">");
            builder.Append("                <v>3</v>");
            builder.Append("             </c><c r=\"D6\" s=\"154\" t=\"s\">");
            builder.Append("                <v>4</v>");
            builder.Append("            </c><c r=\"E6\" s=\"150\">");
            builder.Append("                <v>1000</v>");
            builder.Append("            </c><c r=\"F6\" s=\"154\">");
            builder.Append("               <v>500</v>");
            builder.Append("           </c><c r=\"G6\" s=\"154\">");
            builder.Append("               <v>200</v>");
            builder.Append("          </c><c r=\"H6\" s=\"145\">");
            builder.Append("              <v>100</v>");
            builder.Append("          </c><c r=\"I6\" s=\"150\" t=\"s\">");
            builder.Append("              <v>6</v>");
            builder.Append("          </c><c r=\"J6\" s=\"144\" t=\"s\">");
            builder.Append("              <v>24</v>");
            builder.Append("          </c><c r=\"K6\" s=\"146\" t=\"s\">");
            builder.Append("              <v>301</v>");
            builder.Append("          </c><c r=\"L6\" s=\"145\" t=\"s\">");
            builder.Append("               <v>423</v>");
            builder.Append("           </c>");
            builder.Append("       </row>");
            return builder.ToString();
        }
        private static string GenerateFormulaRowAndSheetEndTag(int idx)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("<row r=\"{0}\" spans=\"1:12\" s=\"160\" customFormat=\"1\">", idx, idx - 1));
            builder.Append(string.Format("<c r=\"E{0}\" s=\"176\"><f>SUM(E7:E{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append(string.Format("<c r=\"F{0}\" s=\"176\"><f>SUM(F7:F{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append(string.Format("<c r=\"G{0}\" s=\"176\"><f>SUM(G7:G{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append(string.Format("<c r=\"H{0}\" s=\"176\"><f>SUM(H7:H{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append(string.Format("<c r=\"I{0}\" s=\"176\"><f>SUM(I7:I{1})</f><v>25100000</v></c>", idx, idx - 1));
            builder.Append("</row>");
            builder.Append(string.Format("<row r=\"{0}\" spans=\"1:12\" s=\"160\" customFormat=\"1\"/>", idx + 1));
            builder.Append(string.Format("<row r=\"{0}\" spans=\"1:12\" s=\"160\" customFormat=\"1\"/>", idx + 2));
            builder.Append("</sheetData>");
            return builder.ToString();
        }
        private static string GenerateFooter()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<sortState ref=\"A7:M422\">");
            builder.Append("                <sortCondition ref=\"B7\"/>");
            builder.Append("            </sortState>");
            builder.Append("<pageMargins left=\"0.75\" right=\"0.75\" top=\"1\" bottom=\"1\" header=\"0.5\" footer=\"0.5\"/>");
            builder.Append("<pageSetup scale=\"79\" orientation=\"landscape\" horizontalDpi=\"4294967293\" r:id=\"rId1\"/>");
            builder.Append("<headerFooter alignWithMargins=\"0\"/>");
            builder.Append("<drawing r:id=\"rId2\"/>");
            builder.Append("</worksheet>");
            return builder.ToString();
        }
        public static void UpdateSheet3(string filePath, DateTime orderDate, System.Data.DataTable dt)
        {
            StringBuilder builder = new StringBuilder();
            string headerWithDefaultRow = GenerateSheetHeaderAndDefaultSheetData(orderDate);
            string footer = GenerateFooter();
            int idx = 7;
            foreach (DataRow dr in dt.Rows)
            {//c.cassette1_denomination,c.cassette1_suggested_notes



                builder.Append(string.Format("<row r=\"{0}\" spans=\"1:12\" s=\"160\" customFormat=\"1\">", idx));
                builder.Append(string.Format("<c r=\"A{0}\" s=\"155\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["cit_atm_title"]));
                builder.Append(string.Format("<c r=\"B{0}\" s=\"156\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["title"]));
                builder.Append(string.Format("<c r=\"C{0}\" s=\"156\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["gl_number"]));
                builder.Append(string.Format("<c r=\"D{0}\" s=\"156\"  t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["location"]));
                builder.Append(string.Format("<c r=\"E{0}\" s=\"157\"><v>{1}</v></c>", idx, int.Parse(dr["cassette1_denomination"].ToString()) * int.Parse(dr["cassette1_suggested_notes"].ToString())));
                builder.Append(string.Format("<c r=\"F{0}\" s=\"157\"><v>{1}</v></c>", idx, int.Parse(dr["cassette2_denomination"].ToString()) * int.Parse(dr["cassette2_suggested_notes"].ToString())));
                builder.Append(string.Format("<c r=\"G{0}\" s=\"157\"><v>{1}</v></c>", idx, int.Parse(dr["cassette3_denomination"].ToString()) * int.Parse(dr["cassette3_suggested_notes"].ToString())));
                builder.Append(string.Format("<c r=\"H{0}\" s=\"157\"><v>{1}</v></c>", idx, int.Parse(dr["cassette4_denomination"].ToString()) * int.Parse(dr["cassette4_suggested_notes"].ToString())));
                builder.Append(string.Format("<c r=\"I{0}\" s=\"158\"><f>SUM(E{0}:H{0})</f><v>2600000</v></c>", idx));
                builder.Append(string.Format("<c r=\"J{0}\" s=\"159\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, dr["city"]));

                if (dr["cash_order_datetime"].ToString() != dr["replenishment_datetime"].ToString())
                {
                    builder.Append(string.Format("<c r=\"K{0}\" s=\"156\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, DateTime.Parse(dr["replenishment_datetime"].ToString()).ToString("dd-MMM")));
                    builder.Append(string.Format("<c r=\"L{0}\" s=\"156\" t=\"inlineStr\"><is><t>{1}</t></is></c>", idx, DateTime.Parse(dr["replenishment_datetime"].ToString()).ToString("HH:mm")));
                }
                else
                {
                    builder.Append(string.Format("<c r=\"K{0}\" s=\"156\"/>", idx));
                    builder.Append(string.Format("<c r=\"L{0}\" s=\"156\"/>", idx));
                }


                builder.Append("</row>");
                idx++;
            }
            File.WriteAllText(filePath, headerWithDefaultRow + builder.ToString() + GenerateFormulaRowAndSheetEndTag(idx) + footer);
        }

       
       
        public static void BuildList(string SearchPath, int RecursionLevel)
        {
            //new ArrayList();
            DirectoryInfo ThisLevel = new DirectoryInfo(SearchPath);
            DirectoryInfo[] ChildLevel = ThisLevel.GetDirectories();
            if (RecursionLevel != 1)
            {
                foreach (DirectoryInfo Child in ChildLevel)
                {
                    BuildList(Child.FullName, RecursionLevel - 1);
                }
            }
            FileInfo[] ChildFiles = ThisLevel.GetFiles();
            foreach (FileInfo ChildFile in ChildFiles)
            {
                _Files.Add(ChildFile.FullName);
            }
        }
        

         
        }
}
