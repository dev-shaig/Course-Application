using Domain.Models;

namespace Repository.Data
{
    public static class AppDbContext<T>
    {
        public static List<T> Datas { get; }

        static AppDbContext()
        {
            Datas = [];
        }

    }
}
