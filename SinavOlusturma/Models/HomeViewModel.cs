using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SinavOlusturma.Models
{
    public class HomeViewModel
    {
        public List<string> headers { get; set; }
        public List<string> contents { get; set; }
    }
}
