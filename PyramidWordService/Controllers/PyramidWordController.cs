using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PyramidWordService.Controllers
{
    public class PyramidWordController : ApiController
    {
        [HttpGet]
        public string get(string id)
        {
            return checkPyramidWord(id);
        }

        public string get()
        {
            return "Value can not be null";
        }

        public string checkPyramidWord(string s)
        {
            if (string.IsNullOrEmpty(s) || int.TryParse(s,out _))
                return "Value can not be null or number";
            char[] c = s.Trim().ToCharArray();
            int cnt=0;
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            for (int i = 0; i < c.Length; i++)
            {
                cnt = 1;
                for (int j = i + 1; j < c.Length; j++)
                {
                    if (charCount.ContainsKey(c[i]))
                        break;
                    if (c[i] == c[j])
                    {
                        cnt++;
                    }

                }
                if (!charCount.ContainsKey(c[i]))
                    charCount.Add(c[i], cnt);
            }

            if (charCount.OrderBy(i => i.Value).ElementAt(charCount.Count - 1).Value == charCount.OrderBy(i => i.Value).ElementAt(0).Value + charCount.Count - 1)
            {
                return "Pyramid word";
            }
            else
                return "Not a pyramid word";
        }
    }
}
