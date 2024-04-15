using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanArchBlog_crud.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
