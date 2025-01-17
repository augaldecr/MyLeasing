﻿using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MyVet.Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImage(IFormFile imageFile)
        {
            var guid = Guid.NewGuid().ToString();
            var file = $"{guid}.jpg";
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot\\images\\Pets",
                file);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return $"~/images/Pets/{file}";
        }
    }
}
