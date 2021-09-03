using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;

namespace Jaylosy.Nps.WebApi
{
    public class NpsUtil
    {
        string hostAddress;
        string authKey;
        public NpsUtil(string hostAddress,string authKey)
        {
            this.hostAddress = hostAddress;
            this.authKey = authKey;
        }
        /// <summary>
        /// 获取解析列表
        /// </summary>
        /// <param name="search">搜索</param>
        /// <param name="page">分页(第几页)</param>
        /// <param name="limit">条数(分页显示的条数)</param>
        public string GetHostList(string search, int page, int limit)
        {
            string url = $"{hostAddress}/index/hostlist";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("search", search);
            dataDict.Add("offset", (page - 1).ToString());
            dataDict.Add("limit", limit.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 新增解析
        /// </summary>
        /// <param name="host"></param>
        public string AddHost(NpsHost host)
        {
            string url = $"{hostAddress}/index/addhost";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("remark", host.remark);
            dataDict.Add("host", host.host);
            dataDict.Add("scheme", host.scheme);
            dataDict.Add("location", host.location);
            dataDict.Add("client_id", host.client_id.ToString());
            dataDict.Add("target", host.target);
            dataDict.Add("header", host.header);
            dataDict.Add("hostchange", host.hostchange);
            return Post(url, dataDict);
        }
        /// <summary>
        /// 修改解析
        /// </summary>
        /// <param name="host"></param>
        public string EditHost(NpsHost host)
        {
            string url = $"{hostAddress}/index/edithost";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("remark", host.remark);
            dataDict.Add("host", host.host);
            dataDict.Add("scheme", host.scheme);
            dataDict.Add("location", host.location);
            dataDict.Add("client_id", host.client_id.ToString());
            dataDict.Add("target", host.target);
            dataDict.Add("header", host.header);
            dataDict.Add("hostchange", host.hostchange);
            dataDict.Add("id", host.id?.ToString()); ;
            return Post(url, dataDict);
        }
        /// <summary>
        /// 删除解析
        /// </summary>
        /// <param name="id"></param>
        public string DeleteHost(int id)
        {
            string url = $"{hostAddress}/index/delhost";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("id", id.ToString());
            return Post(url, dataDict);
        }

        /// <summary>
        /// 获取单个隧道
        /// </summary>
        /// <param name="id">隧道ID</param>
        public string GetTunnel(int id)
        {
            string url = $"{hostAddress}/index/getonetunnel";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("id", id.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 获取隧道列表
        /// </summary>
        /// <param name="client_id">穿透隧道的客户端id</param>
        /// <param name="type">类型tcp udp httpProx socks5 secret p2p</param>
        /// <param name="search">搜索</param>
        /// <param name="page">分页(第几页)</param>
        /// <param name="limit">条数(分页显示的条数)</param>
        public string GetTunnelList(int?client_id,string type,string search,int page,int limit)
        {
            string url = $"{hostAddress}/index/gettunnel";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("client_id", client_id?.ToString());
            dataDict.Add("type", type);
            dataDict.Add("search", search);
            dataDict.Add("offset", (page - 1).ToString());
            dataDict.Add("limit", limit.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 新增隧道
        /// </summary>
        /// <param name="tunnel"></param>
        public string AddTunnel(NpsTunnel tunnel)
        {
            string url = $"{hostAddress}/index/add";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("type", tunnel.type);
            dataDict.Add("remark", tunnel.remark);
            dataDict.Add("port", tunnel.port.ToString());
            dataDict.Add("target", tunnel.target);
            dataDict.Add("client_id", tunnel.client_id.ToString());
            return Post(url, dataDict);
        }

        /// <summary>
        /// 编辑隧道
        /// </summary>
        /// <param name="tunnel"></param>
        public string EditTunnel(NpsTunnel tunnel)
        {
            string url = $"{hostAddress}/index/edit";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("type", tunnel.type);
            dataDict.Add("remark", tunnel.remark);
            dataDict.Add("port", tunnel.port.ToString());
            dataDict.Add("target", tunnel.target);
            dataDict.Add("client_id", tunnel.client_id.ToString());
            dataDict.Add("id", tunnel.id?.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 删除隧道
        /// </summary>
        /// <param name="id"></param>
        public string DeleteTunnel(int id)
        {
            string url = $"{hostAddress}/index/del";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("id", id.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 停止隧道
        /// </summary>
        /// <param name="id"></param>
        public string StopTunnel(int id)
        {
            string url = $"{hostAddress}/index/stop";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("id", id.ToString());
            return Post(url, dataDict);
        }

        /// <summary>
        /// 获取客户端列表
        /// </summary>
        /// <param name="search">搜索</param>
        /// <param name="page">分页(第几页)</param>
        /// <param name="limit">条数(分页显示的条数)</param>
        public string GetClientList(string search,int page,int limit)
        {
            string url = $"{hostAddress}/client/list";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("search", search);
            dataDict.Add("offset", (page-1).ToString());
            dataDict.Add("limit", limit.ToString());
            return Post(url, dataDict);

        }
        /// <summary>
        /// 获取单个客户端
        /// </summary>
        /// <param name="id">客户端id</param>
        public string GetClient(int id)
        {
            string url = $"{hostAddress}/client/getclient";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("id", id.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 新增客户端
        /// </summary>
        /// <param name="client"></param>
        public string AddClient(NpsClient client)
        {
            string url = $"{hostAddress}/client/add";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("remark", client.remark);
            dataDict.Add("u", client.u);
            dataDict.Add("p", client.p);
            dataDict.Add("limit", client.limit.ToString());
            dataDict.Add("vkey", client.vkey);
            dataDict.Add("config_conn_allow", client.config_conn_allow.ToString());
            dataDict.Add("compress", client.compress.ToString());
            dataDict.Add("crypt", client.crypt.ToString());
            dataDict.Add("rate_limit", client.rate_limit?.ToString());
            dataDict.Add("flow_limit", client.flow_limit?.ToString());
            dataDict.Add("max_conn", client.max_conn?.ToString());
            dataDict.Add("max_tunnel", client.max_tunnel?.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 修改客户端
        /// </summary>
        /// <param name="client"></param>
        public string EditClient(NpsClient client)
        {
            string url = $"{hostAddress}/client/edit";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("remark", client.remark);
            dataDict.Add("u", client.u);
            dataDict.Add("p", client.p);
            dataDict.Add("limit", client.limit.ToString());
            dataDict.Add("vkey", client.vkey);
            dataDict.Add("config_conn_allow", client.config_conn_allow.ToString());
            dataDict.Add("compress", client.compress.ToString());
            dataDict.Add("crypt", client.crypt.ToString());
            dataDict.Add("rate_limit", client.rate_limit?.ToString());
            dataDict.Add("flow_limit", client.flow_limit?.ToString());
            dataDict.Add("max_conn", client.max_conn?.ToString());
            dataDict.Add("max_tunnel", client.max_tunnel?.ToString());
            dataDict.Add("id", client.id?.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        public string DeleteClient(int id)
        {
            string url = $"{hostAddress}/client/del";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            dataDict.Add("id", id.ToString());
            return Post(url, dataDict);
        }
        /// <summary>
        /// 获取系统时间
        /// </summary>
        public string GetTime()
        {
            string url = $"{hostAddress}/auth/gettime";
            Dictionary<string, string> dataDict = new Dictionary<string, string>();
            return Post(url, dataDict);

        }
        /// <summary>
        /// POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>

        string Post(string url, Dictionary<string, string> data)
        {
            StringBuilder content = new StringBuilder();
            foreach(var dd in data)
            {
                if (content.Length > 0) content.Append("&");
                content.Append($"{dd.Key}={dd.Value}");
            }
            Dictionary<string, string> data2 = new Dictionary<string, string>();
            string timestamp = GetTimeStamp().ToString();
            data2.Add("auth_key", Md5(authKey+timestamp));
            data2.Add("timestamp", timestamp);
            foreach (var dd in data2)
            {
                if (content.Length > 0) content.Append("&");
                content.Append($"{dd.Key}={dd.Value}");
            }
            byte[] bytes = Encoding.UTF8.GetBytes(content.ToString());
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }

                using (var stream = request.GetResponse().GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                    return sr.ReadToEnd();
                }


            }
            catch (WebException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                GC.Collect();
            }
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        string Md5(string data)
        {
            try
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] bytValue, bytHash;
                bytValue = System.Text.Encoding.UTF8.GetBytes(data);
                bytHash = md5.ComputeHash(bytValue);
                md5.Clear();
                string sTemp = "";
                for (int i = 0; i < bytHash.Length; i++)
                {
                    sTemp += bytHash[i].ToString("X").PadLeft(2, '0');
                }
                return sTemp.ToLower();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 取时间戳，高并发情况下会有重复。想要解决这问题请使用sleep线程睡眠1毫秒。
        /// </summary>
        /// <param name="AccurateToMilliseconds">精确到毫秒</param>
        /// <returns>返回一个长整数时间戳</returns>
        long GetTimeStamp(bool AccurateToMilliseconds = false)
        {
            if (AccurateToMilliseconds)
            {

                // 使用当前时间计时周期数（636662920472315179）减去1970年01月01日计时周期数（621355968000000000）除去（删掉）后面4位计数（后四位计时单位小于毫秒，快到不要不要）再取整（去小数点）。

                //备注：DateTime.Now.ToUniversalTime不能缩写成DateTime.Now.Ticks，会有好几个小时的误差。

                //621355968000000000计算方法 long ticks = (new DateTime(1970, 1, 1, 8, 0, 0)).ToUniversalTime().Ticks;

                return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;

            }
            else
            {

                //上面是精确到毫秒，需要在最后除去（10000），这里只精确到秒，只要在10000后面加三个0即可（1秒等于1000毫米）。
                return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            }
        }
    }
}
