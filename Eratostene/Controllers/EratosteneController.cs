using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EratosteneAPI.Controllers
{
    [Route("api/[controller]")]
    public class EratosteneController : Controller
    {
        [HttpGet("{n}")]
        public ActionResult<bool[]> Get(int n)
        {
            bool[] values = new bool[n + 1];

            values[0] = false;
            for (int i = 1; i < values.Length; i++) values[i] = true;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (!values[i]) continue;

                for (int j = 2 * i; j <= n; j += i)
                {
                    if (values[j]) values[j] = false;
                }
            }

            return values;
        }
    }
}

