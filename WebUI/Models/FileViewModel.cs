using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace WebUI.Models
{
    public class FileViewModel
    {
        public IEnumerable<File> Files { get; set; }

        public string Key;

    }
}