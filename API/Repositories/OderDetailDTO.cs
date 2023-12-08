using API.Model;

namespace API.Repositories;

public interface OderDetailDTO
{
    List<OderDetail> GetlistOderDetail();
    OderDetail GetOderDetailById(int id);
    // OderDetail ADDOderDetail(OderDetail oderDetail);
    void UpdateOderDetail(long PriceTotal, int Quantity,int id);
    void DeleteOderDetail(int id);
}