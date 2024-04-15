﻿using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CleanArchBlog_crud.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
