using System.ComponentModel.DataAnnotations;

namespace Burikaigi.Shared
{
    // 条鰭綱  スズキ目  メバル科  カサゴ属  カサゴ
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
        public int 食味 { get; set; }

        public string 食味_表示() => string.Join("", Enumerable.Range(0, 食味).Select(_ => "★"));
    }
}
