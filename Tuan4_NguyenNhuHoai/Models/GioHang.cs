using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Tuan4_NguyenNhuHoai.Models;
namespace Tuan4_NguyenNhuHoai.Models
{
    public class GioHang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int masach { get; set; }

        [Display(Name = "Tên sách")]
        public string tensach { get; set; }

        [Display(Name ="Ảnh bìa")]
        public string hinh { get; set; }
        [Display(Name ="Giá bán")]
        public double giaban { get; set; }
        [Display (Name ="Số lượng")]
        public int iSoLuong { get; set; }
        [Display(Name ="Thành tiền")]
        public double dThanhTien
        {
            get { return iSoLuong * giaban; }
        }
        public GioHang(int id)
        {
            masach = id;
            Sach sach = data.Saches.Single(n => n.masach == masach);
            tensach = sach.tensach;
            hinh = sach.hinh;
            giaban = double.Parse(sach.giaban.ToString());
            iSoLuong = 1;
        }
    }
}