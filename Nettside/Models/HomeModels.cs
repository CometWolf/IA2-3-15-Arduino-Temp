using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models {
    public class HomeViewModel {
        public string temperature;
        [Display(Name = "Logging interval")]
        [Required]
        [Range(minimum:1,maximum:99999)]
        public string LogInterval { get; set; }
        [Display(Name = "Øvre grense")]
        [Required]
        public string AlarmUpperLimit { get; set; }
        [Display(Name = "Nedre grense")]
        [Required]
        public string AlarmLowerLimit { get; set; }
        [Display(Name = "Øvre grense")]
        [Required]
        public string FurnaceUpperLimit { get; set; }
        [Display(Name = "Nedre grense")]
        [Required]
        public string FurnaceLowerLimit { get; set; }
        public string alarmMessage;
        public string alarmHide = "hidden";
        public string AlarmId { get; set; }
    }
}