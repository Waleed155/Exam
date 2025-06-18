using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Runtime.CompilerServices;

namespace Exam.Helper
{
    public static class  MapperHelper
    {
        public static IMapper _mapper { get; set; }
        public static TResult Mapone<TResult>(this object Source)
        {
            return
                 _mapper.Map<TResult>(Source);
        }
        public static IQueryable<TResult> MapList<TResult>(this IQueryable Source)
        {
            return Source.ProjectTo<TResult>(_mapper.ConfigurationProvider);
            
        }

    }
}