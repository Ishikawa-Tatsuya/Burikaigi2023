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
    public class FishApiController : ControllerBase
    {
        readonly ApplicationDbContext _context;

        public FishApiController(ApplicationDbContext context)
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

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(魚? newEntity)
        {
            if (newEntity == null) return Ok();

            var currentEntity = await _context.魚
                .Where(e=>e.Id == newEntity.Id)
                .FirstOrDefaultAsync();

            if (currentEntity == null)
            {
                _context.魚.Add(newEntity);
            }
            else
            {
                currentEntity.名前 = newEntity.名前;
                currentEntity.綱 = newEntity.綱;
                currentEntity.目 = newEntity.目;
                currentEntity.科 = newEntity.科;
                currentEntity.属 = newEntity.属;
                currentEntity.生息環境 = newEntity.生息環境;
                currentEntity.食性 = newEntity.食性;
                currentEntity.星 = newEntity.星;
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<魚?> GetAsync(long id)
            => await _context.魚
                    .Where(e => e.Id == id)
                    .FirstOrDefaultAsync();

        [HttpGet]
        public async Task<魚[]> GetAsync(string? name, string? @class, string? order, string? family, string? genus, string? star)
        {
            IQueryable<魚> query = _context.魚;
            if (!string.IsNullOrEmpty(name)) query = query.Where(e => e.名前 == name);
            if (!string.IsNullOrEmpty(@class)) query = query.Where(e => e.綱 == @class);
            if (!string.IsNullOrEmpty(order)) query = query.Where(e => e.目 == order);
            if (!string.IsNullOrEmpty(family)) query = query.Where(e => e.科 == family);
            if (!string.IsNullOrEmpty(genus)) query = query.Where(e => e.属 == genus);
            if (!string.IsNullOrEmpty(star))
            {
                var count = star.Where(e => e == '★').Count();
                query = query.Where(e => e.星 == count);
            }
            var x = await query.ToArrayAsync();

            return x;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            _context.魚.RemoveRange(_context.魚.Where(e => e.Id == id));
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}