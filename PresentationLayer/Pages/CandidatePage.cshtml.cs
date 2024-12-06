using BusinessLogicLayer;
using DatabaseLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PresentationLayer.Pages
{
    public class CandidatePageModel : PageModel
    {
        private readonly UngVienService _ungVienService;

        public CandidatePageModel(UngVienService ungVienService)
        {
            _ungVienService = ungVienService;
        }

        public List<UngVien> UngViens { get; set; } = new List<UngVien>();

        public void OnGet(int maTinTD)
        {
            // Ki?m tra mã tin tuy?n d?ng h?p l? và l?y danh sách ?ng viên

            UngViens = _ungVienService.GetCandidatesByJobId(maTinTD);

        }
    }
}
