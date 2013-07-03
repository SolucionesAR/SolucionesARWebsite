using System.Globalization;
using System.Web.Mvc;
using AutoMapper;
using PagedList;
using SolucionesARWebsite2.Business.Management;
using SolucionesARWebsite2.Models;
using SolucionesARWebsite2.ViewModels.Companies;

namespace SolucionesARWebsite2.Controllers
{
    public class CompaniesController : BaseController
    {
        #region Private Members

        private readonly CompaniesManagement _companiesManagement;

        #endregion

        #region Constructors

        public CompaniesController(CompaniesManagement companiesManagement, UsersManagement usersManagement)
            : base(usersManagement)
        {
            _companiesManagement = companiesManagement;
        }

        #endregion

        #region Public Actions

        public ActionResult Index(IndexViewModel indexViewModel)
        {
            var pageIndex = indexViewModel.Page.HasValue ? (int)indexViewModel.Page : FirstPage;
            //missing filtering
            var results = _companiesManagement.GetCompaniesList(SecurityContext);
            indexViewModel.PagedItems = results.ToPagedList(pageIndex, PageSize);

            return View(indexViewModel);
        }

        public ActionResult Create()
        {
            var editViewModel = new EditViewModel
                                    {
                                        CompanyId = 0,
                                        CompanyName = string.Empty,
                                        
                                    };
            return View("Edit", editViewModel);
        }

        public ActionResult Edit(int id)
        {
            var company = _companiesManagement.GetCompany(id);

            Mapper.CreateMap<Company, EditViewModel>()
                  .ForMember(dest => dest.CashBackPercentage, opt => opt.MapFrom(src => src.CashBackPercentaje)); 
            var editViewModel = Mapper.Map<Company, EditViewModel>(company);

            return View(editViewModel);
        }

        [HttpPost]
        public ActionResult Save(EditViewModel editFormModel)
        {
            if (ModelState.IsValid)
            {
                Mapper.CreateMap<EditViewModel, Company>()
                      .ForMember(dest => dest.CashBackPercentaje, opt => opt.MapFrom(src => src.CashBackPercentage))
                      .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName.ToUpper()))
                      .ForMember(dest => dest.CompanyNickName,
                                 opt =>
                                 opt.MapFrom(
                                     src => src.CompanyNickname != null ? src.CompanyNickname.ToUpper() : string.Empty))
                      .ForMember(dest => dest.CorporateId,
                                 opt =>
                                 opt.MapFrom(
                                     src => src.CorporateId != null ? src.CorporateId.Replace("-", string.Empty) : string.Empty));
                var company = Mapper.Map<EditViewModel, Company>(editFormModel);

                _companiesManagement.Save(company);

                return RedirectToAction("Index");
            }

            return View("Edit", editFormModel);
        }

        #endregion

        #region Private Members
        #endregion
    }
}