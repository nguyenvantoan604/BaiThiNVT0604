using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BaiThiNVT.Models;
[Table("NVTCau3")]
public class NVTCau3{
    [Key]
    public string IDNhanVien {get;set;}
    public string TenNhanVien {get;set;}
    public int TuoiNhanVien {get;set;}
}