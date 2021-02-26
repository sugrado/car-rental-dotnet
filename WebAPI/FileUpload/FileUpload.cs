using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.FileUpload
{
    public class FileUpload
    {
        public FormFile files { get; set; }
    }
}