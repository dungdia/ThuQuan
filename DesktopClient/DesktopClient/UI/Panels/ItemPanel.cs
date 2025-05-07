using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopClient.APIs;
using DesktopClient.Models;
using DesktopClient.Contains;
using System.Net.Http.Headers;
using DesktopClient.UI.Dialog;
using System.Net.WebSockets;
using OfficeOpenXml;
using DesktopClient.Interface;

namespace DesktopClient.UI
{
    public partial class ItemPanel : UserControl,IChildPanel
    {
        List<VatDung> vatDungs = new List<VatDung>();
        public ItemPanel()
        {
            InitializeComponent();
            vatDungs = APIContext.GetMethod<VatDung>("VatDung")
                  .Where(v => v.tinhTrang != TinhTrangVatDung.Ẩn.ToString())
                  .ToList();
            dataGridView1.DataSource = vatDungs;
            dataGridView1.CellFormatting += cellFormatting;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["tenVatDung"].HeaderText = "Tên vật dụng";
            dataGridView1.Columns["hinhAnh"].Visible = false;
            dataGridView1.Columns["moTa"].HeaderText = "Mô tả";
            dataGridView1.Columns["id_LoaiVatDung"].HeaderText = "Loại vật dụng";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void cellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Check xem cột hiện tại có phải là cột "id_LoaiVatDung" không
            if (dataGridView1.Columns[e.ColumnIndex].Name == "id_LoaiVatDung" && e.Value != null)
            {
                // Đổi từ string sang int và check
                int idValue = Convert.ToInt32(e.Value);
                e.Value = idValue == 1 ? "Sách" : "Thiết bị";
                e.FormattingApplied = true;
            }
        }

        private void OptionEvent(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex < 0) return;
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        // Nút xóa vật dụng
        private void delete_item_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedVatDungs = dataGridView1.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(row => (VatDung)row.DataBoundItem)
                    .ToList();

                var deleteDialog = new DeleteVatDungDialog(selectedVatDungs)
                {
                    StartPosition = FormStartPosition.Manual
                };
                deleteDialog.Location = new Point(450, 100);

                // Lắng nghe sự kiện OnItemsDeleted
                deleteDialog.OnItemsDeleted += ReloadData;

                deleteDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn ít nhất một vật dụng cần xóa.");
            }
        }

        // Nút sửa vật dụng
        private void edit_item_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedVatDung = (VatDung)dataGridView1.SelectedRows[0].DataBoundItem;
                var editDialog = new EditVatDungDialog(selectedVatDung)
                {
                    StartPosition = FormStartPosition.Manual
                };
                editDialog.Location = new Point(this.Location.X + 500, this.Location.Y + 250); // Đặt vị trí hiển thị
                // Lắng nghe sự kiện OnItemsDeleted
                editDialog.OnItemUpdated += ReloadData;
                editDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một vật dụng để sửa.");
            }
        }

        // Nút thêm vật dụng
        private void add_item_Click(object sender, EventArgs e)
        {
            var addDialog = new AddVatDungDialog()
            {
                StartPosition = FormStartPosition.CenterParent // Đặt vị trí hiển thị ở giữa
            };
            // Lắng nghe sự kiện OnItemAdded
            addDialog.OnItemAdded += ReloadData;
            addDialog.ShowDialog();
        }

        // Nút thêm vật dụng bằng excel
        private void excel_btn_Click(object sender, EventArgs e)
        {
            // Tạo một luồng riêng để xử lý việc chọn và xử lý file Excel
            Thread staThread = new Thread(() =>
            {
                // Sử dụng OpenFileDialog để cho phép người dùng chọn file Excel
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";  // Lọc các file Excel
                    openFileDialog.Title = "Chọn file Excel";  // Tiêu đề của hộp thoại

                    // Kiểm tra xem người dùng đã chọn file hay chưa
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var filePath = openFileDialog.FileName;  // Lấy đường dẫn file đã chọn

                        try
                        {
                            // Cài đặt license cho EPPlus (thư viện xử lý Excel)
                            ExcelPackage.License.SetNonCommercialPersonal("Thêm vật dụng");

                            // Mở file Excel với đường dẫn đã chọn
                            using (var package = new ExcelPackage(new FileInfo(filePath)))
                            {
                                var worksheet = package.Workbook.Worksheets[0];  // Lấy worksheet đầu tiên từ file Excel
                                if (worksheet == null)
                                {
                                    throw new Exception("Không tìm thấy worksheet nào trong file Excel.");  // Nếu không có worksheet, báo lỗi
                                }

                                int rowCount = worksheet.Dimension?.Rows ?? 0;  // Lấy số lượng dòng dữ liệu trong worksheet
                                if (rowCount < 2)
                                {
                                    throw new Exception("File Excel không có dữ liệu hoặc không đúng định dạng.");  // Nếu không có đủ dữ liệu, báo lỗi
                                }

                                // Lặp qua các dòng dữ liệu bắt đầu từ dòng thứ 2 (dòng đầu tiên là tiêu đề)
                                for (int row = 2; row <= rowCount; row++)
                                {
                                    // Lấy dữ liệu từ các cột trong dòng hiện tại (tên, hình ảnh, mô tả, loại vật dụng)
                                    string ten = worksheet.Cells[row, 1].Text.Trim();
                                    string hinh = worksheet.Cells[row, 2].Text.Trim();
                                    string moTa = worksheet.Cells[row, 3].Text.Trim();
                                    string loai = worksheet.Cells[row, 4].Text.Trim().ToLower();

                                    // Kiểm tra nếu tên hoặc loại vật dụng bị thiếu
                                    if (string.IsNullOrEmpty(ten) || string.IsNullOrEmpty(loai))
                                    {
                                        throw new Exception($"Dữ liệu không hợp lệ tại dòng {row}. Vui lòng kiểm tra lại.");
                                    }

                                    // Xác định id_loai dựa trên loại vật dụng (ví dụ: nếu là sách, id_loai = 1, ngược lại = 2)
                                    int id_loai = loai.Contains("sách") ? 1 : 2;

                                    // Tạo đối tượng dữ liệu để gửi lên API
                                    var data = new
                                    {
                                        tenVatDung = ten,
                                        hinhAnh = hinh,
                                        moTa = moTa,
                                        id_LoaiVatDung = id_loai
                                    };

                                    // Gửi dữ liệu lên API thông qua phương thức Post
                                    var response = APIContext.PostMethod("VatDung", data);

                                    // Kiểm tra kết quả trả về từ API, nếu không thành công thì ném lỗi
                                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                                    {
                                        throw new Exception($"Lỗi ở dòng {row}: {APIContext.getErrorMessage(response)}");
                                    }
                                }

                                // Hiển thị thông báo thành công nếu tất cả dữ liệu được xử lý thành công
                                MessageBox.Show("Thêm vật dụng từ Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                                // Gọi lại phương thức ReloadData để làm mới dữ liệu trong giao diện
                                this.Invoke((MethodInvoker)ReloadData);
                            }
                        }
                        catch (Exception ex)
                        {
                            // Nếu có lỗi trong quá trình xử lý file Excel, hiển thị thông báo lỗi
                            MessageBox.Show($"Lỗi khi đọc file Excel: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        }
                    }
                }
            });
            // Đảm bảo luồng chạy dưới chế độ STA
            staThread.SetApartmentState(ApartmentState.STA);

            // Khởi động luồng
            staThread.Start();
        }


        public void refeshTable()
        {
           ReloadData();
        }


        // Hàm làm mới dữ liệu
        private void ReloadData()
        {
            vatDungs = APIContext.GetMethod<VatDung>("VatDung")
                .Where(v => v.tinhTrang != TinhTrangVatDung.Ẩn.ToString())
                .ToList();
            dataGridView1.DataSource = null; // bỏ dữ liệu cũ
            dataGridView1.DataSource = vatDungs; // Gán dữ liệu mới
            // Đảm bảo không đăng ký trùng sự kiện
            dataGridView1.CellFormatting -= cellFormatting;
            dataGridView1.CellFormatting += cellFormatting;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["tenVatDung"].HeaderText = "Tên vật dụng";
            dataGridView1.Columns["hinhAnh"].Visible = false;
            dataGridView1.Columns["moTa"].HeaderText = "Mô tả";
            dataGridView1.Columns["id_LoaiVatDung"].HeaderText = "Loại vật dụng";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void loadData()
        {
            // Đảm bảo không đăng ký trùng sự kiện
            dataGridView1.CellFormatting -= cellFormatting;
            dataGridView1.CellFormatting += cellFormatting;
            dataGridView1.Columns["id"].HeaderText = "ID";
            dataGridView1.Columns["id"].FillWeight = 30;
            dataGridView1.Columns["tenVatDung"].HeaderText = "Tên vật dụng";
            dataGridView1.Columns["hinhAnh"].Visible = false;
            dataGridView1.Columns["moTa"].HeaderText = "Mô tả";
            dataGridView1.Columns["id_LoaiVatDung"].HeaderText = "Loại vật dụng";
            dataGridView1.Columns["tinhTrang"].HeaderText = "Tình trạng";
        }

        private void text_search_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_btn_Click(object sender, EventArgs e)
        {
            string searchText = text_search.Text.ToLower();

            var filteredVatDungs = vatDungs
                .Where(vatDung => vatDung.tenVatDung.ToLower().Contains(searchText) ||
                                 vatDung.id_LoaiVatDung == 1 && "Sách".ToLower().Contains(searchText) ||
                                 vatDung.id_LoaiVatDung != 1 && "Thiết bị".ToLower().Contains(searchText) ||
                                 vatDung.id.ToString().ToLower().Contains(searchText) ||
                                 vatDung.tinhTrang.ToLower().Contains(searchText))
                                 
                .ToList();

            dataGridView1.DataSource = null; // bỏ dữ liệu cũ
            dataGridView1.DataSource = filteredVatDungs; // Gán dữ liệu mới
            loadData();
        }

        // Hàm bấm bằng nút Enter
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                search_btn.PerformClick(); // Mô phỏng một cú nhấp chuột
                return true; // Chỉ ra rằng phím nhấn đã được xử lý
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

    }
}
