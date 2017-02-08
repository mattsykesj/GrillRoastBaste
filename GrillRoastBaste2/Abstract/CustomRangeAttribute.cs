using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GrillRoastBaste2.Models
{
    public class CustomRangeAttribute : RangeAttribute
    {
        public CustomRangeAttribute() : base(typeof(DateTime), DateTime.Now.ToShortDateString(),
            DateTime.Now.AddYears(20).ToShortDateString())
        { }


    }
}