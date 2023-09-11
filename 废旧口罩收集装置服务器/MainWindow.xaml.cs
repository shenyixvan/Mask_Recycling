using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MySql.Data.MySqlClient;
using Modbus.Device;
using System.Timers;

namespace 废旧口罩收集装置服务器
{
    /// <summary>
    /// Window2.xaml 的交互逻辑
    /// </summary>
    public partial class Window2 : Window
    {
        private System.Timers.Timer timer = new System.Timers.Timer(5000);
        System.Timers.Timer timer_2 = new System.Timers.Timer(1000);      //
        string sURL = AppDomain.CurrentDomain.BaseDirectory + "Map_2.html";
        TcpClient tcpClient = null;                                       //

        public Window2()
        {
            InitializeComponent();
            Light_SystemDown.Background = Brushes.YellowGreen;
            AduFlatButton_systemDown.IsEnabled = false;
            TextBlock_SystemDown.Opacity = 1;

            timer.Enabled = true;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(CrewInformation);
            timer.AutoReset = true;
        }

        Thread thread;

        private void AduFlatButton_systemOpen_Click(object sender, RoutedEventArgs e)
        {
            Light_SystemOpen.Background = Brushes.YellowGreen;
            Light_SystemDown.Background = Brushes.White;
            TextBlock_SystemOpen.Opacity = 1;
            TextBlock_SystemDown.Opacity = 0.2;
            AduFlatButton_systemOpen.IsEnabled = false;
            AduFlatButton_systemDown.IsEnabled = true;

            thread = new Thread(ModbusConnect);
            thread.Start();
        }

        public void ModbusConnect()
        {
            //TcpClient tcpClient = null;
            connectcontinue:
            try
            {
                //tcpClient = new TcpClient("u3815n0014.qicp.vip ", 22476);
                //tcpClient = new TcpClient("192.168.43.100", 503);
                //tcpClient = new TcpClient("127.0.0.1", 502);
                tcpClient = new TcpClient("192.168.0.13", 502);
            }
            catch
            {
                goto connectcontinue;
            }


            //while (true)
            //{
                ModbusIpMaster modbusIpMaster = ModbusIpMaster.CreateIp(tcpClient);
                try
                {



                timer_2.Enabled = true;
                timer_2.Start();
                timer_2.Elapsed += new System.Timers.ElapsedEventHandler(ReadWrite);




                string str_mask = "E001";
                StationConnection(str_mask);









               



                   
                }
                catch
                {
                    tcpClient.Close();
                    //modbusIpMaster.Dispose();
                    //goto connectcontinue;
                }
            //}

        }



        private void ReadWrite(object source, ElapsedEventArgs e)
        {
            ModbusIpMaster modbusIpMaster = ModbusIpMaster.CreateIp(tcpClient);
            ushort[] Modbusreturn = new ushort[20];
            Modbusreturn = modbusIpMaster.ReadHoldingRegisters(0, 4, 18);
            modbusIpMaster.WriteMultipleRegisters(0, 22, Ycommon.Common.ReadMySqlOpen());
            Ycommon.Common.Datacollection(Modbusreturn);
        }



        public void StationConnection(string mask)
        {
            if (mask == "E001")
            {
                Image_S1.Dispatcher.Invoke(() =>
                {
                    Image_S1.Opacity = 1;
                });

                Light_S1zt.Dispatcher.Invoke(() =>
                {
                    Light_S1zt.Background = Brushes.YellowGreen;
                });

                TextBlock_S1zt.Dispatcher.Invoke(() =>
                {
                    TextBlock_S1zt.Text = "已连接";
                });
            }
            else if(mask == "002")
            {
                Image_S2.Dispatcher.Invoke(() =>
                {
                    Image_S2.Opacity = 1;
                });

                Light_S2zt.Dispatcher.Invoke(() =>
                {
                    Light_S2zt.Background = Brushes.YellowGreen;
                });

                TextBlock_S2zt.Dispatcher.Invoke(() =>
                {
                    TextBlock_S2zt.Text = "已连接";
                });
            }
            else if (mask == "003")
            {
                Image_S3.Dispatcher.Invoke(() =>
                {
                    Image_S3.Opacity = 1;
                });

                Light_S3zt.Dispatcher.Invoke(() =>
                {
                    Light_S3zt.Background = Brushes.YellowGreen;
                });

                TextBlock_S3zt.Dispatcher.Invoke(() =>
                {
                    TextBlock_S3zt.Text = "已连接";
                });
            }
            else if (mask == "004")
            {
                Image_S4.Dispatcher.Invoke(() =>
                {
                    Image_S4.Opacity = 1;
                });

                Light_S4zt.Dispatcher.Invoke(() =>
                {
                    Light_S4zt.Background = Brushes.YellowGreen;
                });

                TextBlock_S4zt.Dispatcher.Invoke(() =>
                {
                    TextBlock_S4zt.Text = "已连接";
                });
            }
            else if (mask == "005")
            {
                Image_S5.Dispatcher.Invoke(() =>
                {
                    Image_S5.Opacity = 1;
                });

                Light_S5zt.Dispatcher.Invoke(() =>
                {
                    Light_S5zt.Background = Brushes.YellowGreen;
                });

                TextBlock_S5zt.Dispatcher.Invoke(() =>
                {
                    TextBlock_S5zt.Text = "已连接";
                });
            }
            else if (mask == "006")
            {
                Image_S6.Dispatcher.Invoke(() =>
                {
                    Image_S6.Opacity = 1;
                });

                Light_S6zt.Dispatcher.Invoke(() =>
                {
                    Light_S6zt.Background = Brushes.YellowGreen;
                });

                TextBlock_S6zt.Dispatcher.Invoke(() =>
                {
                    TextBlock_S6zt.Text = "已连接";
                });
            }
        }
        public void StationDisconnect()
        {
            Image_S1.Opacity = 0.5;
            Light_S1zt.Background = Brushes.White;
            TextBlock_S1zt.Text = "未连接";

            Image_S2.Opacity = 0.5;
            Light_S2zt.Background = Brushes.White;
            TextBlock_S2zt.Text = "未连接";

            Image_S3.Opacity = 0.5;
            Light_S3zt.Background = Brushes.White;
            TextBlock_S3zt.Text = "未连接";

            Image_S4.Opacity = 0.5;
            Light_S4zt.Background = Brushes.White;
            TextBlock_S4zt.Text = "未连接";

            Image_S5.Opacity = 0.5;
            Light_S5zt.Background = Brushes.White;
            TextBlock_S5zt.Text = "未连接";

            Image_S6.Opacity = 0.5;
            Light_S6zt.Background = Brushes.White;
            TextBlock_S6zt.Text = "未连接";
            
        }

        private void AduFlatButton_systemDown_Click(object sender, RoutedEventArgs e)
        {
            Light_SystemOpen.Background = Brushes.White;
            Light_SystemDown.Background = Brushes.YellowGreen;
            TextBlock_SystemOpen.Opacity = 0.2;
            TextBlock_SystemDown.Opacity = 1;
            AduFlatButton_systemOpen.IsEnabled = true;
            AduFlatButton_systemDown.IsEnabled = false;

            StationDisconnect();

            thread.Abort();

            timer.Enabled = false;
        }

        private void Image_OnMouseDown(object sender, RoutedEventArgs e)
        {
            Equipment equipment1 = new Equipment();
            //equipment1.ShowDialog();
            equipment1.Show();
        }

        private void CrewInformation(object source, System.Timers.ElapsedEventArgs e)
        {
            string[,] crew = Ycommon.Common.CrewInformain();

            if (crew[0, 0] != "")
            {
                TextBox_T1bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T1bh.Text = crew[0, 0];
                });
                TextBox_T1Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T1Name.Text = crew[0, 1];
                });
            }
            if (crew[1, 0] != "")
            {
                TextBox_T2bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T2bh.Text = crew[1, 0];
                });
                TextBox_T2Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T2Name.Text = crew[1, 1];
                });
            }
            if (crew[2, 0] != "")
            {
                TextBox_T3bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T3bh.Text = crew[2, 0];
                });
                TextBox_T3Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T3Name.Text = crew[2, 1];
                });
            }
            if (crew[3, 0] != "")
            {
                TextBox_T4bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T4bh.Text = crew[3, 0];
                });
                TextBox_T4Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T4Name.Text = crew[3, 1];
                });
            }
            if (crew[4, 0] != "")
            {
                TextBox_T5bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T5bh.Text = crew[4, 0];
                });
                TextBox_T5Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T5Name.Text = crew[4, 1];
                });
            }
            if (crew[5, 0] != "")
            {
                TextBox_T6bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T6bh.Text = crew[5, 0];
                });
                TextBox_T6Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T6Name.Text = crew[5, 1];
                });
            }
            if (crew[6, 0] != "")
            {
                TextBox_T7bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T7bh.Text = crew[5, 0];
                });
                TextBox_T7Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T7Name.Text = crew[5, 1];
                });
            }
            if (crew[7, 0] != "")
            {
                TextBox_T8bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T8bh.Text = crew[5, 0];
                });
                TextBox_T8Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T8Name.Text = crew[5, 1];
                });
            }
            if (crew[8, 0] != "")
            {
                TextBox_T9bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T9bh.Text = crew[5, 0];
                });
                TextBox_T9Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T9Name.Text = crew[5, 1];
                });
            }
            if (crew[9, 0] != "")
            {
                TextBox_T10bh.Dispatcher.Invoke(() =>
                {
                    TextBox_T10bh.Text = crew[5, 0];
                });
                TextBox_T10Name.Dispatcher.Invoke(() =>
                {
                    TextBox_T10Name.Text = crew[5, 1];
                });
            }

            if (Ycommon.Common.Readmaimen()[0] == "1")
            {
                Task.Delay(4500);

                string strsql = "update tb_middle set `开门`='0'";
                YF.Utility.YMysqlHelper.MysqlHelper.ExecuteNonQuery(strsql);

            }



        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Light_SystemOpen.Background = Brushes.White;
            Light_SystemDown.Background = Brushes.YellowGreen;
            TextBlock_SystemOpen.Opacity = 0.2;
            TextBlock_SystemDown.Opacity = 1;
            AduFlatButton_systemOpen.IsEnabled = true;
            AduFlatButton_systemDown.IsEnabled = false;

            StationDisconnect();

            Environment.Exit(0);                                                                                                                //关闭退出
                                                       
            thread.Abort();
            timer.Enabled = false;

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(sURL);
            wb.Navigate(uri);
        }
    }
}