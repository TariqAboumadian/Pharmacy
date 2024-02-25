using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.Application.Services
{
    public class FileSetings
    {
        public const string imagespath = "/assets/Images/Medicine";
        public const string allowedextensions = ".jpg,.jpeg,.png";
        public const int MaxFilleSizeInMB = 1;
        public const int MaxFilleSizeInBytes = MaxFilleSizeInMB * 1024 * 1024;
    }
}
