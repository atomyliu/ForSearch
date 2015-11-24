using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using common;
using System.Configuration;

namespace Elasticsearch_Finger
{    
    public partial class Default : System.Web.UI.Page
    {
        protected List<Nest.CatShardsRecord> slist = null;
        protected List<Nest.CatIndicesRecord> ilist = null;
        protected int inin = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                tbip.Text = connectString;
                string ip = tbip.Text.ToString();
                GetCluster(ip);
            }
        }
        private string connectString = ConfigurationManager.AppSettings["ESPath"].ToString();
        private void GetCluster(string ip)
        {
            var _client = ESHelper.Client(ip);
            var result = _client.ClusterHealth();
            var catindices = _client.CatIndices();
            var catnodes = _client.CatNodes();
            
            string shards = result.ActiveShards.ToString()+ " of "+(result.ActiveShards + result.UnassignedShards).ToString() ;
            lbcluster.Text = result.ClusterName.ToString();
            
            lbhealth.Text = result.Status.ToString()+" ("+ shards + ")";
            switch (result.Status.ToString())
            {
                case "green":
                    lbhealth.BackColor = System.Drawing.Color.Green;
                    break;
                case "yellow":
                    lbhealth.BackColor = System.Drawing.Color.Goldenrod;
                    break;
                case "red":
                    lbhealth.BackColor = System.Drawing.Color.Red;
                    break;
                default:
                    lbhealth.BackColor = System.Drawing.Color.Gray;
                    break;
            }
            
            ilist = catindices.Records.ToList();
            List<Nest.CatNodesRecord> nlist = catnodes.Records.ToList();
            slist = _client.CatShards().Records.ToList();
            

            rpindex.DataSource = ilist;
            rpindex.DataBind();
            rpnodes.DataSource = nlist;
            rpnodes.DataBind();
            //rpunassinged.DataSource = nlist;
            //rpunassinged.DataBind();
        }
        public string getMaster(string m)
        {
            string ma = "";
            switch (m)
            {
                case "*":
                    ma = "★";
                    break;
                case "m":
                    ma = "☆";
                    break;
                default:
                    break;
            }
            return ma;
        }
        public string getShard(string _index, string _node)
        {
            string s = "";
            s= string.Join(",", slist.Where(A => A.Index.Equals(_index) && !string.IsNullOrEmpty(A.Node)? A.Node.Equals(_node) : false).Select(A => A.Shard).ToArray());
            return s;
        }
        public string getunassignShard(string _index)
        {
            string s = "";
            s = string.Join(",", slist.Where(A => A.Index.Equals(_index) && A.State.Equals("UNASSIGNED")).Select(A => A.Shard).ToArray());
            return s;
        }
        public string getShardType(string _index, string _node)
        {
            string por = "";
            por = string.Join(",", slist.Where(A => A.Index.Equals(_index) && !string.IsNullOrEmpty(A.Node) ? A.Node.Equals(_node) : false).Select(A => A.PrimaryOrReplica).ToArray());
            return por;
        }
        public string getIndex(int i)
        {
            string index = "";
            index = ilist[i].Index.ToString();
            return index;
        }
        public string TDs(string _node)
        {
            string tds = "";
            for (int i = 0; i < ilist.Count(); i++)
            {
                string shard = getShard(getIndex(i), _node);
                string[] shards = shard.Split(',');
                string[] por = getShardType(getIndex(i), _node).Split(',');
                string sp = "";
                string spt = "";
                string shardstyle = "";
                for (int j = 0; j < shards.Count(); j++)
                {
                    spt = por[j].ToString();
                    switch (spt)
                    {
                        case "r":
                            shardstyle = "shard shard-normal";
                            break;
                        case "p":
                            shardstyle = "shard shard-normal shard-primary";
                            break;
                        default:
                            shardstyle = "shard";
                            break;
                    }
                    sp += string.Format("<span class=\"{0}\">{1}</span>", shardstyle, shards[j]);
                }
                string td = string.Format("<td><div>{0}</div></td>", sp);
                tds += td;
            }
            return tds;
        }
        public string TDsunassign()
        {
            string tds = "";
            for (int i = 0; i < ilist.Count(); i++)
            {
                string shard = getunassignShard(getIndex(i));
                string[] shards = shard.Split(',');
                string sp = "";
                string shardstyle = "shard";
                for (int j = 0; j < shards.Count(); j++)
                {
                    sp += string.Format("<span class=\"{0}\">{1}</span>", shardstyle, shards[j]);
                }
                string td = string.Format("<td><div>{0}</div></td>", sp);
                tds += td;
            }
            return tds;
        }
        public string THunassign()
        {
            string th = null;
            string un = "UNASSIGNED";
            foreach (string u in slist.Select(A => A.State).ToArray())
            {
                if (un == u)
                {
                    th = "<th>UNASSIGNED</th>";
                }
            }
            return th;
        }
    }
}