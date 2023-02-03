using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using podsticarijum_backend.Application.DTO;
using podsticarijum_backend.Domain.Entities;

namespace podsticarijum_backend.Application.EntityExtensions;

public static class ExpertExtensions
{
    public static ExpertDto ToDto(this Expert expert)
        => new ExpertDto(
            subCategoryDto: expert.SubCategory.ToDto(), 
            firstName: expert.FirstName, 
            lastName: expert.LastName, 
            email: expert.Email);

    public static List<ExpertDto> ToDto(this IEnumerable<Expert> experts)
        => experts.Select(e => e.ToDto()).ToList();
}
