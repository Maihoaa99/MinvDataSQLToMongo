using AutoMapper;

namespace MV_SqlToMongo.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<dmdvcs, Branch>()
                .ForMember(x => x.branchId, x => x.MapFrom(x => x.dmdvcs_id))
                .ForMember(x => x.branchCode, x => x.MapFrom(x => x.ma_dvcs))
                .ForMember(x => x.branchName, x => x.MapFrom(x => x.ten_dvcs))
                .ForMember(x => x.taxCode, x => x.MapFrom(x => x.ms_thue))
                .ForMember(x => x.addressApi, x => x.MapFrom(x => x.post_invoice))
                .ForMember(x => x.address, x => x.MapFrom(x => x.dia_chi))
                .ForMember(x => x.email, x => x.MapFrom(x => x.email))
                .ForMember(x => x.userNew, x => x.MapFrom(x => x.user_new))
                .ForMember(x => x.dateNew, x => x.MapFrom(x => x.date_new))
                .ForMember(x => x.userEdit, x => x.MapFrom(x => x.user_edit))
                .ForMember(x => x.dateEdit, x => x.MapFrom(x => x.date_edit))
                .ForMember(x => x.isUse, x => x.MapFrom(x => x.is_use))
                .ForMember(x => x.phone, x => x.MapFrom(x => x.sdt))
                .ForMember(x => x.token, x => x.MapFrom(x => x.token))
                ;
        }
    }
}
