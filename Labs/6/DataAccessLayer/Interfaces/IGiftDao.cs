using BusinessLayer;

namespace DataAccessLayer.Interfaces;

public interface IGiftDao
{
    Gift Load(string path);
    void Save(Gift gift, string path);
    void SaveReport(string path, string text);
}