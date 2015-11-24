using Elasticsearch.Net.ConnectionPool;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class Connect
    {
        /// <summary>
        /// 获取Eastic连接
        /// </summary>
        /// <returns></returns>
        public static ElasticClient GetSearchClient()
        {
            var connectString = ConfigurationManager.AppSettings["ESPath"].ToString();
            var nodesStr = connectString.Split('|');
            var nodes = nodesStr.Select(s => new Uri(s)).ToList();
            var connectionPool = new SniffingConnectionPool(nodes);
            var settings = new ConnectionSettings(connectionPool);
            var client = new ElasticClient(settings);
            return client;
        }
        
    }
}
