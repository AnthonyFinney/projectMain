using ProjectMain.Models;

namespace ProjectMain.Services.Interfaces;

public interface ISearchService {
    Task<IEnumerable<Template>> SearchTemplatesAsync(string query);
}