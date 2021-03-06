﻿using System;
using System.Data;
using System.Windows.Forms;

namespace Tool
{
    public class xd100x
    {
        //数据结构
        #region
        public struct XD100xBuffer
        {
            public Info _Info;
            public Data _Data;
            public Command[] _Command;
            public Set _Set;
            public bool _SaveDatas;
            public int _LastCommandIndex;
        }

        public struct Info
        {
            public int _id;
            public string _name;
            public string _group;
            public float _HeatBase;
            public float _HeatArea;
            public string _remark;
            public string _dturegister;
            public string _ip;
            public byte _addr;
            public int _cycle;
            public int _timeout;
            public int _retrytimes;
            public bool _state;
            public string _result;
            public string _version;

            public int locationx;
            public int locationy;
            public int lablex;
            public int labley;
        }

        public struct Data
        {
            public float _GT1;
            public float _BT1;
            public float _GT2;
            public float _BT2;
            public float _OD;
            public float _OT;
            public float _GTB2;
            public float _GP1;
            public float _BP1;
            public float _WL;
            public float _GP2;
            public float _BP2;
            public float _BPB2;
            public float _WI1;
            public ulong _WS1;
            public float _WI2;
            public ulong _WS2;
            public float _WI3;
            public ulong _WS3;
            public float _HS1;
            public double _HI1;
            public float _HS2;
            public double _HI2;
            public float _PA2;
            public PumpState _pump;
            public AlarmState _alarm;
            public DateTime _dt;
        }

            public struct PumpState
            {
                public GRPumpState _CM1;
                public GRPumpState _CM2;
                public GRPumpState _CM3;
                public GRPumpState _RM1;
                public GRPumpState _RM2;
            }
            public struct AlarmState
            {
                public GRAlarm _all;
                public int _word;
                public GRAlarm _yicigongdiya;
                public GRAlarm _ercigonggaoya;
                public GRAlarm _ercihuigaoya;
                public GRAlarm _ercihuidiya;
                public GRAlarm _yicigongdiwen;
                public GRAlarm _ercigonggaowen;
                public GRAlarm _shuiweigao;
                public GRAlarm _shuiweidi;
                public GRAlarm _xunhuanbeng1;
                public GRAlarm _xunhuanbeng2;
                public GRAlarm _xunhuanbeng3;
                public GRAlarm _bushuibeng1;
                public GRAlarm _bushuibeng2;
                public GRAlarm _kaiguangao;
                public GRAlarm _kaiguandi;
                public GRAlarm _diaodian;
            }
            public enum GRPumpState
            {
                运行 = 0,
                停止 = 1,
            }
            public enum GRAlarm
            {
                有 = 1,
                无 = 0,
            }

        public struct Command
        {
            public byte[] _cmd;
            public DateTime _senddt;
            public DateTime _backdt;
            public string _introduce;
            public int _timeoutnow;
            public int _retrytimesnow;
            public bool _send;
            public bool _back;
            public bool _onoff;
        }

        public struct Set
        {
            public valvecontrol _valvecontrol;
            public valvevalue _valvevalue;
            public valveline _valveline;
            public valvetime _valvetime;
            public valvemm _valvemm;
            public valvelimit _valvelimit;

            public cycpumpline _cycpumpline;
            public cycpumpvalue _cycpumpvalue;
            public addpumpvalue _addpumpvalue;
            public addpumpmm _addpumpmm;

            public alarmp _alarmp;
            public alarmt _alarmt;
            public outmode _outmode;
            public outtemp _outtemp;
            public temprevise _outrevise;
            public temprevise _GT1revise;
            public temprevise _BT1revise;
            public temprevise _GT2revise;
            public temprevise _BT2revise;
        }
            public struct valvecontrol
            {
                public int _control;
            }
            public struct valvevalue
            {
                public float _value;
            }
            public struct valveline
            {
                public int _ov1;
                public int _gv1;
                public int _ov2;
                public int _gv2;
                public int _ov3;
                public int _gv3;
                public int _ov4;
                public int _gv4;
                public int _ov5;
                public int _gv5;
                public int _ov6;
                public int _gv6;
                public int _ov7;
                public int _gv7;
                public int _ov8;
                public int _gv8;
            }
            public struct valvetime
            {
                public float _v1;
                public float _v2;
                public float _v3;
                public float _v4;
                public float _v5;
                public float _v6;
                public float _v7;
                public float _v8;
                public float _v9;
                public float _v10;
                public float _v11;
                public float _v12;
            }
            public struct valvemm
            {
                public int _max;
                public int _min;
                public int _deatharea;
            }
            public struct valvelimit
            {
                public int _enable;
                public int _limit;
            }

            public struct cycpumpline
            {
                public int _ov1;
                public float _pv1;
                public int _ov2;
                public float _pv2;
                public int _ov3;
                public float _pv3;
                public int _ov4;
                public float _pv4;
                public int _ov5;
                public float _pv5;
                public int _ov6;
                public float _pv6;
                public int _ov7;
                public float _pv7;
                public int _ov8;
                public float _pv8;
            }
            public struct cycpumpvalue
            {
                public int _type;
                public float _pressure;
            }
            public struct addpumpvalue
            {
                public int _type;
                public float _pressure;
            }
            public struct addpumpmm
            {
                public float _presshight;
                public float _presslow;
                public float _levelhight;
                public float _levellow;
            }

        public struct alarmp
        {
            public float _yicigdiya;
            public float _erciggaoya;
            public float _ercihgaoya;
            public float _ercihdiya;
        }
        public struct alarmt
        {
            public int _yicigdiwen;
            public int _erciggaowen;
            public float _waterlow;
            public float _waterhight;
        }
        public struct outmode
        {
            public int _outmode;
        }
        public struct outtemp
        {
            public float _outtemp;
        }

        public struct temprevise
        {
            public byte _channel;
            public byte _type;
            public byte _unit;
            public float _max;
            public float _min;
            public float _k;
            public float _b;
            public float _temp;
        }


        public static XD100xBuffer[] _XD100xBuffer;
        #endregion

        //加载数据缓存
        #region
        public static void Load_XD100xBuffer()
        {
            try
            {
                string sql = "select [DeviceID],[StationName],[IPAddress],[DeviceAddress],[Remark],[HeatArea],[HeatBase],[GroupName],[Cycle],[TimeOut],[RetryTimes],[Version],[locationx],[locationy],[lablex],[labley] from vDeviceGR where [Deleted]=0 order by [GroupID] ";
                DataTable dt = Tool.DB.getDt(sql);
                _XD100xBuffer = new XD100xBuffer[dt.Rows.Count];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //加载站点信息
                    _XD100xBuffer[i]._Info._id = int.Parse(dt.Rows[i]["DeviceID"].ToString());
                    _XD100xBuffer[i]._Info._name = dt.Rows[i]["StationName"].ToString();
                    _XD100xBuffer[i]._Info._remark = dt.Rows[i]["Remark"].ToString();
                  //  _XD100xBuffer[i]._Info._HeatBase = float.Parse(dt.Rows[i]["HeatBase"].ToString());
                    _XD100xBuffer[i]._Info._HeatArea = float.Parse(dt.Rows[i]["HeatArea"].ToString());
                    _XD100xBuffer[i]._Info._group = dt.Rows[i]["GroupName"].ToString();

                    _XD100xBuffer[i]._Info._dturegister = "";
                    _XD100xBuffer[i]._Info._ip = dt.Rows[i]["IPAddress"].ToString();
                    _XD100xBuffer[i]._Info._cycle = int.Parse(dt.Rows[i]["Cycle"].ToString());
                    _XD100xBuffer[i]._Info._addr = Convert.ToByte(dt.Rows[i]["DeviceAddress"].ToString());
                    _XD100xBuffer[i]._Info._timeout = int.Parse(dt.Rows[i]["TimeOut"].ToString());
                    _XD100xBuffer[i]._Info._retrytimes = int.Parse(dt.Rows[i]["RetryTimes"].ToString());
                    _XD100xBuffer[i]._Info._version = dt.Rows[i]["Version"].ToString();

                    _XD100xBuffer[i]._Info.locationx = Convert.ToInt16(dt.Rows[i]["locationx"].ToString());
                    _XD100xBuffer[i]._Info.locationy = Convert.ToInt16(dt.Rows[i]["locationy"].ToString());
                    _XD100xBuffer[i]._Info.lablex = Convert.ToInt16(dt.Rows[i]["lablex"].ToString());
                    _XD100xBuffer[i]._Info.labley = Convert.ToInt16(dt.Rows[i]["labley"].ToString());

                    _XD100xBuffer[i]._Info._state = true;
                    //加载存储标志位
                    _XD100xBuffer[i]._SaveDatas = false;                  

                    //加载命令
                    if (_XD100xBuffer[i]._Info._version == "xd100n")
                    {
                        xd100n.load_xd100ncmd(i, _XD100xBuffer[i]._Set);
                    }
                    else
                    {
                        xd100.load_xd100cmd(i, _XD100xBuffer[i]._Set);
                    }
                    //初始化最后一次发送命令的起始地址
                    _XD100xBuffer[i]._LastCommandIndex = -1;
                }
                //加载历史最后数据
                load_lastdata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("建立数据缓存失败！" + ex, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
         //加载最后数据
        public static void load_lastdata()
        {
            string sql2 = "SELECT [AW], [DT], [GT1], [BT1], [GT2], [BT2], [OT]," +
                "[GTB2], [GP1], [BP1], [WL], [GP2], [BP2], " +
                "[BPB2], [WI1], [WS1], [WI3], [WS3], [HS1], [HI1]," +
                " [PA2], [OD], [CM1], [CM2], [CM3], [RM1], [RM2]," +
                " [DeviceID], [WI2], [WS3], [HS2], [HI2] FROM [vGRDataLast] ";
                //" where [DeviceID]=" + _XD100xBuffer[listID]._Info._id.ToString() +              
            DataTable dt1 = Tool.DB.getDt(sql2);
            for (int i = 0; i < Tool.xd100x._XD100xBuffer.Length; i++)
            {
                for (int j = 0; j < dt1.Rows.Count; j++)
                {
                    if (Tool.xd100x._XD100xBuffer[i]._Info._id == Convert.ToInt32(dt1.Rows[j]["DeviceID"].ToString()))
                    {
                        _XD100xBuffer[i]._Data._alarm._word = Convert.ToInt32(dt1.Rows[j]["AW"]);
                        _XD100xBuffer[i]._Data._dt = Convert.ToDateTime(dt1.Rows[j]["DT"]);
                        _XD100xBuffer[i]._Data._GT1 = Convert.ToSingle(dt1.Rows[j]["GT1"]);
                        _XD100xBuffer[i]._Data._BT1 = Convert.ToSingle(dt1.Rows[j]["BT1"]);
                        _XD100xBuffer[i]._Data._GT2 = Convert.ToSingle(dt1.Rows[j]["GT2"]);
                        _XD100xBuffer[i]._Data._BT2 = Convert.ToSingle(dt1.Rows[j]["BT2"]);
                        _XD100xBuffer[i]._Data._OT = Convert.ToSingle(dt1.Rows[j]["OT"]);
                        _XD100xBuffer[i]._Data._GTB2 = Convert.ToSingle(dt1.Rows[j]["GTB2"]);

                        _XD100xBuffer[i]._Data._GP1 = Convert.ToSingle(dt1.Rows[j]["GP1"]);
                        _XD100xBuffer[i]._Data._BP1 = Convert.ToSingle(dt1.Rows[j]["BP1"]);
                        _XD100xBuffer[i]._Data._WL = Convert.ToSingle(dt1.Rows[j]["WL"]);
                        _XD100xBuffer[i]._Data._GP2 = Convert.ToSingle(dt1.Rows[j]["GP2"]);
                        _XD100xBuffer[i]._Data._BP2 = Convert.ToSingle(dt1.Rows[j]["BP2"]);
                        _XD100xBuffer[i]._Data._BPB2 = Convert.ToSingle(dt1.Rows[j]["BPB2"]);

                        _XD100xBuffer[i]._Data._WI1 = Convert.ToSingle(dt1.Rows[j]["WI1"]);
                        _XD100xBuffer[i]._Data._WS1 = Convert.ToUInt32(dt1.Rows[j]["WS1"]);
                        _XD100xBuffer[i]._Data._HS1 = Convert.ToSingle(dt1.Rows[j]["HS1"]);
                        _XD100xBuffer[i]._Data._HI1 = Convert.ToDouble(dt1.Rows[j]["HI1"]);

                        _XD100xBuffer[i]._Data._WI3 = Convert.ToSingle(dt1.Rows[j]["WI3"]);
                        _XD100xBuffer[i]._Data._WS3 = Convert.ToUInt32(dt1.Rows[j]["WS3"]);

                        _XD100xBuffer[i]._Data._WI2 = Convert.ToSingle(dt1.Rows[j]["WI2"]);
                        _XD100xBuffer[i]._Data._WS2 = Convert.ToUInt32(dt1.Rows[j]["WS3"]);
                        _XD100xBuffer[i]._Data._HS2 = Convert.ToSingle(dt1.Rows[j]["HS2"]);
                        _XD100xBuffer[i]._Data._HI2 = Convert.ToDouble(dt1.Rows[j]["HI2"]);

                        _XD100xBuffer[i]._Data._PA2 = Convert.ToSingle(dt1.Rows[j]["PA2"]);
                        _XD100xBuffer[i]._Data._OD = Convert.ToSingle(dt1.Rows[j]["OD"]);

                        _XD100xBuffer[i]._Data._pump._CM1 = DataInfo.dttops(dt1.Rows[j]["CM1"].ToString());
                        _XD100xBuffer[i]._Data._pump._CM2 = DataInfo.dttops(dt1.Rows[j]["CM2"].ToString());
                        _XD100xBuffer[i]._Data._pump._CM3 = DataInfo.dttops(dt1.Rows[j]["CM3"].ToString());
                        _XD100xBuffer[i]._Data._pump._RM1 = DataInfo.dttops(dt1.Rows[j]["RM1"].ToString());
                        _XD100xBuffer[i]._Data._pump._RM2 = DataInfo.dttops(dt1.Rows[j]["RM2"].ToString());

                        byte[] alarm = { Convert.ToByte(_XD100xBuffer[i]._Data._alarm._word / 256), Convert.ToByte(_XD100xBuffer[i]._Data._alarm._word % 256) };
                        if (_XD100xBuffer[i]._Info._version == "xd100n")
                        {
                            _XD100xBuffer[i]._Data._alarm = xd100n.AlarmParse(alarm);
                        }
                        else
                        {
                            _XD100xBuffer[i]._Data._alarm = xd100.AlarmParse(alarm);
                        }
                        break;
                    }
                }
                
            }
        }
        #endregion

        //插入历史和报警数据
        #region
        public static void InsertSql(xd100x.XD100xBuffer bd)
        {           
            string str = string.Format("INSERT INTO tblGRData (DeviceID,DT,GT1,BT1,GT2,BT2,OT,GTB2,GP1,BP1,WL,GP2,BP2,BPB2,WI1,WS1,WI3,WS3,HS1,HI1,WI2,WS2,HS2,HI2,PA2,OD,CM1,CM2,CM3,RM1,RM2,AW) VALUES ({0},'{1}',{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},'{26}','{27}','{28}','{29}','{30}',{31})",
                bd._Info._id, bd._Data._dt, bd._Data._GT1, bd._Data._BT1, bd._Data._GT2, bd._Data._BT2, bd._Data._OT, bd._Data._GTB2, bd._Data._GP1, bd._Data._BP1, bd._Data._WL, bd._Data._GP2, bd._Data._BP2, bd._Data._BPB2, bd._Data._WI1, bd._Data._WS1, bd._Data._WI3, bd._Data._WS3, bd._Data._HS1, bd._Data._HI1, bd._Data._WI2, bd._Data._WS2, bd._Data._HS2, bd._Data._HI2, bd._Data._PA2, bd._Data._OD, bd._Data._pump._CM1, bd._Data._pump._CM2, bd._Data._pump._CM3, bd._Data._pump._RM1, bd._Data._pump._RM2, bd._Data._alarm._word);
            Tool.DB.runCmd(str);
            if (bd._Data._alarm._all == xd100x.GRAlarm.有)
            {
                str = string.Format("INSERT INTO tblGRAlarmData (DeviceID,DT,powercut,watboxdlow,watboxdhight,addPump2break,addPump1break,Pump3break,Pump2break,Pump1break,watboxalow,watboxahight,twoGiveTempH,oneGiveTempL,twoBackPressL,twoBackPressH,twoGivePressH,oneGivePressL) VALUES ({0},'{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}')",
                    bd._Info._id, bd._Data._dt, bd._Data._alarm._diaodian, bd._Data._alarm._kaiguandi, bd._Data._alarm._kaiguangao, bd._Data._alarm._bushuibeng2, bd._Data._alarm._bushuibeng1, bd._Data._alarm._xunhuanbeng3, bd._Data._alarm._xunhuanbeng2, bd._Data._alarm._xunhuanbeng1, bd._Data._alarm._shuiweidi, bd._Data._alarm._shuiweigao, bd._Data._alarm._ercigonggaowen, bd._Data._alarm._yicigongdiwen, bd._Data._alarm._ercihuidiya, bd._Data._alarm._ercihuigaoya,bd._Data._alarm._ercigonggaoya, bd._Data._alarm._yicigongdiya);
                Tool.DB.runCmd(str);
            }
        }
        #endregion

        //xd100x任务
        #region
        //xd100x发送任务
        public static void Polling_XD100xSend()
        {
            for (int i = 0; i < xd100x._XD100xBuffer.Length; i++)
            {
                for (int j = 0; j < xd100x._XD100xBuffer[i]._Command.Length; j++)
                {
                    //判断命令是否开启
                    if (xd100x._XD100xBuffer[i]._Command[j]._onoff == false)
                    {
                        continue;
                    }

                    //判断是否已发送
                    if (xd100x._XD100xBuffer[i]._Command[j]._send == false)
                    {
                        //检测ISocketRS是否被占用和是否连接 
                        Gprs.GprsList gl = Gprs.Get_GprsList(xd100x._XD100xBuffer[i]._Info._ip);
                        if (gl._Iscon == false || gl._Isbusy == true|| gl._activate==false)
                        {
                            continue;
                        }
                        bool send_flg = Gprs.Gprs_send(gl, xd100x._XD100xBuffer[i]._Command[j]._cmd);
                        if (send_flg == true)
                        {
                            xd100x._XD100xBuffer[i]._Command[j]._send = true;
                            xd100x._XD100xBuffer[i]._Command[j]._back = false;
                            xd100x._XD100xBuffer[i]._Command[j]._timeoutnow = 0;
                            xd100x._XD100xBuffer[i]._Command[j]._senddt = DateTime.Now;
                            xd100x._XD100xBuffer[i]._LastCommandIndex = j;
                            //占用ISocketRS
                            Gprs.Gprs_IsOccupy(xd100x._XD100xBuffer[i]._Info._ip, true);
                        }
                        //尝试发送没有成功 gprs已掉线 注销任务
                        else
                        {
                            xd100x._XD100xBuffer[i]._Command[j]._onoff = false;
                        }
                    }
                    //发送完成 开始计时 计算超时时间
                    else
                    {
                        xd100x._XD100xBuffer[i]._Command[j]._timeoutnow++;
                    }

                    //判断超时
                    if (xd100x._XD100xBuffer[i]._Command[j]._timeoutnow >= xd100x._XD100xBuffer[i]._Info._timeout)
                    {
                        xd100x._XD100xBuffer[i]._Command[j]._timeoutnow = 0;
                        xd100x._XD100xBuffer[i]._Command[j]._send = false;
                        //解除ISocketRS占用
                        Gprs.Gprs_IsOccupy(xd100x._XD100xBuffer[i]._Info._ip, false);
                        xd100x._XD100xBuffer[i]._Command[j]._retrytimesnow++;
                    }

                    //判断重试次数 超过次数 任务取消
                    if (xd100x._XD100xBuffer[i]._Command[j]._retrytimesnow >= xd100x._XD100xBuffer[i]._Info._retrytimes)
                    {
                        xd100x._XD100xBuffer[i]._Command[j]._retrytimesnow = 0;
                        xd100x._XD100xBuffer[i]._Command[j]._onoff=false;
                        xd100x._XD100xBuffer[i]._Info._state = false;
                    }

                }
            }
        }
        //xd100x存储任务
        public static void Polling_XD100xSave()
        {
            for (int i = 0; i < _XD100xBuffer.Length; i++)
            {
                if (_XD100xBuffer[i]._SaveDatas == true)
                {
                    _XD100xBuffer[i]._SaveDatas = false;
                    InsertSql(_XD100xBuffer[i]);
                    return;
                }
            }
        }
        //循环命令生成
        public static void Polling_XD100xCollect()
        {
            for (int i = 0; i < _XD100xBuffer.Length; i++)
            {
                if ((DateTime.Now-_XD100xBuffer[i]._Command[0]._senddt).TotalSeconds >= _XD100xBuffer[i]._Info._cycle * 60)
                {
                    _XD100xBuffer[i]._Command[0]._senddt = DateTime.Now;
                    _XD100xBuffer[i]._Command[0]._onoff = true;
                }
            }
        }
        #endregion
    }
}
