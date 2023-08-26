using Diploma.Domain.Entities;

namespace Diploma.Client.Services.BreadcrumbService
{
    public interface IBreadcrumbService
    {
        IReadOnlyList<BreadcrumbItem> Breadcrumbs { get; }
        void AddBreadcrumb(string label, string link);
        void ClearBreadcrumbs();
    }
}
