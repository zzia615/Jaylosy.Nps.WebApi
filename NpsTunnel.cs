namespace Jaylosy.Nps.WebApi
{
    public class NpsTunnel
    {
        /// <summary>
        /// 类型tcp udp httpProx socks5 secret p2p
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 服务端端口
        /// </summary>
        public int port { get; set; }
        /// <summary>
        /// 目标(ip:端口)
        /// </summary>
        public string target { get; set; }
        /// <summary>
        /// 客户端id
        /// </summary>
        public int client_id { get; set; }
        /// <summary>
        /// 隧道id
        /// </summary>
        public int? id { get; set; }
    }
}
