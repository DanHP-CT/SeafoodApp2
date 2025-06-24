using System;
using System.Linq;

namespace SeafoodApp.Helpers
{
    /// <summary>
    /// Các hàm static để sinh mã tự động (số phiếu, số lô, …).
    /// </summary>
    public static class CodeHelper
    {
        /// <summary>
        /// Tạo mã mới theo prefix và lastCode.
        /// Ví dụ: Next("PM-", "PM-000123") => "PM-000124"
        /// Nếu lastCode null hoặc không đúng format sẽ sinh "PM-000001".
        /// </summary>
        public static string NextCode(string prefix, string? lastCode)
        {
            int nextNumber = 1;
            if (!string.IsNullOrEmpty(lastCode) && lastCode.StartsWith(prefix))
            {
                var numPart = lastCode.Substring(prefix.Length);
                if (int.TryParse(numPart, out var n))
                    nextNumber = n + 1;
            }
            // D6 = 6 chữ số, ví dụ 000001, 000123
            return prefix + nextNumber.ToString("D6");
        }

        /// <summary>
        /// Tạo số lô tiếp theo, ví dụ lastLot="LOT-000123" thì trả về "LOT-000124".
        /// Nếu lastLot null hoặc sai format thì trả về "LOT-000001".
        /// </summary>
        public static string NextLot(string prefix, string? lastLot)
        {
            int nextNumber = 1;
            if (!string.IsNullOrEmpty(lastLot) && lastLot.StartsWith(prefix))
            {
                var numPart = lastLot.Substring(prefix.Length);
                if (int.TryParse(numPart, out var n))
                    nextNumber = n + 1;
            }
            return prefix + nextNumber.ToString("D6");
        }
    }
}
