
# Phát biểu bài toán DSS – Chọn vị trí lý tưởng tham dự sự kiện (Concert A80)

## 1. Mục tiêu
Xây dựng hệ thống hỗ trợ ra quyết định (Decision Support System – DSS) nhằm xác định **vị trí lý tưởng nhất để tham dự sự kiện** dựa trên nhiều tiêu chí khác nhau (khoảng cách, nhu cầu cá nhân, khả năng di chuyển, sức chứa…).  
Vị trí tối ưu là vị trí có **tổng điểm cao nhất** sau khi chuẩn hóa và áp dụng trọng số theo lựa chọn người dùng.

---

## 2. Các biến và dữ liệu (theo bảng của bạn)
Dữ liệu sẵn có (per location `i`):

- `Capacity_i`
- `Parking_i` (số bãi đỗ xe)
- `Bus_i` (số tuyến bus)
- `SP_i` (số điểm hỗ trợ)
- `Parade_i` (số khối đi qua)
- `Area_i`
- (bạn cần thêm) `Dist_i` = khoảng cách từ vị trí tham chiếu (người dùng nhập) tới vị trí `i` — nếu chưa có tọa độ thì bạn cần bổ sung lat/lon hoặc ước lượng khoảng cách.

---

## 3. Chuẩn hoá (normalize) — đưa mọi thứ về [0,1]

Dùng **Min–Max normalization**:

- Nếu tiêu chí là **benefit** (càng lớn càng tốt):

\[
x'_i = \frac{x_i - x_{\min}}{x_{\max} - x_{\min}}
\]

- Nếu tiêu chí là **cost** (càng nhỏ càng tốt) — ví dụ `Dist_i`:

\[
d'_i = 1 - \frac{d_i - d_{\min}}{d_{\max} - d_{\min}}
\]

Trong Excel:  
`=(A2-MIN(A$2:A$10))/(MAX(A$2:A$10)-MIN(A$2:A$10))`

---

## 4. Xác định trọng số động — ý tưởng chính

Chia tổng trọng số 1 thành ba nhóm chủ đạo:

- \( w_{dist} \): tầm quan trọng **khoảng cách** (biến thiên theo lựa chọn R_pref).
- \( w_{mob} \): tầm quan trọng **khả năng di chuyển** (chia thành `w_parking` và `w_bus` theo lựa chọn của người dùng).
- \( w_{pref} \): tầm quan trọng **nhu cầu cá nhân** (chủ yếu là `ParadeUnits`).

### Công thức
1. Người dùng nhập \(R_{pref}\) (bán kính ưu tiên, mét).

\[
importance_{dist} = clip\left(1 - \frac{R_{pref}}{R_{max}}, 0, 1\right)
\]

\[
w_{dist} = w_{dist\_max} \times importance_{dist}
\]

2. Người dùng chọn chế độ di chuyển:
   - **Công cộng**: \( w_{bus} = \alpha \cdot w_{mob} \), \( w_{parking} = (1-\alpha) \cdot w_{mob} \), với \(\alpha \approx 0.8\).
   - **Cá nhân**: \(\alpha\) nhỏ (ví dụ 0.2).

3. Người dùng nhập mức ưu tiên cá nhân \(p_{parade} \in [0,1]\):

\[
w_{parade} = w_{pref\_max} \times p_{parade}
\]

4. Phần còn lại: \( 1 - w_{dist} - w_{parade} \) chia cho `Capacity`, `SP`, `Area`, `Mobility`.

---

## 5. Công thức điểm tổng hợp (final composite score)

Sau chuẩn hóa, ký hiệu normalized values:  
`cap_i`, `park_i`, `bus_i`, `sp_i`, `parade_i`, `area_i`, `dist_i` (đều ∈ [0,1])

Công thức:

\[
Score_i = w_{dist} \cdot dist_i + w_{parade} \cdot parade_i + w_{parking} \cdot park_i + w_{bus} \cdot bus_i + w_{cap} \cdot cap_i + w_{sp} \cdot sp_i + w_{area} \cdot area_i
\]

Vị trí lý tưởng là vị trí có \(Score_i\) lớn nhất.

---

## 6. Triển khai trong Excel

1. Bảng dữ liệu: mỗi hàng 1 vị trí, các cột: `Capacity`, `Parking`, `Bus`, `SP`, `Parade`, `Area`, `Dist`.
2. Thêm cột normalize cho từng tiêu chí với Min–Max.
3. Các ô tham số: `R_pref`, `R_max`, `w_dist_max`, `w_pref_max`, `p_parade`, `alpha`…
4. Cột `Score` = `SUMPRODUCT(weights_range, normalized_values_range)`.
5. Sắp xếp theo `Score` giảm dần → top 1 là vị trí lý tưởng.

---

## 7. Lý do mô hình này có giá trị

- **Cá nhân hóa**: trọng số thay đổi theo lựa chọn người dùng.  
- **Khoảng cách động**: phản ánh thực tế mong muốn gần/xa của người dùng.  
- **Phân tách rõ nhu cầu**: mobility vs cá nhân.  
- **Minh bạch**: mọi bước đều hiển thị, dễ kiểm chứng.  
- **Khả năng mở rộng**: dễ tích hợp thêm ràng buộc và dữ liệu thời gian thực.
