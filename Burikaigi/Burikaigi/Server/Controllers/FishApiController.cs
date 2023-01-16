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
            _context.��.RemoveRange(_context.��);
            var excel = ExcelReader.ReadExcel(@"c:\aaa\��.xlsx");
            foreach (var row in excel.Values.First())
            {
                _context.��.Add(new ��
                {
                    ���O = row["A"],
                    �j = row["B"],
                    �� = row["C"],
                    �� = row["D"],
                    �� = row["E"],
                    ������ = row["F"],
                    �H�� = row["G"],
                    �� = int.Parse(row["H"]),
                });
            }
            _context.SaveChanges();
            */
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(��? newEntity)
        {
            if (newEntity == null) return Ok();

            var currentEntity = await _context.��
                .Where(e=>e.Id == newEntity.Id)
                .FirstOrDefaultAsync();

            if (currentEntity == null)
            {
                _context.��.Add(newEntity);
            }
            else
            {
                currentEntity.���O = newEntity.���O;
                currentEntity.�j = newEntity.�j;
                currentEntity.�� = newEntity.��;
                currentEntity.�� = newEntity.��;
                currentEntity.�� = newEntity.��;
                currentEntity.������ = newEntity.������;
                currentEntity.�H�� = newEntity.�H��;
                currentEntity.�� = newEntity.��;
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<��?> GetAsync(long id)
            => await _context.��
                    .Where(e => e.Id == id)
                    .FirstOrDefaultAsync();

        [HttpGet]
        public async Task<��[]> GetAsync(string? name, string? @class, string? order, string? family, string? genus, string? star)
        {
            IQueryable<��> query = _context.��;
            if (!string.IsNullOrEmpty(name)) query = query.Where(e => e.���O == name);
            if (!string.IsNullOrEmpty(@class)) query = query.Where(e => e.�j == @class);
            if (!string.IsNullOrEmpty(order)) query = query.Where(e => e.�� == order);
            if (!string.IsNullOrEmpty(family)) query = query.Where(e => e.�� == family);
            if (!string.IsNullOrEmpty(genus)) query = query.Where(e => e.�� == genus);
            if (!string.IsNullOrEmpty(star))
            {
                var count = star.Where(e => e == '��').Count();
                query = query.Where(e => e.�� == count);
            }
            var x = await query.ToArrayAsync();

            return x;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            _context.��.RemoveRange(_context.��.Where(e => e.Id == id));
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}