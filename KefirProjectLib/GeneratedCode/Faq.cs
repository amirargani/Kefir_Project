using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Faq
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage ="متن سوال را وارد نمایید")]
    public string QuestionText { get; set; }
    public string Answer { get; set; }
}
