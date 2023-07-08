using OnlaynMiProject.DataAccessLayer.Concrete;
using OnlaynMiProject.DtoLayer;
using OnlaynMiProject.EntityLayer;
using OnlaynMiProject.EntityLayer.Concrete;

namespace OnlaynMiProject.Controller.Models;

public class TransferMethod
{
    public void Transfers(List<AppUser> appUsers)
    {
        decimal totalsum = 0;
        foreach (var user in appUsers)
        {
            totalsum += user.Sum;
        }
        int count = appUsers.Count;
        decimal share = totalsum / count;

        List<AppUser> paidLess = new List<AppUser>();
        List<AppUser> paidMore = new List<AppUser>();
        foreach (var p in appUsers)
        {
            decimal newValue = share - p.Sum;
            p.Sum = newValue;

            if (newValue > 0)
            {
                paidLess.Add(p);
            }
            else
            {
                paidMore.Add(p);
            }                

        }

        paidLess = paidLess.OrderByDescending(p => p.Sum).ToList();
        paidMore = paidMore.OrderBy(p => p.Sum).ToList();

        MoveEqualTransfersToBeginning(paidLess, paidMore);

        List<Transfer> transfers = new List<Transfer>();
        int i = 0;
        int j = 0;
        while (i < paidLess.Count && j < paidMore.Count)
        {
            int paidLessId = paidLess[i].Id;
            int paidMoreId = paidMore[j].Id;
            decimal remainder = paidLess[i].Sum + paidMore[j].Sum;
            decimal paid;
            if (remainder > 0)
            {
                paid = paidLess[i].Sum - remainder;
                paidLess[i].Sum = remainder;
                j++;
            }
            else
            {
                paid = paidLess[i].Sum;
                paidMore[j].Sum = remainder;
                i++;
            }

            decimal roundedPaid = System.Math.Round(paid);
            if (roundedPaid > 0)
            {
                transfers.Add(new Transfer { FromId = paidLessId, EventId=14, ToId = paidMoreId, Pay = roundedPaid });
            }
        }

        Context context = new Context();
        context.Transfers.AddRange(transfers);
        context.SaveChanges();
        

        var transferResult = new TransferResultViewModel()
        {
            Sum = totalsum,
            Share = Math.Round(share, 2),
            Transfers = transfers
        };

    }

    private void MoveEqualTransfersToBeginning(List<AppUser> paidLess, List<AppUser> paidMore)
    {
        int i = 0;
        int j = 0;
        while (i < paidLess.Count)
        {
            while (j < paidMore.Count)
            {
                if (paidLess[i].Sum + paidMore[j].Sum == 0)
                {
                    var element = paidLess[i];
                    paidLess.RemoveAt(i);
                    paidLess.Insert(0, element);
                    element = paidMore[j];
                    paidMore.RemoveAt(j);
                    paidMore.Insert(0, element);
                    break;
                }
                j++;
            }
            j = 0;
            i++;
        }
    }
}