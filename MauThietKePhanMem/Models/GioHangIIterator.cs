using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MauThietKePhanMem.Models
{

    //public class Hang
    //{
    //    public MatHang gioHang { get; set; }
    //    public int _soLuongHang { get; set; }

    //}

    public interface IIterator
    {
        int TongTien();

        int Total();

        double sum();
    }


    public class GioHangIIterator : IIterator
    {

        public List<Hang> _listHang { get; } = new List<Hang>();
               
        public GioHangIIterator(List<Hang> listHang)
        {
            _listHang = listHang;
        }


       /* List<Hang> listHang = new List<Hang>();*/

        public IEnumerable<Hang> ListHang
        {
            get { return _listHang; }
        }

      
        public void Add(MatHang _matHang, int _soLuong = 1)
        {
            var i = _listHang.FirstOrDefault(s => s.gioHang.IDMH == _matHang.IDMH);
            if (i == null)
            {
                _listHang.Add(new Hang
                {
                    gioHang = _matHang,
                    _soLuongHang = _soLuong
                });
            }
            else
            {
                i._soLuongHang += _soLuong;
            }
        }

        public void Update_quantity(string id, int _quatity)
        {
            var i = _listHang.Find(s => s.gioHang.IDMH.ToString() == id);
            if (i != null)
            {
                i._soLuongHang = _quatity;
            }
        }

        public double sum()
        {
            var sum = _listHang.Sum(s => s._soLuongHang * 1);
            return sum;
        }

        public void Remove(int id)
        {
            _listHang.RemoveAll(s => s.gioHang.IDMH == id);
        }

        public int Total()
        {
            return _listHang.Sum(s => s._soLuongHang);
        }

        public int TongTien()
        {
            int tongtien = 0;
            foreach (Hang item in _listHang)
            {
                tongtien = tongtien + (int)(item.gioHang.DonGia * item._soLuongHang);
            }
            return tongtien;
        }

        public void clear()
        {
            _listHang.Clear();
        }

        public void ssss()
        {
            DateTime aDateTime = DateTime.Now;

            Console.WriteLine("Now is " + aDateTime);

            // Một khoảng thời gian. 
            // 1 giờ + 1 phút
            TimeSpan aInterval = new System.TimeSpan(0, 1, 1, 0);

            // Thêm một khoảng thời gian.
            DateTime newTime = aDateTime.Add(aInterval);
        }

         
    }
}