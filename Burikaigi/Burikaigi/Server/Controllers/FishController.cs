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
        //�o�^�ƌ���

        [HttpGet]
        public ��[] Get()
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
                �H�� = 5,
                }
            };
        }
    }
}