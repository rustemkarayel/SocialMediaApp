
namespace SocialMediaApp.PagedList
{
    public class Pager
    {
        public int BeginPage { get; set; }
        public int EndPage { get; set; }
        public int ActivePage { get; set; }
        //Sayfa sayısı
        public int PageSize { get; set; }
        //Toplam kayıt sayısı
        public int TotalData { get; set; }
        //Bir sayfada görüntülenecek sayfa sayısı
        public int CurrentData { get; set; }

		public Pager()
		{

		}

		public Pager(int itemCounts,int pageSize, int page)     //parametre sırası önemli.
        {

            ActivePage = page;
            TotalData = itemCounts;
            CurrentData = pageSize;     //Bir sayfada görüntülenecek sayfa sayısı

            PageSize = (int)Math.Ceiling((decimal)TotalData / (decimal)CurrentData);
            
            BeginPage = ActivePage - 5;
            EndPage = ActivePage + 4;

            if (BeginPage < 1)
            {
                EndPage = EndPage - (BeginPage - 1);
                BeginPage= 1;
            }
            if(EndPage>PageSize) 
            {
                EndPage = PageSize;
                if (EndPage > 10)
                {
                    BeginPage = EndPage - 9;
                }
            }      
        }
    }
}
