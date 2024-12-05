using BusinessLogicLayer;
using DataAccessLayer;
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
        public string ?Message { get; set; }

        public void OnGet()
        {
            // Lấy danh sách sản phẩm từ cơ sở dữ liệu
            tblTinTuyenDung = _jobManager.GetAllJobs();
        }

        public IActionResult OnPost(string jobTitle, DateTime datePosted, string description, int salary, int numberOfEmployees, string workLocation)
        {
            // Kiểm tra nếu có thông tin hợp lệ
            if (string.IsNullOrEmpty(jobTitle) || salary <= 0 || numberOfEmployees < 0 || string.IsNullOrEmpty(workLocation))
            {
                TempData["ErrorMessage"] = "Invalid input. Please check your data.";
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



    }
}
