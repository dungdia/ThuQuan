﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopClient.DTO.ApiRequestDTO
{
    public class ThanhVienRequestDTO
    {
        public string username { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string hoten { get; set; }

        public string sodienthoai { get; set; }

        public int vaitro { get; set; }

        
        public string ToString()
        {
            return "ThanhVienRequestDTO{" +
            "username='" + username + '\'' +
            ", password='" + password + '\'' +
            ", email='" + email + '\'' +
            ", hoten='" + hoten + '\'' +
            ", sodienthoai='" + sodienthoai + '\'' +
            ", vaitro=" + vaitro +
            '}';
        }
    }
}
