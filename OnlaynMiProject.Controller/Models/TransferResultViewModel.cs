using OnlaynMiProject.DtoLayer;
using OnlaynMiProject.EntityLayer;

namespace OnlaynMiProject.Controller.Models;

public class TransferResultViewModel
{
    public decimal Sum { get; set; }
    public decimal Share { get; set; }
    public List<Transfer> Transfers { get; set; }
}