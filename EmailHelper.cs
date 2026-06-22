using System;

namespace QuanLySinhVien
{
    public static class EmailHelper
    {
        public static string BuildOtpHtml(string otp, string recipientEmail, string purpose = "xác thực")
        {
            return $@"<!DOCTYPE html>
<html>
<head><meta charset=""utf-8"">
<style>
  body{{font-family:'Segoe UI',Arial,sans-serif;background:#f4f6fb;margin:0;padding:0}}
  .wrap{{max-width:520px;margin:36px auto;background:#fff;border-radius:12px;box-shadow:0 4px 20px rgba(21,67,137,.13);overflow:hidden}}
  .hdr{{background:linear-gradient(135deg,#154389,#1e6abf);padding:28px 36px 22px;text-align:center}}
  .hdr h1{{color:#fff;font-size:20px;margin:0;letter-spacing:.5px}}
  .hdr p{{color:#b8d0f0;font-size:12px;margin:5px 0 0}}
  .body{{padding:32px 36px}}
  .body p{{color:#374151;font-size:15px;line-height:1.7;margin:0 0 12px}}
  .otp-box{{background:#f0f5ff;border:2px dashed #154389;border-radius:10px;text-align:center;padding:22px;margin:20px 0}}
  .otp-code{{font-size:44px;font-weight:700;letter-spacing:12px;color:#154389;font-family:'Courier New',monospace}}
  .otp-note{{font-size:12px;color:#6b7280;margin-top:8px}}
  .warn{{background:#fff7ed;border-left:4px solid #f59e0b;padding:12px 15px;border-radius:6px;font-size:13px;color:#92400e;margin-top:18px}}
  .ftr{{background:#f9fafb;padding:16px 36px;text-align:center;font-size:11px;color:#9ca3af;border-top:1px solid #e5e7eb}}
</style></head>
<body>
<div class=""wrap"">
  <div class=""hdr""><h1>🎓 HCM-UTE</h1><p>Hệ Thống Quản Lý Sinh Viên — HCMUTE</p></div>
  <div class=""body"">
    <p>Xin chào <strong>{recipientEmail}</strong>,</p>
    <p>Bạn vừa yêu cầu mã OTP để <strong>{purpose}</strong>. Đây là mã của bạn:</p>
    <div class=""otp-box"">
      <div class=""otp-code"">{otp}</div>
      <div class=""otp-note"">⏱️ Mã có hiệu lực trong <strong>5 phút</strong></div>
    </div>
    <div class=""warn"">⚠️ <strong>Lưu ý:</strong> Không chia sẻ mã này với bất kỳ ai. Nếu bạn không thực hiện yêu cầu này, hãy bỏ qua email này.</div>
  </div>
  <div class=""ftr"">© {DateTime.Now.Year} Trường ĐH Công Nghệ Kỹ Thuật TP.HCM — HCMUTE &nbsp;|&nbsp; Email tự động, vui lòng không phản hồi.</div>
</div>
</body></html>";
        }

        public static string BuildApprovalHtml(string name, string email, string username)
        {
            return $@"<!DOCTYPE html>
<html>
<head><meta charset=""utf-8"">
<style>
  body{{font-family:'Segoe UI',Arial,sans-serif;background:#f4f6fb;margin:0;padding:0}}
  .wrap{{max-width:520px;margin:36px auto;background:#fff;border-radius:12px;box-shadow:0 4px 20px rgba(21,67,137,.13);overflow:hidden}}
  .hdr{{background:linear-gradient(135deg,#154389,#1e6abf);padding:28px 36px 22px;text-align:center}}
  .hdr h1{{color:#fff;font-size:20px;margin:0}}
  .hdr p{{color:#b8d0f0;font-size:12px;margin:5px 0 0}}
  .body{{padding:32px 36px}}
  .body p{{color:#374151;font-size:15px;line-height:1.7;margin:0 0 12px}}
  .ok-box{{background:#f0fdf4;border-left:4px solid #22c55e;padding:14px 18px;border-radius:6px;margin:18px 0;font-size:14px;color:#166534}}
  .ftr{{background:#f9fafb;padding:16px 36px;text-align:center;font-size:11px;color:#9ca3af;border-top:1px solid #e5e7eb}}
</style></head>
<body>
<div class=""wrap"">
  <div class=""hdr""><h1>🎓 HCM-UTE</h1><p>Hệ Thống Quản Lý Sinh Viên — HCMUTE</p></div>
  <div class=""body"">
    <p>Xin chào <strong>{name}</strong>,</p>
    <p>Tài khoản của bạn đã được <strong>Admin phê duyệt</strong> thành công!</p>
    <div class=""ok-box"">✅ <strong>Tài khoản được kích hoạt</strong><br>Email: {email}<br>Tên đăng nhập: {username}</div>
    <p>Bạn có thể đăng nhập vào hệ thống ngay bây giờ. Chúc bạn học tập và làm việc hiệu quả!</p>
  </div>
  <div class=""ftr"">© {DateTime.Now.Year} HCMUTE &nbsp;|&nbsp; Email tự động, vui lòng không phản hồi.</div>
</div>
</body></html>";
        }
    }
}
