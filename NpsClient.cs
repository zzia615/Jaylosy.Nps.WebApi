namespace Jaylosy.Nps.WebApi
{
    /// <summary>
    /// NPS客户端
    /// </summary>
    public class NpsClient
    {
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// basic权限认证用户名
        /// </summary>
        public string u { get; set; }
        /// <summary>
        /// basic权限认证密码
        /// </summary>
        public string p { get; set; }
        /// <summary>
        /// 条数(分页显示的条数)
        /// </summary>
        public int limit { get; set; }
        /// <summary>
        /// 客户端验证密钥
        /// </summary>
        public string vkey { get; set; }
        /// <summary>
        /// 是否允许客户端以配置文件模式连接 1允许 0不允许
        /// </summary>
        public int config_conn_allow { get; set; }
        /// <summary>
        /// 压缩1允许 0不允许
        /// </summary>
        public int compress { get; set; }
        /// <summary>
        /// 是否加密（1或者0）1允许 0不允许
        /// </summary>
        public int crypt { get; set; }
        /// <summary>
        /// 带宽限制 单位KB/S 空则为不限制
        /// </summary>
        public int? rate_limit { get; set; }
        /// <summary>
        /// 流量限制 单位M 空则为不限制
        /// </summary>
        public int? flow_limit { get; set; }
        /// <summary>
        /// 客户端最大连接数量 空则为不限制
        /// </summary>
        public int? max_conn { get; set; }
        /// <summary>
        /// 客户端最大隧道数量 空则为不限制
        /// </summary>
        public int? max_tunnel { get; set; }
        /// <summary>
        /// 要修改的客户端id
        /// </summary>
        public int? id { get; set; }
    }
}
