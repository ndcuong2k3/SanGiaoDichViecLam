using BusinessLogicLayer;
using DatabaseLayer;

namespace PresentationLayer
{
    public class CandidatePageModel
    {
        private readonly UngVienService _ungVienService;

        public CandidatePageModel(UngVienService ungVienService)
        {
            _ungVienService = ungVienService;
        }

        public List<UngVien> UngViens { get; set; } = new List<UngVien>();

        public void OnGet(int maTinTD)
        {
            // Kiểm tra mã tin tuyển dụng hợp lệ và lấy danh sách ứng viên

            UngViens = _ungVienService.GetCandidatesByJobId(maTinTD);

        }
    }
}
