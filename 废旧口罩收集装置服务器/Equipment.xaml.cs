using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;
using MessageBox = System.Windows.MessageBox;

namespace 废旧口罩收集装置服务器
{
    /// <summary>
    /// Equipment.xaml 的交互逻辑
    /// </summary>
    public partial class Equipment : Window
    {
        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        string GlobalVariable_SavePath = null;



        /// <summary>
        /// 窗口打开事件
        /// </summary>
        public Equipment()
        {
            InitializeComponent();

            ChartData();


            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Information);
            timer.AutoReset = true;

            //AddLineGraph 方法将dataSource 中的坐标点绘制到图表中,曲线颜色定义为绿色，粗细设置为2，曲线名称为"Percentage"
            plotter1.AddLineGraph(dataSource1, Colors.Blue, 3, "温度");
            plotter2.AddLineGraph(dataSource2, Colors.Blue, 3, "湿度");
            plotter3.AddLineGraph(dataSource3, Colors.Blue, 3, "紫外线强度");
            plotter4.AddLineGraph(dataSource4, Colors.Blue, 3, "箱内压强");
            plotter5.AddLineGraph(dataSource5, Colors.Blue, 3, "箱外压强");
            plotter6.AddLineGraph(dataSource6, Colors.Blue, 3, "臭氧浓度");

            //设置计时器间隔为10秒
            timer1.Interval = TimeSpan.FromSeconds(1);
            //连续执行AnimatedPlot 事件实时绘制新坐标点
            timer1.Tick += new EventHandler(AnimatedPlot);
            timer1.IsEnabled = true;
            plotter1.Viewport.FitToView();
            plotter2.Viewport.FitToView();
            plotter3.Viewport.FitToView();
            plotter4.Viewport.FitToView();
            plotter5.Viewport.FitToView();
            plotter6.Viewport.FitToView();


        }

        /// <summary>
        /// 写入表数据
        /// </summary>
        private void ChartData()
        {
            //温度
            double[] temp = { 28.3};
            //湿度
            double[] humidity = { 71 };
            //紫外线
            double[] ultraviolet = {0.1 };
            //内压
            double[] internalpressure = { 0,44450,99952 };
            //外压
            double[] externalpressure = { 0,100003};
            //臭氧
            double[] ozone = { 0, 1.62 };

            for (int i = 0; i <= 0; i++)
            {
                string sqlStr = "update tb_equipment set `箱内温度`='" + temp[i] + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlStr);
            }
            for (int i = 0; i <= 0; i++)
            {
                string sqlStr = "update tb_equipment set `箱内湿度`='" + humidity[i] + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlStr);
            }
            for (int i = 0; i <= 0; i++)
            {
                string sqlStr = "update tb_equipment set `紫外线强度`='" + ultraviolet[i] + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlStr);
            }
            for (int i = 0; i <= 2; i++)
            {
                Task.Delay(10000);
                string sqlStr = "update tb_equipment set `箱内压强`='" + internalpressure[i] + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlStr);
            }
            for (int i = 0; i <= 1; i++)
            {
                string sqlStr = "update tb_equipment set `箱外压强`='" + externalpressure[i] + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlStr);
                Task.Delay(1000);
            }
            for(int i = 0; i <=1; i++)
            {
                string sqlStr = "update tb_equipment set `臭氧浓度`='" + ozone[i] + "' where`编号`='E001'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(sqlStr);
                Task.Delay(1000);
            }
        }


        /// <summary>
        /// 获取设备满溢情况
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void Information(object source, System.Timers.ElapsedEventArgs e)
        {
            TextBlock_EquipmentBrimmingrContent.Dispatcher.Invoke(() =>
            {
                TextBlock_EquipmentBrimmingrContent.Text = Ycommon.Common.InformationVisit()[0];
            });
            TextBlock_NumberMask1.Dispatcher.Invoke(() =>
            {
                TextBlock_NumberMask1.Text = Ycommon.Common.InformationVisit()[1];
            });

            string[,] history = Ycommon.Common.History();
            TextBlock_History.Dispatcher.Invoke(() =>
            {
                TextBlock_History.Text = "·" + "  " + history[0, 0] + "\r\n" + "   " + history[0, 1] + "        " + history[0, 2] + "\r\n\r\n" +
                                          "·" + "  " + history[1, 0] + "\r\n" + "   " + history[1, 1] + "        " + history[1, 2] + "\r\n\r\n" +
                                          "·" + "  " + history[2, 0] + "\r\n" + "   " + history[2, 1] + "        " + history[2, 2] + "\r\n\r\n" +
                                          "·" + "  " + history[3, 0] + "\r\n" + "   " + history[3, 1] + "        " + history[3, 2] + "\r\n\r\n";
            });

            LightStop();

            Light(Ycommon.Common.InformationVisit()[2], Ycommon.Common.InformationVisit()[3]);
        }

        /// <summary>
        /// 界面关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Equipment_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Enabled = false;
            LightStop();
        }

        /// <summary>
        /// 图表点存储
        /// </summary>
        private static ObservableDataSource<Point> dataSource1 = new ObservableDataSource<Point>();
        private static ObservableDataSource<Point> dataSource2 = new ObservableDataSource<Point>();
        private static ObservableDataSource<Point> dataSource3 = new ObservableDataSource<Point>();
        private static ObservableDataSource<Point> dataSource4 = new ObservableDataSource<Point>();
        private static ObservableDataSource<Point> dataSource5 = new ObservableDataSource<Point>();
        private static ObservableDataSource<Point> dataSource6 = new ObservableDataSource<Point>();
        private DispatcherTimer timer1 = new DispatcherTimer();
        private static int i = 0;

        /// <summary>
        /// AnimatedPlot 事件用于构造坐标点,
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnimatedPlot(object sender, EventArgs e)
        {
            string sqlstr = "select `箱内温度`,`箱内湿度`,`紫外线强度`,`箱内压强`,`箱外压强`,`臭氧浓度` from tb_equipment where `编号`='E001'";
            DataTable dataTable = new DataTable();
            dataTable = YF.Utility.YMysqlHelper.MysqlHelper.ExecuteDataTable(sqlstr);

            //整型i 作为X值
            double x = i;
            //温度数据作为Y值
            double temp = double.Parse(dataTable.Rows[0][0].ToString());
            double humidity = double.Parse(dataTable.Rows[0][1].ToString());
            double ultraviolet = double.Parse(dataTable.Rows[0][2].ToString());
            double pressureN = double.Parse(dataTable.Rows[0][3].ToString());
            double pressureW = double.Parse(dataTable.Rows[0][4].ToString());
            double ozone = double.Parse(dataTable.Rows[0][5].ToString());


            //将X、Y值构造为坐标点（Point）
            Point point1 = new Point(x, temp);
            Point point2 = new Point(x, humidity);
            Point point3 = new Point(x, ultraviolet);
            Point point4 = new Point(x, pressureN);
            Point point5 = new Point(x, pressureW);
            Point point6 = new Point(x, ozone);
            //通过异步方式存储在dataSource
            dataSource1.AppendAsync(base.Dispatcher, point1);
            dataSource2.AppendAsync(base.Dispatcher, point2);
            dataSource3.AppendAsync(base.Dispatcher, point3);
            dataSource4.AppendAsync(base.Dispatcher, point4);
            dataSource5.AppendAsync(base.Dispatcher, point5);
            dataSource6.AppendAsync(base.Dispatcher, point6);

            //显示出最新值
            cpuUsageText1.Text = temp.ToString() + "   ℃";
            cpuUsageText2.Text = humidity.ToString() + "   %";
            cpuUsageText3.Text = ultraviolet.ToString();
            cpuUsageText4.Text = pressureN.ToString() + "   Pa";
            cpuUsageText5.Text = pressureW.ToString() + "   Pa";
            cpuUsageText6.Text = ozone.ToString() + "   pp";

            i++;    //可换成当前时间值
        }

        /// <summary>
        /// 打印按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string Crewchar = null;
                string Equipmentchar = null;
                if (ComboBox_crew.Text == "")
                {
                    Crewchar = "!";
                }
                if (ComboBox_equipment.Text == "")
                {
                    Equipmentchar = "!";
                }
                string Crew = ComboBox_crew.Text;
                string Equipment = ComboBox_equipment.Text;
                string FileName = TextBox_FileName.Text;
                string SavePath = GlobalVariable_SavePath;

                string InitialDate = null;
                string InitialTime = null;
                string Start = null;
                if (DataPicker_InitialDate.Text == "")
                {
                    Start = "2021-1-1 00:00";
                }
                else
                {
                    InitialDate = DataPicker_InitialDate.Text.Replace('/', '-');
                    if (PresetTimePicker_InitialTime.Text == "")
                    {
                        InitialTime = "00:00";
                    }
                    else
                    {
                        InitialTime = PresetTimePicker_InitialTime.Text;
                    }
                    Start = InitialDate + "\t" + InitialTime;
                }

                string Deadilne = null;
                string DeadilneTime = null;
                string Stop = null;
                if (DataPicker_Deadilne.Text == "")
                {
                    Deadilne = DateTime.Now.ToString("g").Replace('/', '-');           // 2008-9-4 14:50
                }
                else
                {
                    Deadilne = DataPicker_Deadilne.Text.Replace('/', '-');
                    if (PresetTimePicker_DeadilneTime.Text == "")
                    {
                        DeadilneTime = "23:59";
                    }
                    else
                    {
                        DeadilneTime = PresetTimePicker_DeadilneTime.Text;
                    }

                    Stop = Deadilne + "\t" + DeadilneTime;
                }

                Ycommon.Common.ExcelPtint(Crewchar, Crew, Equipmentchar, Equipment, FileName, SavePath, Start, Stop);
            }
            catch
            {
                if (TextBox_FileName.Text == "")
                {
                    System.Windows.MessageBox.Show("请输入文件名！");
                }
                if (TextBox_SavePath.Text == "")
                {
                    System.Windows.MessageBox.Show("请输入文件路径！");
                }
            }
        }

        private void Button_Browse_Print_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "pls select a folder";
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                TextBox_SavePath.Text = fbd.SelectedPath;
                GlobalVariable_SavePath = fbd.SelectedPath;
            }
        }

        public void Light(string light1,string light2)
        {
            if(light1 == "1")
            {
                Light_Waiting.Dispatcher.Invoke(() =>
                {
                    Light_Waiting.Background = Brushes.YellowGreen;
                });
            }
            else if (light1 == "2")
            {
                Light_Breaking.Dispatcher.Invoke(() =>
                {
                    Light_Breaking.Background = Brushes.YellowGreen;
                });
            }
            else if (light1 == "3")
            {
                Light_Clean.Dispatcher.Invoke(() =>
                {
                    Light_Clean.Background = Brushes.YellowGreen;
                });
            }
            else  if (light1 == "4")
            {
                Light_Breakdown.Dispatcher.Invoke(() =>
                {
                    Light_Breakdown.Background = Brushes.YellowGreen;
                });
            }
            if(light2 == "1")
            {
                Light_Sterilize.Dispatcher.Invoke(() =>
                {
                    Light_Sterilize.Background = Brushes.YellowGreen;
                });
            }
        }

        public void LightStop()
        {
            Light_Waiting.Dispatcher.Invoke(() =>
            {
                Light_Waiting.Background = Brushes.White;
            });
            Light_Breaking.Dispatcher.Invoke(() =>
            {
                Light_Breaking.Background = Brushes.White;
            });
            Light_Clean.Dispatcher.Invoke(() =>
            {
                Light_Clean.Background = Brushes.White;
            });
            Light_Breakdown.Dispatcher.Invoke(() =>
            {
                Light_Breakdown.Background = Brushes.White;
            });
            Light_Sterilize.Dispatcher.Invoke(() =>
            {
                Light_Sterilize.Background = Brushes.White;
            });
        }
    }
}
