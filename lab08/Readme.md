# COMP1019 - Lab 08: Simple Paint

## 1. Giới thiệu
Dự án này là bài thực hành Lab 08 thuộc môn học Lập trình trên Windows (COMP1019). Ứng dụng là một phần mềm Paint đơn giản được xây dựng bằng C# và Windows Forms, cho phép người dùng tương tác bằng chuột để vẽ các hình học cơ bản, đổi màu sắc, tùy chỉnh độ dày nét vẽ, cũng như thực hiện các chức năng hoàn tác (Undo) và xóa toàn bộ màn hình (Clear)[cite: 4].

## 2. Hướng dẫn chạy chương trình
1. Đảm bảo máy tính đã cài đặt **Visual Studio 2022** (hoặc phiên bản tương đương) có tích hợp workload **.NET Desktop Development**.
2. Dự án được thiết lập sử dụng framework **.NET 10.0** (như cấu hình trong file `lab08.csproj`)[cite: 6].
3. Mở file `lab08.csproj` bằng Visual Studio.
4. Nhấn phím **F5** hoặc click nút **Start** để biên dịch và khởi chạy ứng dụng.
5. Thao tác trên giao diện:
   - Sử dụng thanh công cụ trên cùng để chọn chế độ vẽ (Mode), chỉnh độ dày nét vẽ (Width) từ 1-20, và chọn màu sắc (Color)[cite: 4].
   - Click và kéo thả chuột trên vùng nền trắng để vẽ[cite: 4].
   - Nhấn **Undo** để xóa nét vẽ gần nhất, hoặc **Clear** để xóa toàn bộ vùng vẽ[cite: 4].

## 3. Mô tả cấu trúc mã nguồn
Ứng dụng được thiết kế theo hướng đối tượng với các thành phần chính sau đây:

* **`DrawMode.cs`**: Định nghĩa `enum` `DrawMode` chứa 4 chế độ vẽ cơ bản: `Pen` (bút vẽ tự do), `Line` (đường thẳng), `Rectangle` (hình chữ nhật), và `Ellipse` (hình elip)[cite: 2].
* **`DrawItem.cs`**: Lớp `DrawItem` đóng vai trò lưu trữ trạng thái của một nét vẽ. Nó chứa các thuộc tính: chế độ vẽ (`Mode`), tọa độ bắt đầu (`Start`) và kết thúc (`End`), màu sắc (`Color`), độ dày (`Width`), và danh sách các điểm `Points` (dành riêng cho chế độ vẽ tự do `Pen`)[cite: 1].
* **`DrawSurface.cs`**: Một class kế thừa từ `Panel` dùng làm vùng vẽ (canvas)[cite: 3]. Thuộc tính `DoubleBuffered = true` được kích hoạt sẵn để khắc phục hiện tượng nhấp nháy (flickering) khi ứng dụng phải vẽ lại (repaint) liên tục trong quá trình kéo chuột[cite: 3].
* **`FrmPaint.cs`**: Form chính của ứng dụng chứa toàn bộ logic tương tác:
  * **Khởi tạo UI**: Giao diện được tạo động hoàn toàn bằng code thông qua hàm `BuildUserInterface()`, bao gồm `ComboBox`, `NumericUpDown`, các nút bấm, và một `Label` hiển thị trạng thái ở cuối Form[cite: 4].
  * **Sự kiện Chuột (Mouse Events)**: 
    * `Canvas_MouseDown`: Ghi nhận thao tác click chuột trái, đánh dấu trạng thái `isDrawing = true`, và tạo một `DrawItem` mới để bắt đầu lưu dữ liệu[cite: 4].
    * `Canvas_MouseMove`: Cập nhật tọa độ điểm kết thúc `End`, thêm tọa độ vào danh sách `Points` nếu đang dùng `Pen`. Gọi `canvas.Invalidate()` để kích hoạt sự kiện vẽ nháp. Đồng thời, liên tục cập nhật tọa độ X, Y của chuột lên Status Label[cite: 4].
    * `Canvas_MouseUp`: Hoàn tất nét vẽ, đưa `DrawItem` vào danh sách `items` và đặt lại trạng thái vẽ[cite: 4].
  * **Sự kiện `Paint`**: Hàm `Canvas_Paint` duyệt qua toàn bộ danh sách `items` đã lưu để vẽ lại mọi thứ lên đồ họa (`e.Graphics`)[cite: 4]. Cơ chế này đảm bảo các hình vẽ cũ không bị biến mất khi Form bị resize hoặc bị các cửa sổ khác che khuất[cite: 4]. Phương thức `DrawOneItem()` sử dụng `using Pen` để cấp phát và tự động giải phóng bộ nhớ đồ họa một cách an toàn[cite: 4].

## 4. Minh chứng hoạt động (Screenshots)

**1. Vẽ 4 loại hình cơ bản (Pen, Line, Rectangle, Ellipse)**
> Thay bằng ảnh chụp màn hình cho thấy bạn đã dùng đủ 4 chế độ vẽ.
> `![Bốn loại hình](1.png)`

**2. Đổi màu sắc (Color) và độ dày (Width)**
> Thay bằng ảnh chụp màn hình sử dụng hộp thoại ColorDialog và nét vẽ có độ dày khác nhau.
> `![Đổi màu và độ dày](2.png)`

**3. Hiển thị tọa độ chuột và Hoàn tác (Undo/Clear)**
> Thay bằng ảnh chụp màn hình hiển thị tọa độ X, Y cập nhật ở góc dưới cùng bên trái (Label trạng thái).
> `![Hiển thị tọa độ](3.png)`