﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Abstraction.Messaging;
using Backend.Domain.Common.Result;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces;

namespace Backend.Application.Features.CategoryManager.Queries
{
    public class GetAllCategoriesQuery : IQuery<GetAllCategoriesResponse>
    {
    }

    public  class GetAllCategoriesResponse
    {
        public List<Category> categoriesResponse { get; set; } = new List<Category> { new Category() };
    }

    internal sealed class GetAllCategoriesQueryHandler : IQueryHandler<GetAllCategoriesQuery, GetAllCategoriesResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository) 
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<Result<GetAllCategoriesResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryRepository.GetAll();
            if (categories == null) 
            {
                return Result<GetAllCategoriesResponse>.Failure(["there is no category"]);
            }

            GetAllCategoriesResponse response = new GetAllCategoriesResponse
            {
                categoriesResponse = categories
            };


            return Result<GetAllCategoriesResponse>.Success(response);
        }
    }
}
