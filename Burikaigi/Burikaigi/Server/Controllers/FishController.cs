using Burikaigi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Burikaigi.Server.Controllers
{
    [Authorize, AutoValidateAntiforgeryToken]
    [ApiController]
    [Route("[controller]")]
    public class FishController : ControllerBase
    {
        //登録と検索

        [HttpGet]
        public 魚[] Get()
        {
            return new[] {
                new 魚
                {
                名前 = "カサゴ",
                綱 = "条鰭",
                目 = "スズキ",
                科 = "メバル",
                属 = "カサゴ",
                生息環境 = "沿岸の岩礁域",
                食性 = "主に小魚や甲殻類",
                食味 = 5,
                }
            };
        }
    }
}