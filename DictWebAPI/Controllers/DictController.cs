using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using common;
namespace DictWebAPI.Controllers
{
    public class DictController : ApiController
    {
        /// <summary>
        /// 分词字典
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        public HttpResponseMessage getCustomDict()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            string filepath = AppDomain.CurrentDomain.BaseDirectory;
            string filename = filepath + "\\Dicts\\updict.dic";
            FileInfo fileinfo = new FileInfo(filename);
            if (fileinfo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            string etag = string.Format("\"{0}\"", GetMD5.GetMD5HashFromFile(filename));
            var tag = Request.Headers.IfNoneMatch.FirstOrDefault();
            if (Request.Headers.IfModifiedSince.HasValue && tag != null && tag.Tag == etag)
            {
                response.StatusCode = HttpStatusCode.NotModified;
            }
            else
            {
                FileStream fs = fileinfo.OpenRead();
                MemoryStream responseStream = new MemoryStream();
                bool fullContent = true;

                if (this.Request.Headers.Range != null)
                {
                    fullContent = false;
                    RangeItemHeaderValue range = this.Request.Headers.Range.Ranges.First();
                    if (range.From != null)
                    {
                        fs.Seek(range.From.Value, SeekOrigin.Begin);
                        if (range.From == 0 && (range.To == null || range.To >= fs.Length))
                        {
                            fs.CopyTo(responseStream);
                            fullContent = true;
                        }
                    }
                    if (range.To != null)
                    {
                        if (range.From != null)
                        {
                            long? rangeLength = range.To - range.From;
                            int length = (int)Math.Min(rangeLength.Value, fs.Length - range.From.Value);
                            byte[] buffer = new byte[length];
                            fs.Read(buffer, 0, length);
                            responseStream.Write(buffer, 0, length);
                        }
                        else
                        {
                            int length = (int)Math.Min(range.To.Value, fs.Length);
                            byte[] buffer = new byte[length];
                            fs.Read(buffer, 0, length);
                            responseStream.Write(buffer, 0, length);
                        }
                    }
                    else
                    {
                        if (range.From != null)
                        {
                            if (range.From < fs.Length)
                            {
                                int length = (int)(fs.Length - range.From.Value);
                                byte[] buffer = new byte[length];
                                fs.Read(buffer, 0, length);
                                responseStream.Write(buffer, 0, length);
                            }
                        }
                    }
                }
                else
                {
                    fs.CopyTo(responseStream);
                }
                fs.Close();
                responseStream.Position = 0;
                response.StatusCode = fullContent ? HttpStatusCode.OK : HttpStatusCode.PartialContent;
                response.Content = new StreamContent(responseStream);
                response.Headers.ETag = new EntityTagHeaderValue(etag);
                response.Headers.CacheControl = new CacheControlHeaderValue();
                response.Headers.CacheControl.Public = true;
                response.Headers.CacheControl.MaxAge = TimeSpan.FromHours(24);
                response.Content.Headers.Expires = DateTimeOffset.Now.AddDays(1);
                response.Content.Headers.LastModified = fileinfo.LastWriteTime;
            }
            return response;
        }
        /// <summary>
        /// 分词结束字典
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET", "HEAD")]
        public HttpResponseMessage getExtStopWordDict()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            string filepath = AppDomain.CurrentDomain.BaseDirectory;
            string filename = filepath + "\\Dicts\\ext_stopword.dic";
            FileInfo fileinfo = new FileInfo(filename);
            if (fileinfo == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            string etag = string.Format("\"{0}\"", GetMD5.GetMD5HashFromFile(filename));
            var tag = Request.Headers.IfNoneMatch.FirstOrDefault();
            if (Request.Headers.IfModifiedSince.HasValue && tag != null && tag.Tag == etag)
            {
                response.StatusCode = HttpStatusCode.NotModified;
            }
            else
            {
                FileStream fs = fileinfo.OpenRead();
                MemoryStream responseStream = new MemoryStream();
                bool fullContent = true;

                if (this.Request.Headers.Range != null)
                {
                    fullContent = false;
                    RangeItemHeaderValue range = this.Request.Headers.Range.Ranges.First();
                    if (range.From != null)
                    {
                        fs.Seek(range.From.Value, SeekOrigin.Begin);
                        if (range.From == 0 && (range.To == null || range.To >= fs.Length))
                        {
                            fs.CopyTo(responseStream);
                            fullContent = true;
                        }
                    }
                    if (range.To != null)
                    {
                        if (range.From != null)
                        {
                            long? rangeLength = range.To - range.From;
                            int length = (int)Math.Min(rangeLength.Value, fs.Length - range.From.Value);
                            byte[] buffer = new byte[length];
                            fs.Read(buffer, 0, length);
                            responseStream.Write(buffer, 0, length);
                        }
                        else
                        {
                            int length = (int)Math.Min(range.To.Value, fs.Length);
                            byte[] buffer = new byte[length];
                            fs.Read(buffer, 0, length);
                            responseStream.Write(buffer, 0, length);
                        }
                    }
                    else
                    {
                        if (range.From != null)
                        {
                            if (range.From < fs.Length)
                            {
                                int length = (int)(fs.Length - range.From.Value);
                                byte[] buffer = new byte[length];
                                fs.Read(buffer, 0, length);
                                responseStream.Write(buffer, 0, length);
                            }
                        }
                    }
                }
                else
                {
                    fs.CopyTo(responseStream);
                }
                fs.Close();
                responseStream.Position = 0;
                response.StatusCode = fullContent ? HttpStatusCode.OK : HttpStatusCode.PartialContent;
                response.Content = new StreamContent(responseStream);
                response.Headers.ETag = new EntityTagHeaderValue(etag);
                response.Headers.CacheControl = new CacheControlHeaderValue();
                response.Headers.CacheControl.Public = true;
                response.Headers.CacheControl.MaxAge = TimeSpan.FromHours(24);
                response.Content.Headers.Expires = DateTimeOffset.Now.AddDays(1);
                response.Content.Headers.LastModified = fileinfo.LastWriteTime;
            }
            return response;
        }
    }
}
