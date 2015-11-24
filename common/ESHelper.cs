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
    public class ESHelper
    {
        /// <summary>
        /// 获取Eastic连接
        /// </summary>
        /// <returns></returns>
        public static ElasticClient Client()
        {
            var connectString = ConfigurationManager.AppSettings["ESPath"].ToString();
            var nodesStr = connectString.Split('|');
            var nodes = nodesStr.Select(s => new Uri(s)).ToList();
            var connectionPool = new SniffingConnectionPool(nodes);
            var settings = new ConnectionSettings(connectionPool);
            var client = new ElasticClient(settings);
            return client;
        }
        /// <summary>
        /// 获取ES链接，nodeip可为多个，用'|'分割
        /// </summary>
        /// <param name="nodeip"></param>
        /// <returns></returns>
        public static ElasticClient Client(string nodeip)
        {
            var connectString = nodeip.ToString();
            var nodesStr = connectString.Split('|');
            var nodes = nodesStr.Select(s => new Uri(s)).ToList();
            var connectionPool = new SniffingConnectionPool(nodes);
            var settings = new ConnectionSettings(connectionPool);
            var client = new ElasticClient(settings);
            return client;
        }

        public static int CresteIndex(string indexname)
        {
            int count = 0;
            var settings = new IndexSettings();
            settings.NumberOfReplicas = 1;
            settings.NumberOfShards = 2;
            Client().CreateIndex(c => c
                .Index(indexname)
                .InitializeUsing(settings)
                );
            return count;
        }
        public static int CresteIndex(string indexname, int replicas, int shards)
        {
            int count = 0;
            var settings = new IndexSettings();
            settings.NumberOfReplicas = replicas;
            settings.NumberOfShards = shards;
            Client().CreateIndex(c => c
                .Index(indexname)
                .InitializeUsing(settings)
                );
            return count;
        }
        public static int CresteIndex(string indexname, int replicas, int shards,IndexSettings settings)
        {
            int count = 0;
            settings.NumberOfReplicas = replicas;
            settings.NumberOfShards = shards;
            Client().CreateIndex(c => c
                .Index(indexname)
                .InitializeUsing(settings)
                );
            return count;
        }

        public  static bool Delete(string node,string index, string type ,string id)
        {
            bool deleteed = false;
            try
            {
                var result = Client(node).Delete(new DeleteRequest(index, type, id));
                deleteed = result.Found;
            }
            catch (Exception)
            {

                throw;
            }
            return deleteed;
        }
        /// <summary>
        /// 删除doc
        /// </summary>
        /// <param name="index"></param>
        /// <param name="type"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Delete( string index, string type, string id)
        {
            bool deleteed = false;
            try
            {
                var result = Client().Delete(new DeleteRequest(index, type, id));
                deleteed = result.Found;
            }
            catch (Exception)
            {

                throw;
            }
            return deleteed;
        }

        public static string GetIndex()
        {
            return "";
        }

        public static int CresteType()
        {
            int count = 0;
            return count;
        }


    }
}
