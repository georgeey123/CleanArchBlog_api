using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanArchBlog_crud.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
