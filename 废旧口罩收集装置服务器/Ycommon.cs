using Microsoft.Office.Interop.Excel;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YF.Utility;

namespace 废旧口罩收集装置服务器
{
    class Ycommon
    {
        public static class Common
        {
            /// <summary>
            /// PLC数据转换存入数据库
            /// </summary>
            /// <param name="Modbusreturn"></param>
            public static void Datacollection(ushort[] Modbusreturn)
            {
                //int high00 = Modbusreturn[0] / 256 % 16;
                //int low00 = Modbusreturn[0] % 256 % 16;
                //int high01 = Modbusreturn[1] / 256 % 16;
                //int low01 = Modbusreturn[1] % 256 % 16;
                //int high02 = Modbusreturn[2] / 256 % 16;
                //int low02 = Modbusreturn[2] % 256 % 16;
                //string pressure0 = high00.ToString() + low00.ToString() + high01.ToString() + low01.ToString() + high02.ToString() + low02.ToString();
                ////string str0 = System.Convert.ToString(Modbusreturn[0], 10);
                //string sqlstrpressure0 = "update tb_equipment set `箱内压强`='" + pressure0 + "' where`编号`='E001'";
                //YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlstrpressure0);

                //int high10 = Modbusreturn[3] / 256 % 16;
                //int low10 = Modbusreturn[3] % 256 % 16;
                //int high11 = Modbusreturn[4] / 256 % 16;
                //int low11 = Modbusreturn[4] % 256 % 16;
                //int high12 = Modbusreturn[5] / 256 % 16;
                //int low12 = Modbusreturn[5] % 256 % 16;
                //string pressure1 = high10.ToString() + low10.ToString() + high11.ToString() + low11.ToString() + high12.ToString() + low12.ToString();
                ////string str0 = System.Convert.ToString(Modbusreturn[0], 10);
                //string sqlstrpressure1 = "update tb_equipment set `箱外压强`='" + pressure1 + "' where`编号`='E001'";
                //YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlstrpressure1);

                //int ozone_byte0 = Modbusreturn[6] / 256 % 16;
                //int ozone_byte1 = Modbusreturn[6] % 256 % 16;
                //int ozone_byte2 = Modbusreturn[7] / 256 % 16;
                //string ozone = ozone_byte0.ToString() + "." + ozone_byte1.ToString() + ozone_byte2.ToString();
                //string sqlstrozone = "update tb_equipment set `臭氧浓度`='" + ozone + "' where`编号`='E001'";
                //YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlstrozone);

                ////int light_byte0 = Modbusreturn[7] % 256 % 16;
                ////int light_byte1 = Modbusreturn[8] / 256 % 16;
                ////int light_byte2 = Modbusreturn[8] % 256 % 16;
                ////string light = light_byte0.ToString() + "." + light_byte1.ToString() + light_byte2.ToString();
                ////string sqlstrlight = "update tb_equipment set `紫外线强度`='" + light + "' where`编号`='E001'";
                ////YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlstrlight);

                //string sqlstrlight = "update tb_equipment set `紫外线强度`='" + Modbusreturn[8].ToString() + "' where`编号`='E001'";
                //YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlstrlight);

                //int temp_byte0 = Modbusreturn[9] / 256 % 16;
                //int temp_byte1 = Modbusreturn[9] % 256 % 16;
                //int temp_byte2 = Modbusreturn[10] / 256 % 16;
                //string temp = temp_byte0.ToString() + temp_byte1.ToString() + "." + temp_byte2.ToString();
                //string sqlstrtemp = "update tb_equipment set `箱内温度`='" + temp + "' where`编号`='E001'";
                //YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlstrtemp);

                //int humidity_byte0 = Modbusreturn[10] % 256 % 16;
                //int humidity_byte1 = Modbusreturn[11] / 256 % 16;
                //int humidity_byte2 = Modbusreturn[11] % 256 % 16;
                //string humidity = humidity_byte0.ToString() + humidity_byte1.ToString() + "." + humidity_byte2.ToString();
                //string sqlstrhumidity = "update tb_equipment set `箱内湿度`='" + humidity + "' where`编号`='E001'";
                //YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlstrhumidity);

                string masknumber = "update tb_equipment set `箱内口罩个数`='" + Modbusreturn[12].ToString() + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(masknumber);

                string light1 = "update tb_equipment set light1='" + Modbusreturn[13].ToString() + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(light1);

                string light2 = "update tb_equipment set light2='" + Modbusreturn[14].ToString() + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(light2);

                string maskfull = "update tb_equipment set `是否满溢`='" + Modbusreturn[15].ToString() + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(maskfull);

                string strxiangmenshifoukaiqi = "update tb_middle set `读门`='" + Modbusreturn[16].ToString() + "'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(strxiangmenshifoukaiqi);

                string strqinglizhong = "update tb_middle set `读清理状态`='" + Modbusreturn[17].ToString() + "'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(strqinglizhong);
            }

            public static ushort[] ReadMySqlOpen()
            {
                ushort[] readmysql = new ushort[2];

                string sqlstr0 = "select `开门`,`启停` from tb_middle";
                System.Data.DataTable dataTable = YMysqlHelper.MysqlHelper.ExecuteDataTable(sqlstr0);

                for (int i = 0; i < 2; i++)
                {
                    readmysql[i] = ushort.Parse(dataTable.Rows[0][i].ToString());
                }

                return readmysql;
            }

            public static string[] Readmaimen()
            {
                string[] vs = new string[1];

                string s1 = "select `开门` from tb_middle";
                System.Data.DataTable dataTable = YMysqlHelper.MysqlHelper.ExecuteDataTable(s1);

                vs[0] = dataTable.Rows[0][0].ToString();

                return vs;
            }

            public static string[] InformationVisit()
            {
                string[] showinfo = new string[4];

                string sqlstr = "select `是否满溢` from tb_equipment where `编号`='E001'";
                System.Data.DataTable dataTable = YMysqlHelper.MysqlHelper.ExecuteDataTable(sqlstr);

                if (dataTable.Rows[0][0].ToString() == "1")
                {
                    showinfo[0] = "已满";
                }
                else
                {
                    showinfo[0] = "未满";
                }

                string sqlstr1 = "select `箱内口罩个数`,light1,light2 from tb_equipment where `编号`='E001'";
                System.Data.DataTable dataTable1 = YMysqlHelper.MysqlHelper.ExecuteDataTable(sqlstr1);
                showinfo[1] = dataTable1.Rows[0][0].ToString();
                showinfo[2] = dataTable1.Rows[0][1].ToString();
                showinfo[3] = dataTable1.Rows[0][2].ToString();

                return showinfo;
            }

            public static string[,] History()
            {
                string[,] result = new string[4,3];

                string sqlstr0 = "select count(*) from tb_history where `被清理的设备编号`='E001'";
                string sqlstr1 = "select `清理时间`,`清理人员编号`,`设备是否正常` from tb_history where `被清理的设备编号`='E001'";
                System.Data.DataTable hangstr = YMysqlHelper.MysqlHelper.ExecuteDataTable (sqlstr0);
                int hang = int.Parse(hangstr.Rows[0][0].ToString());

                System.Data.DataTable dataTable = YMysqlHelper.MysqlHelper.ExecuteDataTable(sqlstr1);
                if(hang >= 4)
                {
                    for(int i = 0;i < 4; i++)
                    {
                        for(int j = 0;j < 3; j++)
                        {
                            result[i, j] = dataTable.Rows[hang - 4 + i][j].ToString();
                            if(j == 2)
                            {
                                if(result[i,j] == "1")
                                {
                                    result[i, j] = "设备正常";
                                }
                                else
                                {
                                    result[i, j] = "设备故障";
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else if(hang == 3)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            result[i, j] = dataTable.Rows[hang - 3 + i][j].ToString();
                            if (j == 2)
                            {
                                if (result[i, j] == "1")
                                {
                                    result[i, j] = "设备正常";
                                }
                                else
                                {
                                    result[i, j] = "设备故障";
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else if (hang == 2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            result[i, j] = dataTable.Rows[hang - 2 + i][j].ToString();
                            if (j == 2)
                            {
                                if (result[i, j] == "1")
                                {
                                    result[i, j] = "设备正常";
                                }
                                else
                                {
                                    result[i, j] = "设备故障";
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else if (hang == 1)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            result[i, j] = dataTable.Rows[hang - 1 + i][j].ToString();
                            if (j == 2)
                            {
                                if (result[i, j] == "1")
                                {
                                    result[i, j] = "设备正常";
                                }
                                else
                                {
                                    result[i, j] = "设备故障";
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

                return result;
            }

            /// <summary>
            /// 打印历史数据
            /// </summary>
            /// <param name="Crewchar"></param>
            /// <param name="crew"></param>
            /// <param name="Equipmentchar"></param>
            /// <param name="equipment"></param>
            /// <param name="filename"></param>
            public static void ExcelPtint(string Crewchar,string crew,string Equipmentchar,string equipment,string filename,string savepath,string start,string stop)
            {
                //数据放入DataTable表格里
                string sqlstr = "select * from tb_history where `清理人员编号`" + Crewchar + "='" + crew
                             + "' and `被清理的设备编号`" + Equipmentchar + "='" + equipment + "'"
                             + "and `清理时间` between '" + start + "' and '" + stop + "'";

                System.Data.DataTable sqldt = YMysqlHelper.MysqlHelper.ExecuteDataTable(sqlstr);

                //创建Excel
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWB = excelApp.Workbooks.Add(Type.Missing);           //创建工作簿（WorkBook：即Excel文件主体本身）
                Worksheet excelWS = (Worksheet)excelWB.Worksheets[1];              //创建工作表（即Excel里的子表sheet） 1表示在子表sheet1里进行数据导出
                excelApp.DisplayAlerts = true;                                     //保存Excel的时候，不弹出是否保存的窗口直接进行保存

                //设置标题
                Range range = excelWS.get_Range("A1", "D1");                       //获取Excel多个单元格区域：本例做为Excel表头
                range.Merge(0);                                                    //单元格合并动作   要配合上面的get_Range()进行设计
                range.get_Offset(0, 0).Cells.Value = "设备清理历史";               //标题名称
                range.HorizontalAlignment = XlHAlign.xlHAlignCenter;               //设置字体在单元格内的对其方式，居中

                //设置标题列名
                range = excelWS.get_Range("A2", Type.Missing);                     //设置表格左上角开始显示的位置
                range.get_Offset(0, 0).Cells.Value = "清理人员名称";               //第一列列名
                range.get_Offset(0, 0).ColumnWidth = 13;                           //设置该单元格的宽度13
                range.get_Offset(0, 1).Cells.Value = "设备编号";                   //第二列列名
                range.get_Offset(0, 2).Cells.Value = "清理时间";                   //第三列列名
                range.get_Offset(0, 2).ColumnWidth = 15;                           //设置该单元格的宽度15
                range.get_Offset(0, 3).Cells.Value = "设备状态";                   //第四列列名

                //将数据导入到工作表的单元格
                range = excelWS.get_Range("A3", Type.Missing);                     //设置表格左上角开始显示的位置
                for (int i = 0; i < sqldt.Rows.Count; i++)
                {
                    for (int j = 0; j < sqldt.Columns.Count; j++)
                    {
                        range.get_Offset(i, j).Cells.Value = sqldt.Rows[i][j].ToString();
                    }
                }
                
                string filepath = savepath.Substring(0,2)+ savepath.Substring(3, savepath.Length-3) + "\\" + filename + ".xlsx";
                excelWB.SaveAs(filepath);                             //将其进行保存到指定的路径
                excelWB.Close();
                excelApp.Quit();                                                  //KillAllExcel(excelApp); 释放可能还没释放的进程
            }

            /// <summary>
            /// 人员管理界面获取数据库信息
            /// </summary>
            /// <returns></returns>
            public static string[,] CrewInformain()
            {
                string[,] crewinformain = new string[10,2];
                string count;
                string sqlstr0 = "select count(*) from tb_cleaningcrews";
                string sqlstr1 = "select `人员编号`,`姓名` from tb_cleaningcrews";

                System.Data.DataTable dataTable0 = new System.Data.DataTable();
                dataTable0 = YMysqlHelper.MysqlHelper.ExecuteDataTable(sqlstr0);
                count = dataTable0.Rows[0][0].ToString();

                System.Data.DataTable dataTable1 = new System.Data.DataTable();
                dataTable1 = YMysqlHelper.MysqlHelper.ExecuteDataTable(sqlstr1);

                for(int i = 0;i<short.Parse(count) & i < 10; i++)
                {
                    for(int j = 0; j < 2; j++)
                    {
                        crewinformain[i, j] = dataTable1.Rows[i][j].ToString();
                    }
                }
                return crewinformain;
            }

            

        }
    }
}
