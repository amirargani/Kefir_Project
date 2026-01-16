using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Setting
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(40, ErrorMessage = "عنوان را بطور صحیح وارد کنید")]
    public string AbstractTitle { get; set; }
    [Required]
    public string AbstractText { get; set; }

    [Required]
    [MaxLength(40, ErrorMessage = "عنوان را بطور صحیح وارد کنید")]
    public string GalleryTitle { get; set; }
    [Required]
    public string GalleryText { get; set; }


    [Required]
    [MaxLength(40, ErrorMessage = "عنوان را بطور صحیح وارد کنید")]
    public string ExpertTitle { get; set; }
    [Required]
    public string ExpertText { get; set; }

    [Required]
    [MaxLength(40, ErrorMessage = "عنوان را بطور صحیح وارد کنید")]
    public string NewsTitle { get; set; }
    [Required]
    public string NewsText { get; set; }
    [Required]
    public int AwardCount { get; set; }
    [Required]
    public string AboutKefirTitle { get; set; }

    [Required]
    public string AboutKefirText { get; set; }
    [Required]
    public string CupTitle { get; set; }

    [Required]
    public string CupFirstTitle { get; set; }
    [Required]
    public float CupFirstPercent { get; set; }

    [Required]
    public string CupSecoundTitle { get; set; }
    [Required]
    public float CupSecoundPercent { get; set; }

    [Required]
    public string CupThirdTitle { get; set; }
    [Required]
    public float CupThirdPercent { get; set; }

    [Required]
    public string CupFourthTitle { get; set; }
    [Required]
    public float CupFourthPercent { get; set; }
}
