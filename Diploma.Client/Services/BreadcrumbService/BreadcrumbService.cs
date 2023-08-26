using Diploma.Domain.Entities;

namespace Diploma.Client.Services.BreadcrumbService
{
    public class BreadcrumbService : IBreadcrumbService
    {
        public List<BreadcrumbItem> _breadcrumbs = new List<BreadcrumbItem>();

        public IReadOnlyList<BreadcrumbItem> Breadcrumbs => _breadcrumbs;

        public void AddBreadcrumb(string label, string link)
        {
            _breadcrumbs.Add(new BreadcrumbItem { Label = label, Link = link });
        }

        public void ClearBreadcrumbs()
        {
            _breadcrumbs.Clear();
        }
    }
}
