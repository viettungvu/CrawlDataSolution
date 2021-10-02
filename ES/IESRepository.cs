using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Models.Responses;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES
{
    public class IESRepository
    {
        protected ElasticClient client;
        protected static Uri node = new Uri("http://localhost:9200");
        protected static StickyConnectionPool connectionPool = new(new[] { node });
        protected bool Index<T>(string _defaultIndex, T data, string route, string id = "") where T : class
        {
            IndexRequest<object> req = new(_defaultIndex, typeof(T));
            if (!string.IsNullOrEmpty(route))
                req.Routing = route;
            req.Document = data;
            IndexResponse re = null;
            if (!string.IsNullOrEmpty(id))
                re = client.Index(data, i => i.Id(id).Refresh(Refresh.True));
            else
                re = client.Index(req);
            return re.Result == Result.Created;
        }
        protected bool Update<T>(string _defaultIndex, T data, string id) where T : class
        {
            var res = client.Update<T>(id, p => p.Doc(data).Index(_defaultIndex).Refresh(Refresh.True));
            if (res.Result == Result.Error)
            {
                return Index(_defaultIndex, data, "");
            }
            return res.Result == Result.Updated;
        }
        protected bool Delete<T>(string _defaultIndex, string id) where T : class
        {
            var res = client.Delete<T>(id);
            return res.Result == Result.Deleted;
        }
    }
}
