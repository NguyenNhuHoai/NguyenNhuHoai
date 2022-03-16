using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan4_NguyenNhuHoai.Models;

namespace Tuan4_NguyenNhuHoai.Controllers
{
    public class GioHangController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        // GET: GioHang
        public List<GioHang> Laygiohang()
        {
            List<GioHang> listGioHang = Session["Giohang"] as List<GioHang>;
            if(listGioHang == null)
            {
                listGioHang = new List<GioHang>();
                Session["Giohang"] = listGioHang;
            }
            return listGioHang;
        }

        public ActionResult ThemGioHang(int id, string strURL)
        {
            List<GioHang> listGioHang = Laygiohang();
            GioHang sanpham = listGioHang.Find(n => n.masach == id);
            if(sanpham == null)
            {
                sanpham = new GioHang(id);
                listGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }

        public int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang != null)
            {
                tsl = listGioHang.Sum(n => n.iSoLuong);
            }
            return tsl;
        }

        public int TongSoLuongSanPham()
        {
            int tsl = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang != null)
            {
                tsl = listGioHang.Count;
            }
            return tsl;
        }

        public double TongTien()
        {
            double tt = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang != null)
            {
                tt = listGioHang.Sum(n => n.dThanhTien);
            }
            return tt;
        }

        public ActionResult GioHang()
        {
            List<GioHang> listGioHang = new List<GioHang>();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return View(listGioHang);
        }

        public ActionResult GioHangPartial()
        {
            List<GioHang> listGioHang = new List<GioHang>();
            ViewBag.Tongsoluong = TongSoLuong();
            ViewBag.Tongtien = TongTien();
            ViewBag.Tongsoluongsanpham = TongSoLuongSanPham();
            return PartialView();
        }

        public ActionResult XoaGioHang(int id)
        {
            List<GioHang> listGioHang = Laygiohang();
            GioHang sanpham = listGioHang.SingleOrDefault(n => n.masach == id);
            if(sanpham != null)
            {
                listGioHang.RemoveAll(n => n.masach == id);
                return RedirectToAction("GioHang");
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult CapNhatGioHang(int id, FormCollection collection)
        {
            List<GioHang> listGioHang = Laygiohang();
            GioHang sanpham = listGioHang.SingleOrDefault(n => n.masach == id);
            if(sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(collection["txtSoLg"].ToString());
            }
            return RedirectToAction("GioHang");
        }

        public ActionResult XoaTatCaGioHang()
        {
            List<GioHang> listGioHang = Laygiohang();
            listGioHang.Clear();
            return RedirectToAction("GioHang");
        }
    }
}