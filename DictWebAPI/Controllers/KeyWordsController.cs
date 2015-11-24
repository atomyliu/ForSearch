using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Model;

namespace DictWebAPI.Controllers
{
    public class KeyWordsController: ApiController
    {
        [HttpGet]
        public List<KeyWords> GetKeyWords()
        {
            return new List<KeyWords>() {
                new KeyWords() { TagId = "0000", Kwname = "中国" } ,
                new KeyWords() { TagId = "0001", Kwname = "美国" }
            };
        }
        [HttpGet]
        public string GetID(string id)
        {
            string ID = id;
            return ID;
        }
    }
}
