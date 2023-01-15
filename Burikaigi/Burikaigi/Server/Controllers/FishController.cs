using Burikaigi.Server.Data;
using Burikaigi.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Burikaigi.Server.Controllers
{
    [Authorize, AutoValidateAntiforgeryToken]
    [ApiController]
    [Route("[controller]")]
    public class FishController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public FishController(ApplicationDbContext context)
        {
            _context = context;

            /*
            _context.魚.RemoveRange(_context.魚);
            var excel = ExcelReader.ReadExcel(@"c:\aaa\魚.xlsx");
            foreach (var row in excel.Values.First())
            {
                _context.魚.Add(new 魚
                {
                    名前 = row["A"],
                    綱 = row["B"],
                    目 = row["C"],
                    科 = row["D"],
                    属 = row["E"],
                    生息環境 = row["F"],
                    食性 = row["G"],
                    星 = int.Parse(row["H"]),
                });
            }
            _context.SaveChanges();
            */
        }
        //登録と検索

        [HttpGet]
        public async Task<魚[]> GetAsync()
            => await _context.魚.ToArrayAsync();
            /*
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
                星 = 5,
                }
            };
        }*/



    }
}