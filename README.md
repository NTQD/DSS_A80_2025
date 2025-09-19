# DSS – Hỗ trợ lựa chọn vị trí xem Concert A80 🎶
Dự án “Xây dựng hệ thống DSS hỗ trợ lựa chọn vị trí tham gia Concert Quốc Gia A80 tại Hà Nội” được thiết kế nhằm đáp ứng nhu cầu thực tiễn của quần chúng nhân dân trong việc đưa ra quyết định lựa chọn vị trí tối ưu để quan sát và cổ vũ các đoàn diễu binh .

## Giới thiệu

Dự án này xây dựng một **Hệ hỗ trợ ra quyết định (Decision Support System – DSS)** nhằm tư vấn cho người dùng vị trí đẹp nhất để tham gia **Concert Quốc Gia A80 tại Hà Nội**.
Hệ thống tính toán điểm số cho từng vị trí dựa trên dữ liệu thực tế (khoảng cách, bãi đỗ xe, tuyến xe buýt, sức chứa, số khối diễu hành đi qua, v.v.) và ưu tiên cá nhân mà người dùng lựa chọn.

---

## Cơ chế bài toán

### Dữ liệu đầu vào

Mỗi vị trí $i$ trong danh sách sẽ có các thông tin:

* **Dist\_i**: khoảng cách đến vị trí người dùng
* **Parking\_i**: số bãi đỗ xe
* **Bus\_i**: số tuyến xe buýt đi qua
* **Cap\_i**: sức chứa ước lượng
* **SP\_i**: số điểm hỗ trợ/dịch vụ gần đó
* **Parade\_i**: số khối diễu hành đi qua
* **Area\_i**: diện tích khả dụng

---

### Chuẩn hóa dữ liệu

Đưa các giá trị về thang điểm \[0,1] bằng **Min–Max Normalization**:

* Với **tiêu chí lợi ích** (Benefit, càng lớn càng tốt):

$$
x'_i = \frac{x_i - x_{\min}}{x_{\max} - x_{\min}}
$$

* Với **tiêu chí chi phí** (Cost, càng nhỏ càng tốt, ví dụ Dist):

$$
d'_i = 1 - \frac{d_i - d_{\min}}{d_{\max} - d_{\min}}
$$

---

### Trọng số động (Dynamic Weights)

Trọng số không cố định, mà thay đổi theo nhu cầu người dùng:

1. **Khoảng cách (w\_dist):** phụ thuộc bán kính ưu tiên $R_{pref}$.
2. **Di chuyển (Mobility):**

   * Nếu chọn **công cộng** → ưu tiên số tuyến xe buýt.
   * Nếu chọn **cá nhân** → ưu tiên số bãi đỗ xe.
3. **Nhu cầu cá nhân (w\_parade):** ưu tiên nơi có nhiều khối diễu hành đi qua.
4. **Phần còn lại** chia cho các tiêu chí khác (Capacity, SP, Area).

---

### Công thức tính điểm

Điểm tổng hợp cho mỗi vị trí $i$:

$$
Score_i = w_{dist}\cdot dist'_i 
        + w_{parade}\cdot parade'_i 
        + w_{parking}\cdot park'_i 
        + w_{bus}\cdot bus'_i 
        + w_{cap}\cdot cap'_i 
        + w_{sp}\cdot sp'_i 
        + w_{area}\cdot area'_i
$$

Vị trí lý tưởng là vị trí có **Score lớn nhất**.

---

## Thuật toán (pseudocode)

```plaintext
Input: R_pref, mobility_type, parade_pref, dataset

1. Chuẩn hóa dữ liệu bằng Min–Max.
2. Tính trọng số dựa trên đầu vào người dùng.
3. Tính Score_i = SUMPRODUCT(normalized_values, weights).
4. Trả về danh sách vị trí, highlight Score cao nhất.
```

---

## Triển khai

* **Excel model:** Người dùng có thể nhập dữ liệu → hệ thống tự tính Score và xếp hạng.
* **Winform C#:** Áp dụng cùng công thức và thuật toán để xây dựng phần mềm có giao diện trực quan.

---

## Ý nghĩa

* **Cá nhân hoá:** mỗi người có kết quả riêng theo nhu cầu.
* **Minh bạch:** công thức rõ ràng, có thể kiểm chứng.
* **Mở rộng:** dễ thêm tiêu chí khác trong tương lai (mức độ đông đúc, an ninh, chi phí…).

---

👉 Đây là nền tảng cơ bản để phát triển thành một **DSS trực quan, thân thiện và đáng tin cậy** cho sự kiện A80.

