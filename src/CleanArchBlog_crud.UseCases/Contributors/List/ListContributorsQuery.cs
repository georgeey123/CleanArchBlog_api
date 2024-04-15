using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanArchBlog_crud.UseCases.Contributors.List;

public record ListContributorsQuery(int? Skip, int? Take) : IQuery<Result<IEnumerable<ContributorDTO>>>;
