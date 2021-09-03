namespace Jaylosy.Nps.WebApi
{
    /// <summary>
    /// NPS域名
    /// </summary>
    public class NpsHost
    {
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 域名
        /// </summary>
        public string host { get; set; }
        /// <summary>
        /// 协议类型(三种 all http https)
        /// </summary>
        public string scheme { get; set; }
        /// <summary>
        /// url路由 空则为不限制
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// 客户端id
        /// </summary>
        public int client_id { get; set; }
        /// <summary>
        /// 内网目标(ip:端口)
        /// </summary>
        public string target { get; set; }
        /// <summary>
        /// request header 请求头
        /// </summary>
        public string header { get; set; }
        /// <summary>
        /// request host 请求主机
        /// </summary>
        public string hostchange { get; set; }
        /// <summary>
        /// 需要修改的域名解析id
        /// </summary>
        public int? id { get; set; }
    }
}
