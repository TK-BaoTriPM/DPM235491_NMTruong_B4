using System;
using System.Collections.Generic;

namespace DPM235491_NMTruong_B4_DealGen_ExtractInterface_Real
{
    // REFACTORED: Interface định nghĩa hợp đồng gửi thông báo đơn hàng
    public interface INotificationService
    {
        string ServiceName { get; }
        bool SendNotification(string recipient, string message);
    }

    // Kênh gửi Email
    public class EmailNotificationService : INotificationService
    {
        public string ServiceName => "Email Service";

        public bool SendNotification(string recipient, string message)
        {
            Console.WriteLine($"[EMAIL -> {recipient}] {message}");
            return true;
        }
    }

    // Kênh gửi SMS
    public class SmsNotificationService : INotificationService
    {
        public string ServiceName => "SMS Gateway";

        public bool SendNotification(string recipient, string message)
        {
            Console.WriteLine($"[SMS -> {recipient}] {message}");
            return true;
        }
    }

    // Kênh gửi Push Notification ứng dụng mobile
    public class AppPushNotificationService : INotificationService
    {
        public string ServiceName => "Mobile App Push";

        public bool SendNotification(string recipient, string message)
        {
            Console.WriteLine($"[PUSH NOTIFICATION -> AppUser:{recipient}] {message}");
            return true;
        }
    }

    // OrderProcessor xử lý đơn hàng chỉ cần làm việc với Interface INotificationService
    public class OrderProcessor
    {
        private readonly List<INotificationService> _notifiers;

        public OrderProcessor(List<INotificationService> notifiers)
        {
            _notifiers = notifiers;
        }

        public void NotifyOrderStatus(string orderCode, string customerContact, string status)
        {
            string msg = $"Don hang {orderCode} cua ban hien tai: {status}. Cảm on ban da mua hang!";

            Console.WriteLine($"\n--- GUI THONG BAO CHO DON HANG {orderCode} ---");
            foreach (var notifier in _notifiers)
            {
                notifier.SendNotification(customerContact, msg);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== REAL PROJECT: Extract Interface cho He Thong Thong Bao E-Commerce ===");

            // Tiêm các lớp cài đặt vào danh sách Notifiers qua Interface
            var notifiers = new List<INotificationService>
            {
                new EmailNotificationService(),
                new SmsNotificationService(),
                new AppPushNotificationService()
            };

            OrderProcessor processor = new OrderProcessor(notifiers);
            processor.NotifyOrderStatus("DH-20261015-99", "0988123456 / truong@gmail.com", "Dang Giao Hang");

            Console.ReadKey();
        }
    }
}