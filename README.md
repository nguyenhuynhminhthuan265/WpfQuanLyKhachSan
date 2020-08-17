# WpfQuanLyKhachSan
## Yêu cầu thiết lập môi trường, phần mềm và công cụ như sau để chạy ứng dụng:
- Hệ điều hành: **Microsoft Windows 7** trở lên.
- Đã cài đặt **.Net Framework 4.0** hoặc cao hơn.
- Để chạy ứng dụng trên localhost, máy tính cần cài đặt **Microsoft SQL Server**
phiên bản từ *2014* trở lên.
- Để triển khai ứng dụng cần có phần mềm IDE **Visual Studio** từ phiên bản *2017* trở
lên để thực hiện Build và Run.
## Các bước thiết lập, biên dịch, build để triển khai ứng dụng trên localhost:
- Mở project bằng **Visual Studio**, xóa hết tập tin trong thư mục `Migrations`,
mở **Package Manager Console**, chạy các lệnh `Enable-Migrations`,
`Add-Migration create-db`, `Update-Database` để tạo database gồm các bảng và quan hệ sinh ra từ code (*Code-First Entity Framework*).
- Tiếp đó chạy các câu lệnh script trong file script
`SQLQueryQuanLyKhachSan.sql` để khởi tạo dữ liệu cho database.
- Tiếp theo thực hiện *Build* kiểu **Release** cho project và *Run* trên **Visual
Studio** để chạy ứng dụng.
