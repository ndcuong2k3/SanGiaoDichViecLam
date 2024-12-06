using BusinessLogicLayer;
using DataAccessLayer;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PresentationLayer
{
    public class JobPageModle : PageModel
    {
        private readonly JobManager _jobManager;

        public JobPageModle(JobManager jobManager)
        {
            _jobManager = jobManager;
        }

        public List<TinTuyenDung> tblTinTuyenDung { get; set; } = new List<TinTuyenDung>();
        public string? Message { get; set; }

        public void OnGet()
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            tblTinTuyenDung = _jobManager.GetAllJobs();
        }

        public IActionResult OnPost(string jobTitle, DateTime datePosted, string description, int salary, int numberOfEmployees, string workLocation)
        {
            // Kiểm tra nếu chuỗi không rỗng trước khi kiểm tra thông tin khác
            if (IsStringEmpty(jobTitle, workLocation, description))
            {
                TempData["ErrorMessage"] = "Các trường thông tin không được để trống.";
                return RedirectToPage();
            }

            if (!IsValidData(salary, numberOfEmployees))
            {
                TempData["ErrorMessage"] = "Nhập đúng lương và số lượng nhân viên cần tuyển";
                return RedirectToPage();
            }

            // Tạo tin tuyển dụng mới
            var newJobPost = new TinTuyenDung
            {
                sTenTinTD = jobTitle,
                dNgayDang = datePosted,
                sMoTa = description,
                iMucLuong = salary,
                iSoNguoiTuyen = numberOfEmployees,
                sNoiLamViec = workLocation
            };

            try
            {
                // Thêm tin tuyển dụng vào cơ sở dữ liệu thông qua JobManager
                _jobManager.AddJob(newJobPost);

                // Cập nhật thông báo thành công
                TempData["SuccessMessage"] = "Đăng tin tuyển dụng thành công.";
            }
            catch (Exception)
            {
                // Cập nhật thông báo lỗi nếu có lỗi trong quá trình thêm tin
                TempData["ErrorMessage"] = "Đăng tin tuyển dụng thất bại.";
            }

            // Tải lại trang và hiển thị danh sách tin tuyển dụng
            return RedirectToPage();
        }

        private bool IsStringEmpty(params string[] values)
        {
            return values.Any(string.IsNullOrEmpty);
        }

        private bool IsValidData(int salary, int numberOfEmployees)
        {
            return salary > 0 && numberOfEmployees >= 0;
        }
    }
}