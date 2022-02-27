using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oyster.ApplicationCore.Extensions;

public class PagedList<T>:List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; set; }
    public PagedList(List<T> items,int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count/(double)pageSize);
        this.AddRange(items);
    }
    public bool PreviouPage
    {
        get { return this.PageIndex > 1; }
    }
    public bool NextPage
    {
        get { return (PageIndex < TotalPages); }
    }
}
