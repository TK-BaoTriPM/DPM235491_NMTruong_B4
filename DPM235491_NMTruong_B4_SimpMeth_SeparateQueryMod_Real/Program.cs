using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_SimpMeth_SeparateQueryMod_Real
{
    public class CouponManager
    {
        private Dictionary<string, bool> _vouchers = new Dictionary<string, bool>
        {
            { "SUMMER2026", true },  // true: chưa sử dụng
            { "VIP100", false }       // false: đã sử dụng
        };

        // QUERY: Kiểm tra mã giảm giá có hợp lệ không (Không thay đổi dữ liệu)
        public bool IsVoucherValid(string code)
        {
            return _vouchers.ContainsKey(code) && _vouchers[code] == true;
        }

        // MODIFIER: Đánh dấu mã giảm giá đã được áp dụng (Thay đổi trạng thái DB)
        public void MarkVoucherAsUsed(string code)
        {
            if (_vouchers.ContainsKey(code))
            {
                _vouchers[code] = false;
                Console.WriteLine($"[DB Update] Ma khuyen mai '{code}' da duoc chuyen sang trang thai DA SU DUNG.");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Quan Ly Voucher voi Separate Query from Modifier ===");

            CouponManager manager = new CouponManager();
            string codeInput = "SUMMER2026";

            // BƯỚC 1: Query (Xác nhận tính hợp lệ trước trên giao diện - an toàn, gọi nhiều lần không sao)
            if (manager.IsVoucherValid(codeInput))
            {
                Console.WriteLine($"-> Ma '{codeInput}' hop le! Duoc giam 15% cho don hang.");

                // BƯỚC 2: Modifier (Chỉ thực thi khi người dùng chính thức chốt Thanh toán)
                manager.MarkVoucherAsUsed(codeInput);
            }
            else
            {
                Console.WriteLine($"-> Ma '{codeInput}' khong hop le hoac da duoc su dung!");
            }

            Console.ReadKey();
        }
    }
}