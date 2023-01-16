using System.ComponentModel.DataAnnotations;

namespace Burikaigi.Shared
{
    public class 魚
    {
        [Key]
        public long Id { get; set; }
        public string? 名前 { get; set; }
        public string? 綱 { get; set; }
        public string? 目 { get; set; }
        public string? 科 { get; set; }
        public string? 属 { get; set; }
        public string? 生息環境 { get; set; }
        public string? 食性 { get; set; }
        public int 星 { get; set; }

        public string 星_表示() => string.Join("", Enumerable.Range(0, 星).Select(_ => "★"));
        public bool 星設定(string 星文字)
        {
            var count = 星文字.Where(e => e == '★').Count();
            if (5 < count) return false;
            星 = count;
            return true;
        }
    }
}
