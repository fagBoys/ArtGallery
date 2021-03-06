﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ArtGallery
{
    public class PaginatefList<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPage { get; private set; }

        public PaginatefList(List<T> items, int count, int PageIndex, int PageSize)
        {
            this.PageIndex = PageIndex;
            this.TotalPage = (int)Math.Ceiling(count / (double)PageSize);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPage);
            }
        }

        public static async Task<PaginatefList<T>> CreateAsunc(IQueryable<T> source, int PageIndex, int PageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((PageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            return new PaginatefList<T>(items, count, PageIndex, PageSize);
        }
    }
}
