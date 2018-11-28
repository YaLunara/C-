using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace homework9
{
    public class Clawler//实现简单的网络爬虫
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;

        private void Crawl()
        {
            Console.WriteLine("开始爬行了......");
            while (true)
            {
                string current = null;
                foreach (String url in urls.Keys)//找到一个还没有下载过的链接
                {
                    if ((bool)urls[url]) continue;//已经下载过的，不再下载
                    current = url;
                }
                if (current == null || count > 10) break;

                Console.WriteLine("爬行" + current + "页面！");

                string html = DownLoad(current);//下载

                urls[current] = true;
                count++;

                Parse(html);//解析，并加入新的链接
            }
            Console.WriteLine("爬行结束");
        }

        public string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);

                string fireName = count.ToString();
                File.WriteAllText(fireName, html, Encoding.UTF8);
                return html;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }

        public void Parse(string html)
        {
            string strRef = @"(herf|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '#',' ','>');
                if (strRef.Length == 0) continue;

                if (urls[strRef] == null) urls[strRef] = false;
            }
        }
    } 
}
