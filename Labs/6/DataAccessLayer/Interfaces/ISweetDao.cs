using BusinessLayer.Sweets;

namespace DataAccessLayer.Interfaces;

public interface ISweetDao
{
    IReadOnlyList<Sweet> GetAll();
    void Add(Sweet sweet);
}