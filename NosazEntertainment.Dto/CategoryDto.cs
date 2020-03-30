using System;
using System.ComponentModel.DataAnnotations;

namespace NosazEntertainment.Dto
{
    public class CategoryDto: IBaseDto
    {

        public Guid Id { get; set; }

        [Required(ErrorMessage ="لطفا نام موضوع را وارد کنید")]
        [StringLength(100,ErrorMessage = "نام موضوع حداکثر 100 کاراکتر است")]
        public string Name { get; set; }
    }
}
