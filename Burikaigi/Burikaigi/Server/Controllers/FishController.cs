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
        //�o�^�ƌ���

        [HttpGet]
        public async Task<��[]> GetAsync()
            => await _context.��.ToArrayAsync();
            /*
        {
            return new[] {
                new ��
                {
                ���O = "�J�T�S",
                �j = "��h",
                �� = "�X�Y�L",
                �� = "���o��",
                �� = "�J�T�S",
                ������ = "���݂̊�ʈ�",
                �H�� = "��ɏ�����b�k��",
                �� = 5,
                }
            };
        }*/



    }
}